from __future__ import annotations

import argparse
import os
import stat
import subprocess
import sys
from pathlib import Path

EXPECTED_ARCHES = ("x86_64", "arm64")
EXECUTABLE_HELPERS = ("MP3Randomizer", "dotnet", "hpatchz", "wit")
REQUIRED_HELPERS = {
    "MP3Randomizer": "data/gollop_mp3_patcher/macos/MP3Randomizer",
    "MP3Randomizer.dll": "data/gollop_mp3_patcher/macos/MP3Randomizer.dll",
    "dotnet": "data/gollop_mp3_patcher/macos/dotnet",
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
    lines = run(["otool", "-L", os.fspath(path)]).stdout.splitlines()[1:]
    result = []
    for line in lines:
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
    if len(matches) > 1:
        raise RuntimeError(f"Found multiple matches for helper {suffix}: {matches}")
    return matches[0]


def validate_dependency_paths(path: Path) -> list[str]:
    failures = []
    for dependency in otool_loads(path):
        if dependency.startswith(ALLOWED_LOAD_PREFIXES):
            continue
        failures.append(f"{path}: disallowed dependency reference {dependency}")
    return failures


def validate_required_helpers(bundle: Path) -> list[str]:
    failures = []
    for helper_name, suffix in REQUIRED_HELPERS.items():
        helper_path = find_helper(bundle, suffix)
        if is_macho(helper_path):
            arches = arches_for(helper_path)
            missing = set(EXPECTED_ARCHES) - arches
            if missing:
                failures.append(f"{helper_path}: missing {', '.join(sorted(missing))}")

        if helper_name in EXECUTABLE_HELPERS and not is_executable(helper_path):
            failures.append(f"{helper_path}: expected executable mode")

        if is_macho(helper_path):
            failures.extend(validate_dependency_paths(helper_path))
            try:
                codesign_verify(helper_path)
            except subprocess.CalledProcessError as exception:
                failures.append(f"{helper_path}: codesign verification failed: {exception}")

    return failures


def validate_all_macho_files(bundle: Path) -> list[str]:
    failures = []
    for path in bundle.rglob("*"):
        if not path.is_file() or path.is_symlink():
            continue
        if not is_macho(path):
            continue

        arches = arches_for(path)
        missing = set(EXPECTED_ARCHES) - arches
        if missing:
            failures.append(f"{path}: missing {', '.join(sorted(missing))}")
        failures.extend(validate_dependency_paths(path))

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

    print(f"All Mach-O files under {bundle} contain: {' '.join(EXPECTED_ARCHES)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
