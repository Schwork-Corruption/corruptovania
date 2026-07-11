from __future__ import annotations

import argparse
import os
import shutil
import stat
import subprocess
import sys
import urllib.request
from dataclasses import dataclass
from pathlib import Path

EXPECTED_ARCHES = ("x86_64", "arm64")
DOTNET_ARCH_TO_RUNTIME = {
    "x86_64": "x64",
    "arm64": "arm64",
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
HDIFFPATCH_DEPENDENCIES = {
    "libmd5": "https://github.com/sisong/libmd5.git",
    "xxHash": "https://github.com/sisong/xxHash.git",
    "lzma": "https://github.com/sisong/lzma.git",
    "zstd": "https://github.com/sisong/zstd.git",
    "zlib": "https://github.com/sisong/zlib.git",
    "libdeflate": "https://github.com/sisong/libdeflate.git",
    "bzip2": "https://github.com/sisong/bzip2.git",
}


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
    for name, repository in HDIFFPATCH_DEPENDENCIES.items():
        destination = checkout_root.joinpath(name)
        if destination.exists():
            shutil.rmtree(destination)
        run(["git", "clone", "--depth", "1", repository, os.fspath(destination)])


def parse_dotnet_runtime_version(output: str) -> str:
    for line in output.splitlines():
        line = line.strip()
        if line.startswith("Microsoft.NETCore.App "):
            return line.split()[1]
    raise RuntimeError("Unable to determine installed Microsoft.NETCore.App runtime version.")


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
    with urllib.request.urlopen("https://dot.net/v1/dotnet-install.sh") as response:
        destination.write_bytes(response.read())
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


def assert_universal2(path: Path) -> None:
    arches = arches_for(path)
    if tuple(sorted(arches)) != tuple(sorted(EXPECTED_ARCHES)):
        raise RuntimeError(f"{path} does not contain both architectures: {arches}")


def merge_binary(left: Path, right: Path, output: Path) -> None:
    output.parent.mkdir(parents=True, exist_ok=True)
    run(["lipo", "-create", os.fspath(left), os.fspath(right), "-output", os.fspath(output)])
    output.chmod(left.stat().st_mode)
    assert_universal2(output)


def merge_trees(left: Path, right: Path, output: Path) -> None:
    names = sorted({path.name for path in left.iterdir()} | {path.name for path in right.iterdir()})
    output.mkdir(parents=True, exist_ok=True)

    for name in names:
        left_path = left.joinpath(name)
        right_path = right.joinpath(name)
        output_path = output.joinpath(name)

        if left_path.exists() and right_path.exists():
            if left_path.is_dir() and right_path.is_dir():
                merge_trees(left_path, right_path, output_path)
                continue
            if left_path.is_symlink() and right_path.is_symlink():
                if left_path.readlink() != right_path.readlink():
                    raise RuntimeError(f"Mismatched symlink target for {left_path} and {right_path}")
                if output_path.exists():
                    output_path.unlink()
                output_path.symlink_to(left_path.readlink())
                continue
            if left_path.is_file() and right_path.is_file():
                if is_macho(left_path) or is_macho(right_path):
                    merge_binary(left_path, right_path, output_path)
                else:
                    if left_path.read_bytes() != right_path.read_bytes():
                        raise RuntimeError(f"Mismatched non-Mach-O file between {left_path} and {right_path}")
                    shutil.copy2(left_path, output_path)
                continue
            raise RuntimeError(f"Mismatched path types for {left_path} and {right_path}")

        lone_path = left_path if left_path.exists() else right_path
        if lone_path is None:  # pragma: no cover - defensive guard
            continue
        if is_macho(lone_path):
            raise RuntimeError(f"Missing matching architecture pair for Mach-O file: {lone_path}")
        if lone_path.is_dir():
            shutil.copytree(lone_path, output_path, symlinks=True)
        elif lone_path.is_symlink():
            if output_path.exists():
                output_path.unlink()
            output_path.symlink_to(lone_path.readlink())
        else:
            output_path.parent.mkdir(parents=True, exist_ok=True)
            shutil.copy2(lone_path, output_path)


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
    publish_root = build_root.joinpath("publish")
    ensure_empty_dir(publish_root)
    published_outputs: dict[str, Path] = {}

    for arch, runtime_identifier in {"x86_64": "osx-x64", "arm64": "osx-arm64"}.items():
        published_output = publish_root.joinpath(arch)
        run(
            [
                "dotnet",
                "publish",
                os.fspath(ROOT.joinpath("tools", "prime3_patcher", "MP3Randomizer", "MP3Randomizer.csproj")),
                "-c",
                "Release",
                "-f",
                "net8.0",
                "-r",
                runtime_identifier,
                "--self-contained",
                "false",
                "-o",
                os.fspath(published_output),
            ]
        )
        published_outputs[arch] = published_output

    merge_binary(
        published_outputs["x86_64"].joinpath("MP3Randomizer"),
        published_outputs["arm64"].joinpath("MP3Randomizer"),
        output_dir.joinpath("MP3Randomizer"),
    )

    reference_output = published_outputs["arm64"]
    for path in reference_output.iterdir():
        if path.name == "MP3Randomizer":
            continue
        if path.is_file():
            counterpart = published_outputs["x86_64"].joinpath(path.name)
            if counterpart.exists() and counterpart.is_file() and counterpart.read_bytes() != path.read_bytes():
                raise RuntimeError(f"Mismatched managed output file between publish directories: {path.name}")
            shutil.copy2(path, output_dir.joinpath(path.name))


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
    merge_trees(runtime_x64, runtime_arm64, output_dir)

    publish_mp3_randomizer(build_root, output_dir)

    build_lzokay(checkout_root, output_dir.joinpath("liblzokay.dylib"), deployment_target)
    build_hpatchz(checkout_root, build_root, output_dir.joinpath("hpatchz"), deployment_target)
    build_wit(checkout_root, build_root, output_dir.joinpath("wit"), deployment_target)

    assert_universal2(output_dir.joinpath("MP3Randomizer"))
    assert_universal2(output_dir.joinpath("dotnet"))
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
