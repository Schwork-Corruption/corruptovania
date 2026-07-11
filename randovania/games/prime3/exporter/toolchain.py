from __future__ import annotations

import dataclasses
import os
import platform
import subprocess
from pathlib import Path
from typing import TYPE_CHECKING

import nod

import randovania

if TYPE_CHECKING:
    from randovania.lib.status_update_lib import ProgressUpdateCallable


@dataclasses.dataclass(frozen=True)
class Prime3Toolchain:
    randomizer_command: tuple[str, ...]
    hpatchz_command: tuple[str, ...]
    wit_command: tuple[str, ...]
    extractor_command: tuple[str, ...]
    uses_python_nod: bool
    randomizer_environment: dict[str, str] = dataclasses.field(default_factory=dict)
    lzokay_library: Path | None = None


def _patcher_root() -> Path:
    return randovania.get_data_path().joinpath("gollop_mp3_patcher")


def _required_path(path: Path, message: str) -> str:
    if not path.is_file():
        raise FileNotFoundError(f"{message}: {path}")
    return os.fspath(path)


def resolve_prime3_toolchain() -> Prime3Toolchain:
    patcher_root = _patcher_root()
    system = platform.system()

    if system == "Windows":
        return Prime3Toolchain(
            randomizer_command=(_required_path(patcher_root.joinpath("MP3Randomizer.exe"), "Missing MP3Randomizer"),),
            hpatchz_command=(_required_path(patcher_root.joinpath("hpatchz.exe"), "Missing hpatchz"),),
            wit_command=(_required_path(patcher_root.joinpath("wit", "bin", "wit.exe"), "Missing wit"),),
            extractor_command=(
                _required_path(patcher_root.joinpath("nodtool", "nodtool.exe"), "Missing nodtool"),
                "extract",
            ),
            uses_python_nod=False,
        )

    if system == "Darwin":
        macos_root = patcher_root.joinpath("macos")
        _required_path(macos_root.joinpath("MP3Randomizer.dll"), "Missing macOS MP3Randomizer managed payload")
        _required_path(macos_root.joinpath("dotnet"), "Missing bundled macOS dotnet runtime")
        return Prime3Toolchain(
            randomizer_command=(_required_path(macos_root.joinpath("MP3Randomizer"), "Missing macOS MP3Randomizer"),),
            hpatchz_command=(_required_path(macos_root.joinpath("hpatchz"), "Missing macOS hpatchz"),),
            wit_command=(_required_path(macos_root.joinpath("wit"), "Missing macOS wit"),),
            extractor_command=(),
            uses_python_nod=True,
            randomizer_environment={
                "DOTNET_ROOT": os.fspath(macos_root),
                "DOTNET_MULTILEVEL_LOOKUP": "0",
                "PATH": f"{macos_root}{os.pathsep}{os.environ['PATH']}",
            },
            lzokay_library=Path(_required_path(macos_root.joinpath("liblzokay.dylib"), "Missing macOS liblzokay")),
        )

    raise RuntimeError(f"Metroid Prime 3 exporting is not supported on {system}.")


def extract_prime3_disc_image(
    toolchain: Prime3Toolchain,
    input_path: Path,
    extract_path: Path,
    progress_update: ProgressUpdateCallable,
) -> None:
    if toolchain.uses_python_nod:
        disc, _is_wii = nod.open_disc_from_image(input_path)
        data_partition = disc.get_data_partition()
        if data_partition is None:
            raise RuntimeError(f"Could not find a Wii data partition in '{input_path}'.")

        context = nod.ExtractionContext()
        context.set_progress_callback(progress_update)
        data_partition.extract_to_directory(os.fspath(extract_path), context)
        if not extract_path.joinpath("DATA", "files").is_dir() or not extract_path.joinpath("DATA", "sys").is_dir():
            raise RuntimeError(f"Prime 3 extraction did not produce DATA/files and DATA/sys under '{extract_path}'.")
        return

    subprocess.run([*toolchain.extractor_command, os.fspath(input_path), os.fspath(extract_path)], check=True)
