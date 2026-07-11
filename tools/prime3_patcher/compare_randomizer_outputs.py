from __future__ import annotations

import argparse
import hashlib
import os
import shutil
import subprocess
import tempfile
from pathlib import Path

DEFAULT_OLD_RANDOMIZER = Path("randovania/data/gollop_mp3_patcher/MP3Randomizer.exe")
DEFAULT_NEW_RANDOMIZER = Path("tools/prime3_patcher/MP3Randomizer/bin/Release/net8.0/MP3Randomizer.dll")


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser()
    parser.add_argument("--seed", required=True)
    parser.add_argument("--old-randomizer", default=DEFAULT_OLD_RANDOMIZER)
    parser.add_argument("--new-randomizer", default=DEFAULT_NEW_RANDOMIZER)
    parser.add_argument("--dotnet", default="dotnet")
    parser.add_argument("--starting-items", default="original-with-command")
    parser.add_argument("--starting-location", default="norion")
    return parser.parse_args()


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as file:
        for chunk in iter(lambda: file.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()


def build_command(
    executable: tuple[str, ...],
    *,
    input_path: Path,
    output_path: Path,
    seed: str,
    starting_items: str,
    starting_location: str,
) -> list[str]:
    return [
        *executable,
        "--input-path",
        os.fspath(input_path) + os.sep,
        "--output-path",
        os.fspath(output_path) + os.sep,
        "--layout",
        seed,
        "--starting-items",
        starting_items,
        "--starting-location",
        starting_location,
        "--hyper-hints",
        "--fast-flying",
    ]


def compare_directories(left: Path, right: Path) -> list[str]:
    failures = []
    left_files = {path.relative_to(left) for path in left.rglob("*") if path.is_file()}
    right_files = {path.relative_to(right) for path in right.rglob("*") if path.is_file()}

    for relative_path in sorted(left_files ^ right_files):
        failures.append(f"Path set differs: {relative_path}")

    for relative_path in sorted(left_files & right_files):
        left_hash = sha256(left.joinpath(relative_path))
        right_hash = sha256(right.joinpath(relative_path))
        if left_hash != right_hash:
            failures.append(f"SHA256 mismatch for {relative_path}: {left_hash} != {right_hash}")

    return failures


def main() -> int:
    root = os.environ.get("CORRUPTOVANIA_MP3_TEST_DATA")
    if not root:
        raise RuntimeError("CORRUPTOVANIA_MP3_TEST_DATA must point to private Prime 3 fixture data.")

    args = parse_args()
    fixture_root = Path(root)
    input_source = fixture_root.joinpath("input")
    if not input_source.is_dir():
        raise FileNotFoundError(f"Missing private input fixture directory: {input_source}")

    with tempfile.TemporaryDirectory() as temporary_directory:
        temp_root = Path(temporary_directory)
        old_input = temp_root.joinpath("old-input")
        new_input = temp_root.joinpath("new-input")
        old_output = temp_root.joinpath("old-output")
        new_output = temp_root.joinpath("new-output")
        shutil.copytree(input_source, old_input)
        shutil.copytree(input_source, new_input)
        old_output.mkdir()
        new_output.mkdir()

        subprocess.run(
            build_command(
                (os.fspath(Path(args.old_randomizer)),),
                input_path=old_input,
                output_path=old_output,
                seed=args.seed,
                starting_items=args.starting_items,
                starting_location=args.starting_location,
            ),
            check=True,
        )
        subprocess.run(
            build_command(
                (args.dotnet, os.fspath(Path(args.new_randomizer))),
                input_path=new_input,
                output_path=new_output,
                seed=args.seed,
                starting_items=args.starting_items,
                starting_location=args.starting_location,
            ),
            check=True,
        )

        failures = compare_directories(old_output, new_output)
        if failures:
            for failure in failures:
                print(failure)
            return 1

    print("Outputs match.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
