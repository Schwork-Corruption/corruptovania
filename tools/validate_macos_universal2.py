from __future__ import annotations

import argparse
import subprocess
import sys
from pathlib import Path


EXPECTED_ARCHES = ("x86_64", "arm64")


def is_macho(path: Path) -> bool:
    result = subprocess.run(["file", "-b", str(path)], capture_output=True, text=True, check=True)
    return "Mach-O" in result.stdout


def arches_for(path: Path) -> set[str]:
    result = subprocess.run(["lipo", "-archs", str(path)], capture_output=True, text=True, check=True)
    return set(result.stdout.strip().split())


def find_missing_arches(root: Path) -> list[tuple[Path, set[str]]]:
    failures = []
    for path in root.rglob("*"):
        if not path.is_file() or path.is_symlink():
            continue
        if not is_macho(path):
            continue

        arches = arches_for(path)
        missing = set(EXPECTED_ARCHES) - arches
        if missing:
            failures.append((path, missing))

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
    failures = find_missing_arches(bundle)
    if failures:
        for path, missing in failures:
            print(f"{path}: missing {', '.join(sorted(missing))}", file=sys.stderr)
        return 1

    print(f"All Mach-O files under {bundle} contain: {' '.join(EXPECTED_ARCHES)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
