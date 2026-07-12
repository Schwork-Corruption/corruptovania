from __future__ import annotations

import argparse
import hashlib
import os
import shutil
import stat
import subprocess
import sys
import urllib.request
from dataclasses import dataclass
from pathlib import Path

EXPECTED_ARCHES = ("x86_64", "arm64")
DOTNET_RUNTIME_FAMILY = "8.0"
DOTNET_ARCH_TO_RUNTIME = {
    "x86_64": "x64",
    "arm64": "arm64",
}
RUNTIME_DIRECTORY_NAMES = {
    "x86_64": "dotnet-x64",
    "arm64": "dotnet-arm64",
}
MACHO_MAGICS = {
    b"\xca\xfe\xba\xbe",
    b"\xbe\xba\xfe\xca",
    b"\xca\xfe\xba\xbf",
    b"\xbf\xba\xfe\xca",
    b"\xfe\xed\xfa\xce",
    b"\xce\xfa\xed\xfe",
    b"\xfe\xed\xfa\xcf",
    b"\xcf\xfa\xed\xfe",
}
ROOT = Path(__file__).resolve().parents[2]
ALLOWED_LOAD_PREFIXES = ("@executable_path", "@loader_path", "@rpath", "/System/Library/", "/usr/lib/")
DISALLOWED_LOAD_PREFIXES = ("/opt/homebrew/", "/usr/local/", "/private/tmp/", "/tmp/")
REQUIRED_RUNTIME_BINARIES = (
    "dotnet",
    "libhostfxr.dylib",
    "libhostpolicy.dylib",
    "libcoreclr.dylib",
    "libclrjit.dylib",
    "libSystem.Native.dylib",
    "libSystem.IO.Compression.Native.dylib",
    "libSystem.Security.Cryptography.Native.Apple.dylib",
)


@dataclass(frozen=True)
class GitSource:
    name: str
    repository: str
    ref: str


LZOKAY_SOURCE = GitSource(
    name="lzokay",
    repository="https://github.com/AxioDL/lzokay.git",
    ref="db2df1fcbebc2ed06c10f727f72567d40f06a2be",
)
HDIFFPATCH_SOURCE = GitSource(
    name="HDiffPatch",
    repository="https://github.com/sisong/HDiffPatch.git",
    ref="v5.0.1",
)
WIT_SOURCE = GitSource(
    name="wiimms-iso-tools",
    repository="https://github.com/Wiimm/wiimms-iso-tools.git",
    ref="fc1c0b840cb3ac41ca6e4f1d5e16da12b47eab58",
)
HDIFFPATCH_DEPENDENCIES = (
    GitSource("libmd5", "https://github.com/sisong/libmd5.git", "51edeb63ec3f456f4950922c5011c326a062fbce"),
    GitSource("xxHash", "https://github.com/sisong/xxHash.git", "e626a72bc2321cd320e953a0ccf1584cad60f363"),
    GitSource("lzma", "https://github.com/sisong/lzma.git", "44809544b95bbf2dccec75d954657ff76fc349ff"),
    GitSource("zstd", "https://github.com/sisong/zstd.git", "68c88c7c7ad22b5e6882a5296ef96d27dc8750c4"),
    GitSource("zlib", "https://github.com/sisong/zlib.git", "323357a50daba38cedd2b766b3427f4c6d33b10f"),
    GitSource("libdeflate", "https://github.com/sisong/libdeflate.git", "8f894fab60464e13ddee3846eae722216347fac1"),
    GitSource("bzip2", "https://github.com/sisong/bzip2.git", "fbc4b11da543753b3b803e5546f56e26ec90c2a7"),
)
DOTNET_INSTALL_SCRIPT_URL = (
    "https://raw.githubusercontent.com/dotnet/install-scripts/"
    "4a37a9f9d1a061fc389d6515100336db4e51710e/src/dotnet-install.sh"
)
DOTNET_INSTALL_SCRIPT_SHA256 = "082f7685e156738a1b2e2ed8381a621870d4ce8e8c59278034556f05c186eb2e"


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser()
    parser.add_argument(
        "--output-dir",
        default=ROOT.joinpath("randovania", "data", "gollop_mp3_patcher", "macos"),
    )
    parser.add_argument(
        "--work-dir",
        default=ROOT.joinpath("build", "prime3-macos-toolchain"),
    )
    parser.add_argument(
        "--deployment-target",
        default=os.environ.get("MACOSX_DEPLOYMENT_TARGET", "12.0"),
    )
    parser.add_argument(
        "--dotnet-runtime-version",
        default=None,
    )
    return parser.parse_args()


def run(command: list[str], *, cwd: Path | None = None, env: dict[str, str] | None = None) -> None:
    print("+", " ".join(command))
    subprocess.run(command, cwd=cwd, env=env, check=True)


def ensure_empty_dir(path: Path) -> None:
    if path.exists():
        shutil.rmtree(path)
    path.mkdir(parents=True, exist_ok=True)


def clone_source(source: GitSource, checkout_root: Path) -> Path:
    destination = checkout_root.joinpath(source.name)
    if destination.exists():
        shutil.rmtree(destination)
    run(["git", "clone", source.repository, os.fspath(destination)])
    run(["git", "checkout", source.ref], cwd=destination)
    return destination


def clone_hdiffpatch_dependencies(checkout_root: Path) -> None:
    for dependency in HDIFFPATCH_DEPENDENCIES:
        clone_source(dependency, checkout_root)


def parse_dotnet_runtime_version(output: str) -> str:
    candidates: list[tuple[int, ...]] = []
    for line in output.splitlines():
        line = line.strip()
        if line.startswith("Microsoft.NETCore.App "):
            version = line.split()[1]
            if version.startswith(f"{DOTNET_RUNTIME_FAMILY}."):
                candidates.append(tuple(int(part) for part in version.split(".")))
    if not candidates:
        raise RuntimeError(f"Unable to determine installed Microsoft.NETCore.App {DOTNET_RUNTIME_FAMILY} runtime.")
    return ".".join(str(part) for part in max(candidates))


def installed_dotnet_runtime_version() -> str:
    result = subprocess.run(
        ["dotnet", "--list-runtimes"],
        check=True,
        capture_output=True,
        text=True,
    )
    return parse_dotnet_runtime_version(result.stdout)


def download_dotnet_install_script(work_dir: Path) -> Path:
    work_dir.mkdir(parents=True, exist_ok=True)
    destination = work_dir.joinpath("dotnet-install.sh")
    with urllib.request.urlopen(DOTNET_INSTALL_SCRIPT_URL) as response:
        script_bytes = response.read()
    digest = hashlib.sha256(script_bytes).hexdigest()
    if digest != DOTNET_INSTALL_SCRIPT_SHA256:
        raise RuntimeError(
            f"Unexpected checksum for dotnet-install.sh: {digest} != {DOTNET_INSTALL_SCRIPT_SHA256}"
        )
    destination.write_bytes(script_bytes)
    destination.chmod(destination.stat().st_mode | stat.S_IXUSR)
    return destination


def dotnet_runtime_arch(arch: str) -> str:
    try:
        return DOTNET_ARCH_TO_RUNTIME[arch]
    except KeyError as exception:  # pragma: no cover - defensive guard
        raise ValueError(f"Unsupported architecture: {arch}") from exception


def dotnet_arch_flags(arch: str, deployment_target: str) -> list[str]:
    return [
        "-arch",
        arch,
        f"-mmacosx-version-min={deployment_target}",
    ]


def is_macho(path: Path) -> bool:
    if not path.is_file() or path.is_symlink():
        return False
    with path.open("rb") as file:
        return file.read(4) in MACHO_MAGICS


def arches_for(path: Path) -> tuple[str, ...]:
    result = subprocess.run(["lipo", "-archs", os.fspath(path)], check=True, capture_output=True, text=True)
    return tuple(result.stdout.strip().split())


def macho_load_commands(path: Path) -> tuple[str, ...]:
    result = subprocess.run(["otool", "-L", os.fspath(path)], check=True, capture_output=True, text=True)
    commands = []
    for line in result.stdout.splitlines()[1:]:
        stripped = line.strip()
        if stripped:
            commands.append(stripped.split(" (", maxsplit=1)[0])
    return tuple(commands)


def validate_macho_load_commands(path: Path) -> None:
    for load_command in macho_load_commands(path):
        if load_command.startswith(DISALLOWED_LOAD_PREFIXES):
            raise RuntimeError(f"{path} links against a disallowed path: {load_command}")
        if load_command.startswith("/"):
            if not load_command.startswith(ALLOWED_LOAD_PREFIXES):
                raise RuntimeError(f"{path} links against a non-system absolute path: {load_command}")
        elif not load_command.startswith(ALLOWED_LOAD_PREFIXES):
            raise RuntimeError(f"{path} links against an unresolved path: {load_command}")


def assert_universal2(path: Path) -> None:
    arches = arches_for(path)
    if tuple(sorted(arches)) != tuple(sorted(EXPECTED_ARCHES)):
        raise RuntimeError(f"{path} does not contain both architectures: {arches}")
    validate_macho_load_commands(path)


def assert_single_arch(path: Path, expected_arch: str) -> None:
    arches = set(arches_for(path))
    if expected_arch not in arches:
        raise RuntimeError(f"{path} does not contain required architecture {expected_arch}: {sorted(arches)}")
    wrong_arches = set(EXPECTED_ARCHES) - {expected_arch}
    unexpected = sorted(arches & wrong_arches)
    if unexpected:
        raise RuntimeError(f"{path} unexpectedly contains {', '.join(unexpected)} in {expected_arch} runtime tree")
    validate_macho_load_commands(path)


def merge_binary(left: Path, right: Path, output: Path) -> None:
    output.parent.mkdir(parents=True, exist_ok=True)
    run(["lipo", "-create", os.fspath(left), os.fspath(right), "-output", os.fspath(output)])
    output.chmod(left.stat().st_mode)
    assert_universal2(output)


def copy_runtime_tree(source: Path, destination: Path) -> None:
    if destination.exists():
        shutil.rmtree(destination)
    shutil.copytree(source, destination, symlinks=True, copy_function=shutil.copy2)


def find_unique_file(root: Path, filename: str) -> Path:
    matches = [path for path in root.rglob(filename) if path.is_file()]
    if not matches:
        raise RuntimeError(f"Missing required runtime binary: {filename}")
    if len(matches) > 1:
        raise RuntimeError(f"Found multiple matches for required runtime binary {filename}: {matches}")
    return matches[0]


def is_user_executable(path: Path) -> bool:
    return bool(path.stat().st_mode & stat.S_IXUSR)


def validate_runtime_tree(runtime_root: Path, expected_arch: str) -> None:
    dotnet_path = runtime_root.joinpath("dotnet")
    if not dotnet_path.is_file():
        raise RuntimeError(f"Missing required runtime binary: {dotnet_path}")
    if not is_user_executable(dotnet_path):
        raise RuntimeError(f"Runtime host is not executable: {dotnet_path}")

    for filename in REQUIRED_RUNTIME_BINARIES:
        find_unique_file(runtime_root, filename)

    for path in runtime_root.rglob("*"):
        if not path.is_file() or path.is_symlink():
            continue
        if not is_macho(path):
            continue
        assert_single_arch(path, expected_arch)


def install_dotnet_runtime(
    *,
    install_script: Path,
    runtime_version: str,
    runtime_arch: str,
    install_dir: Path,
) -> None:
    ensure_empty_dir(install_dir)
    run(
        [
            "bash",
            os.fspath(install_script),
            "--version",
            runtime_version,
            "--runtime",
            "dotnet",
            "--architecture",
            runtime_arch,
            "--install-dir",
            os.fspath(install_dir),
        ]
    )


def publish_mp3_randomizer(build_root: Path, output_dir: Path) -> None:
    publish_root = build_root.joinpath("publish-portable")
    ensure_empty_dir(publish_root)
    run(
        [
            "dotnet",
            "publish",
            os.fspath(ROOT.joinpath("tools", "prime3_patcher", "MP3Randomizer", "MP3Randomizer.csproj")),
            "-c",
            "Release",
            "-f",
            "net8.0",
            "--self-contained",
            "false",
            "-p:UseAppHost=false",
            "-o",
            os.fspath(publish_root),
        ]
    )

    for filename in ("MP3Randomizer.dll", "MP3Randomizer.deps.json", "MP3Randomizer.runtimeconfig.json"):
        source = publish_root.joinpath(filename)
        if not source.is_file():
            raise RuntimeError(f"Missing published MP3Randomizer payload file: {source}")
        shutil.copy2(source, output_dir.joinpath(filename))


def build_lzokay(checkout_root: Path, output_path: Path, deployment_target: str) -> None:
    source_root = clone_source(LZOKAY_SOURCE, checkout_root)
    command = [
        "clang++",
        "-std=c++14",
        "-dynamiclib",
        *dotnet_arch_flags("x86_64", deployment_target),
        *dotnet_arch_flags("arm64", deployment_target),
        os.fspath(source_root.joinpath("lzokay.cpp")),
        os.fspath(source_root.joinpath("lzokay-c", "lzokay-c.cpp")),
        "-install_name",
        "@rpath/liblzokay.dylib",
        "-o",
        os.fspath(output_path),
    ]
    run(command)
    assert_universal2(output_path)


def build_hpatchz(checkout_root: Path, build_root: Path, output_path: Path, deployment_target: str) -> None:
    source_root = clone_source(HDIFFPATCH_SOURCE, checkout_root)
    clone_hdiffpatch_dependencies(checkout_root)
    binaries: list[Path] = []

    for arch in EXPECTED_ARCHES:
        arch_output = build_root.joinpath(f"hpatchz-{arch}")
        if arch_output.exists():
            arch_output.unlink()

        run(["make", "clean"], cwd=source_root)
        run(
            [
                "make",
                "-j",
                "hpatchz",
                "CC=clang",
                "CXX=clang++",
                f"CFLAGS={' '.join(dotnet_arch_flags(arch, deployment_target))}",
                f"CXXFLAGS={' '.join(dotnet_arch_flags(arch, deployment_target))}",
                f"LDFLAGS={' '.join(dotnet_arch_flags(arch, deployment_target))}",
            ],
            cwd=source_root,
        )
        shutil.copy2(source_root.joinpath("hpatchz"), arch_output)
        binaries.append(arch_output)

    merge_binary(binaries[0], binaries[1], output_path)


def build_wit(checkout_root: Path, build_root: Path, output_path: Path, deployment_target: str) -> None:
    source_root = clone_source(WIT_SOURCE, checkout_root)
    project_root = source_root.joinpath("project")
    binaries: list[Path] = []

    for arch in EXPECTED_ARCHES:
        arch_output = build_root.joinpath(f"wit-{arch}")
        if arch_output.exists():
            arch_output.unlink()

        run(["make", "clean"], cwd=project_root)
        run(
            [
                "make",
                "-j",
                "wit",
                "CC=clang",
                "CPP=clang++",
                "STRIP=true",
                f"XFLAGS={' '.join(dotnet_arch_flags(arch, deployment_target))}",
                "XLIBS=",
            ],
            cwd=project_root,
        )
        shutil.copy2(project_root.joinpath("wit"), arch_output)
        binaries.append(arch_output)

    merge_binary(binaries[0], binaries[1], output_path)


def build_macos_toolchain(output_dir: Path, work_dir: Path, deployment_target: str, runtime_version: str) -> None:
    output_dir = output_dir.resolve()
    work_dir = work_dir.resolve()
    checkout_root = work_dir.joinpath("sources")
    build_root = work_dir.joinpath("build-products")
    runtime_x64 = build_root.joinpath("dotnet-x64")
    runtime_arm64 = build_root.joinpath("dotnet-arm64")
    install_script = work_dir.joinpath("dotnet-install.sh")

    ensure_empty_dir(work_dir)
    ensure_empty_dir(output_dir)
    ensure_empty_dir(checkout_root)
    ensure_empty_dir(build_root)

    if install_script.exists():
        install_script.unlink()
    install_script = download_dotnet_install_script(work_dir)

    install_dotnet_runtime(
        install_script=install_script,
        runtime_version=runtime_version,
        runtime_arch=dotnet_runtime_arch("x86_64"),
        install_dir=runtime_x64,
    )
    install_dotnet_runtime(
        install_script=install_script,
        runtime_version=runtime_version,
        runtime_arch=dotnet_runtime_arch("arm64"),
        install_dir=runtime_arm64,
    )
    copy_runtime_tree(runtime_x64, output_dir.joinpath(RUNTIME_DIRECTORY_NAMES["x86_64"]))
    copy_runtime_tree(runtime_arm64, output_dir.joinpath(RUNTIME_DIRECTORY_NAMES["arm64"]))

    publish_mp3_randomizer(build_root, output_dir)

    build_lzokay(checkout_root, output_dir.joinpath("liblzokay.dylib"), deployment_target)
    build_hpatchz(checkout_root, build_root, output_dir.joinpath("hpatchz"), deployment_target)
    build_wit(checkout_root, build_root, output_dir.joinpath("wit"), deployment_target)

    validate_runtime_tree(output_dir.joinpath(RUNTIME_DIRECTORY_NAMES["x86_64"]), "x86_64")
    validate_runtime_tree(output_dir.joinpath(RUNTIME_DIRECTORY_NAMES["arm64"]), "arm64")
    assert_universal2(output_dir.joinpath("hpatchz"))
    assert_universal2(output_dir.joinpath("wit"))
    assert_universal2(output_dir.joinpath("liblzokay.dylib"))


def main() -> int:
    if sys.platform != "darwin":
        print("This helper is only supported on macOS.", file=sys.stderr)
        return 1

    args = parse_args()
    runtime_version = args.dotnet_runtime_version or installed_dotnet_runtime_version()
    build_macos_toolchain(
        output_dir=Path(args.output_dir),
        work_dir=Path(args.work_dir),
        deployment_target=args.deployment_target,
        runtime_version=runtime_version,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
