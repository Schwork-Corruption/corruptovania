"""
Prepare universal2 wheels for the installed macOS packaging environment.

PyInstaller can only produce a real universal2 app when every bundled native
extension is itself universal2. This helper inspects the currently installed
packages, looks up the exact installed versions on PyPI, and then:

- reuses an existing universal2 wheel when one is available,
- merges matching x86_64 and arm64 wheels with ``delocate-merge``, or
- falls back to a pure-Python wheel when the installed package does not need a
  platform-specific wheel.
"""

from __future__ import annotations

import argparse
import json
import subprocess
import sys
import tempfile
import urllib.request
from dataclasses import dataclass
from pathlib import Path

from packaging.utils import canonicalize_name


@dataclass(frozen=True)
class WheelInfo:
    filename: str
    python_tag: str
    abi_tag: str
    platform_tag: str
    url: str


@dataclass(frozen=True)
class WheelPlan:
    kind: str
    wheels: tuple[WheelInfo, ...]


def parse_wheel_filename(url: str) -> WheelInfo:
    filename = url.rsplit("/", maxsplit=1)[-1]
    if not filename.endswith(".whl"):
        raise ValueError(f"Invalid wheel filename: {filename}")

    parts = filename[:-4].split("-")
    if len(parts) < 5:
        raise ValueError(f"Invalid wheel filename: {filename}")

    return WheelInfo(
        filename=filename,
        python_tag=parts[-3],
        abi_tag=parts[-2],
        platform_tag=parts[-1],
        url=url,
    )


def is_macos_wheel(platform_tag: str) -> bool:
    return platform_tag.startswith("macosx_")


def parse_macos_platform(platform_tag: str) -> tuple[str, tuple[int, int]]:
    if not is_macos_wheel(platform_tag):
        raise ValueError(f"Not a macOS platform tag: {platform_tag}")

    parts = platform_tag.split("_")
    if len(parts) < 4:
        raise ValueError(f"Invalid macOS platform tag: {platform_tag}")

    return "_".join(parts[3:]), (int(parts[1]), int(parts[2]))


def compatible_with_current_interpreter(wheel: WheelInfo) -> bool:
    if not is_macos_wheel(wheel.platform_tag):
        return False

    current_python_tag = f"cp{sys.version_info.major}{sys.version_info.minor}"
    return wheel.abi_tag == "abi3" or (
        wheel.python_tag == current_python_tag and wheel.abi_tag == current_python_tag
    )


def is_pure_python_wheel(wheel: WheelInfo) -> bool:
    return wheel.python_tag == "py3" and wheel.abi_tag == "none" and wheel.platform_tag == "any"


def sort_by_oldest_macos(wheels: list[WheelInfo]) -> list[WheelInfo]:
    return sorted(wheels, key=lambda wheel: parse_macos_platform(wheel.platform_tag)[1])


def select_merge_pair(wheels: list[WheelInfo]) -> tuple[WheelInfo, WheelInfo] | None:
    arm64 = sort_by_oldest_macos([wheel for wheel in wheels if parse_macos_platform(wheel.platform_tag)[0] == "arm64"])
    x86_64 = sort_by_oldest_macos(
        [wheel for wheel in wheels if parse_macos_platform(wheel.platform_tag)[0] == "x86_64"]
    )

    for x86_wheel in x86_64:
        for arm_wheel in arm64:
            if x86_wheel.abi_tag == arm_wheel.abi_tag and x86_wheel.python_tag == arm_wheel.python_tag:
                return x86_wheel, arm_wheel

    return None


def build_wheel_plan(wheels: list[WheelInfo]) -> WheelPlan | None:
    compatible = [wheel for wheel in wheels if compatible_with_current_interpreter(wheel)]
    pure_python = [wheel for wheel in wheels if is_pure_python_wheel(wheel)]

    universal2 = sort_by_oldest_macos(
        [wheel for wheel in compatible if parse_macos_platform(wheel.platform_tag)[0] == "universal2"]
    )
    if universal2:
        return WheelPlan("download", (universal2[0],))

    merge_pair = select_merge_pair(compatible)
    if merge_pair is not None:
        return WheelPlan("merge", merge_pair)

    if pure_python:
        return WheelPlan("download", (pure_python[0],))

    return None


def get_installed_packages() -> dict[str, str]:
    result = subprocess.run(
        [sys.executable, "-m", "pip", "list", "--format=json"],
        check=True,
        capture_output=True,
        text=True,
    )
    packages = json.loads(result.stdout)
    return {canonicalize_name(package["name"]): package["version"] for package in packages}


def fetch_release_wheels(package_name: str, version: str) -> list[WheelInfo]:
    normalized_name = package_name.replace("_", "-")
    with urllib.request.urlopen(f"https://pypi.org/pypi/{normalized_name}/{version}/json") as response:
        data = json.load(response)

    wheels = []
    for file_entry in data["urls"]:
        if file_entry["packagetype"] != "bdist_wheel":
            continue
        wheels.append(parse_wheel_filename(file_entry["url"]))
    return wheels


def download_wheel(url: str, output_dir: Path) -> Path:
    destination = output_dir.joinpath(url.rsplit("/", maxsplit=1)[-1])
    if destination.exists():
        return destination

    with urllib.request.urlopen(url) as response:
        destination.write_bytes(response.read())
    return destination


def merge_wheels(wheels: tuple[WheelInfo, WheelInfo], output_dir: Path) -> None:
    with tempfile.TemporaryDirectory() as temporary_directory:
        temp_dir = Path(temporary_directory)
        wheel_paths = [download_wheel(wheel.url, temp_dir) for wheel in wheels]
        subprocess.run(
            ["delocate-merge", "-w", os_fspath(output_dir), *(os_fspath(path) for path in wheel_paths)],
            check=True,
        )


def os_fspath(path: Path) -> str:
    return str(path)


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser()
    parser.add_argument("--output-dir", default="universal_wheels")
    return parser.parse_args()


def main() -> int:
    if sys.platform != "darwin":
        print("This helper is only supported on macOS.", file=sys.stderr)
        return 1

    output_dir = Path(parse_args().output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)

    failed_packages: list[str] = []
    installed_packages = get_installed_packages()

    for package_name, version in sorted(installed_packages.items()):
        wheels = fetch_release_wheels(package_name, version)
        plan = build_wheel_plan(wheels)
        if plan is None:
            continue

        print(f"Package: {package_name}=={version}")
        for wheel in plan.wheels:
            print(f"  {wheel.filename}")

        try:
            if plan.kind == "download":
                download_wheel(plan.wheels[0].url, output_dir)
            elif plan.kind == "merge":
                merge_wheels(plan.wheels, output_dir)
            else:
                raise ValueError(f"Unknown wheel plan kind: {plan.kind}")
        except Exception as exception:  # pragma: no cover - exercised in CI
            print(f"  Failed: {exception}")
            failed_packages.append(package_name)

    if failed_packages:
        print(f"Failed packages: {', '.join(failed_packages)}", file=sys.stderr)
        return 1

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
