from __future__ import annotations

import argparse
import os
import stat
import subprocess
import sys
from pathlib import Path

EXPECTED_ARCHES = ("x86_64", "arm64")
RUNTIME_ARCH_DIRECTORIES = {
    "dotnet-x64": "x86_64",
    "dotnet-arm64": "arm64",
}
EXECUTABLE_HELPERS = (
    "data/gollop_mp3_patcher/macos/dotnet-x64/dotnet",
    "data/gollop_mp3_patcher/macos/dotnet-arm64/dotnet",
    "data/gollop_mp3_patcher/macos/hpatchz",
    "data/gollop_mp3_patcher/macos/wit",
)
REQUIRED_HELPERS = {
    "MP3Randomizer.dll": "data/gollop_mp3_patcher/macos/MP3Randomizer.dll",
    "MP3Randomizer.deps.json": "data/gollop_mp3_patcher/macos/MP3Randomizer.deps.json",
    "MP3Randomizer.runtimeconfig.json": "data/gollop_mp3_patcher/macos/MP3Randomizer.runtimeconfig.json",
    "dotnet-x64": "data/gollop_mp3_patcher/macos/dotnet-x64/dotnet",
    "dotnet-arm64": "data/gollop_mp3_patcher/macos/dotnet-arm64/dotnet",
    "liblzokay.dylib": "data/gollop_mp3_patcher/macos/liblzokay.dylib",
    "hpatchz": "data/gollop_mp3_patcher/macos/hpatchz",
    "wit": "data/gollop_mp3_patcher/macos/wit",
}
SYSTEM_LIBRARY_PREFIXES = ("/System/Library/", "/usr/lib/")
ALLOWED_LOAD_PREFIXES = ("@executable_path", "@loader_path", "@rpath", *SYSTEM_LIBRARY_PREFIXES)


def run(command: list[str]) -> subprocess.CompletedProcess[str]:
    return subprocess.run(command, capture_output=True, text=True, check=True)


def is_macho(path: Path) -> bool:
    return "Mach-O" in run(["file", "-b", os.fspath(path)]).stdout


def arches_for(path: Path) -> set[str]:
    return set(run(["lipo", "-archs", os.fspath(path)]).stdout.strip().split())


def otool_loads(path: Path) -> list[str]:
    lines = run(["otool", "-L", os.fspath(path)]).stdout.splitlines()
    result = []
    for line in lines:
        # Fat Mach-O output has one unindented header for each architecture.
        # Only indented lines are install names or linked dependencies.
        if not line[:1].isspace():
            continue

        stripped = line.strip()
        if not stripped:
            continue
        result.append(stripped.split(" (", maxsplit=1)[0])
    return result


def codesign_verify(path: Path) -> None:
    subprocess.run(["codesign", "--verify", "--strict", os.fspath(path)], check=True)


def is_executable(path: Path) -> bool:
    return bool(path.stat().st_mode & stat.S_IXUSR)


def find_helper(bundle: Path, suffix: str) -> Path:
    matches = [path for path in bundle.rglob("*") if path.is_file() and path.as_posix().endswith(suffix)]
    if not matches:
        raise FileNotFoundError(f"Missing required helper: {suffix}")

    # PyInstaller's macOS bundle layout can expose the same file through
    # Resources and Frameworks using symlinks or hardlinks. Collapse aliases
    # that refer to the same underlying file, but still reject real duplicates.
    unique_matches: list[Path] = []
    for match in matches:
        if any(match.samefile(existing) for existing in unique_matches):
            continue
        unique_matches.append(match)

    if len(unique_matches) > 1:
        raise RuntimeError(f"Found multiple distinct matches for helper {suffix}: {matches}")

    return min(
        matches,
        key=lambda candidate: (
            candidate.is_symlink(),
            "Contents/Resources" not in candidate.as_posix(),
            candidate.as_posix(),
        ),
    )


def validate_dependency_paths(path: Path) -> list[str]:
    failures = []
    for dependency in otool_loads(path):
        if dependency.startswith(ALLOWED_LOAD_PREFIXES):
            continue
        failures.append(f"{path}: disallowed dependency reference {dependency}")
    return failures


def expected_arch_for_runtime_path(path: Path) -> str | None:
    for part in path.parts:
        if part in RUNTIME_ARCH_DIRECTORIES:
            return RUNTIME_ARCH_DIRECTORIES[part]
    return None


def validate_required_helpers(bundle: Path) -> list[str]:
    failures = []
    for helper_name, suffix in REQUIRED_HELPERS.items():
        helper_path = find_helper(bundle, suffix)

        if suffix in EXECUTABLE_HELPERS and not is_executable(helper_path):
            failures.append(f"{helper_path}: expected executable mode")

    return failures


def validate_all_macho_files(bundle: Path) -> list[str]:
    failures = []
    for path in bundle.rglob("*"):
        if not path.is_file() or path.is_symlink():
            continue
        if not is_macho(path):
            continue

        arches = arches_for(path)
        runtime_arch = expected_arch_for_runtime_path(path)
        if runtime_arch is None:
            missing = set(EXPECTED_ARCHES) - arches
            if missing:
                failures.append(f"{path}: missing {', '.join(sorted(missing))}")
        else:
            if runtime_arch not in arches:
                failures.append(f"{path}: missing {runtime_arch}")
            opposite_arch = (set(EXPECTED_ARCHES) - {runtime_arch}) & arches
            if opposite_arch:
                failures.append(f"{path}: contains unexpected {', '.join(sorted(opposite_arch))}")
        failures.extend(validate_dependency_paths(path))
        try:
            codesign_verify(path)
        except subprocess.CalledProcessError as exception:
            failures.append(f"{path}: codesign verification failed: {exception}")

    return failures


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser()
    parser.add_argument("bundle")
    return parser.parse_args()


def main() -> int:
    if sys.platform != "darwin":
        print("This helper is only supported on macOS.", file=sys.stderr)
        return 1

    bundle = Path(parse_args().bundle)
    failures = [*validate_all_macho_files(bundle), *validate_required_helpers(bundle)]
    if failures:
        for failure in failures:
            print(failure, file=sys.stderr)
        return 1

    print(f"All required macOS binaries under {bundle} passed architecture and codesign validation.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
