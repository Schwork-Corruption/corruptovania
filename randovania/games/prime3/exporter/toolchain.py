from __future__ import annotations

import dataclasses
import os
import platform
import subprocess
from pathlib import Path
from typing import TYPE_CHECKING

import nod  # type: ignore[import-untyped]

import randovania

if TYPE_CHECKING:
    from randovania.lib.status_update_lib import ProgressUpdateCallable


@dataclasses.dataclass(frozen=True)
class Prime3Toolchain:
    """Resolved helper commands and environment needed by the Prime 3 exporter.

    Commands are stored as tuples because a helper may be either a single executable, as on Windows, or a command
    prefix such as ``dotnet MP3Randomizer.dll`` on macOS. The exporter appends operation-specific arguments later.
    ``uses_python_nod`` distinguishes the bundled Windows nodtool process from the Python nod bindings used on macOS.
    """

    randomizer_command: tuple[str, ...]
    hpatchz_command: tuple[str, ...]
    wit_command: tuple[str, ...]
    extractor_command: tuple[str, ...]
    uses_python_nod: bool
    randomizer_environment: dict[str, str] = dataclasses.field(default_factory=dict)
    lzokay_library: Path | None = None


def _patcher_root() -> Path:
    """Locate the root containing Prime 3 patch data and platform-specific helper tools."""
    # Source checkouts and the Windows package keep the patcher beneath Randovania's ordinary data directory.
    default_root = randovania.get_data_path().joinpath("gollop_mp3_patcher")

    if platform.system() == "Darwin" and randovania.is_frozen():
        # The macOS toolchain is installed after PyInstaller packaging so its split .NET runtime trees are preserved.
        # Those manually installed files live in Contents/Resources rather than PyInstaller's normal data location.
        resources_root = randovania.get_file_path().parent.joinpath(
            "Resources",
            "data",
            "gollop_mp3_patcher",
        )
        # Falling back to the default root keeps source tests and incomplete development bundles diagnosable.
        if resources_root.is_dir():
            return resources_root

    return default_root


def _required_path(path: Path, message: str) -> str:
    """Return a filesystem path string, raising a focused packaging error when the file is absent."""
    if not path.is_file():
        raise FileNotFoundError(f"{message}: {path}")
    return os.fspath(path)


def _macos_runtime_directory(machine: str) -> str:
    """Map Python's machine name to the matching bundled .NET runtime directory."""
    # Apple and Python installations may report the ARM architecture using either spelling.
    if machine in {"arm64", "aarch64"}:
        return "dotnet-arm64"
    if machine in {"x86_64", "AMD64"}:
        return "dotnet-x64"
    raise RuntimeError(f"Unsupported macOS architecture for Prime 3 export: {machine}")


def resolve_prime3_toolchain() -> Prime3Toolchain:
    """Resolve and validate the Prime 3 helper commands for the current operating system.

    This function performs validation before extraction starts so a damaged or incomplete application bundle fails with
    a precise missing-file error instead of reaching the middle of a several-gigabyte export first.
    """
    patcher_root = _patcher_root()
    system = platform.system()

    if system == "Windows":
        # Preserve the established Windows path: every helper is a bundled native executable and nodtool performs
        # extraction in a child process.
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
        runtime_root = macos_root.joinpath(_macos_runtime_directory(platform.machine()))

        # MP3Randomizer is published as a portable managed application. The sidecar files tell the private dotnet host
        # which framework and dependencies the application requires, so validate all three before launching it.
        _required_path(macos_root.joinpath("MP3Randomizer.dll"), "Missing macOS MP3Randomizer managed payload")
        _required_path(macos_root.joinpath("MP3Randomizer.deps.json"), "Missing macOS MP3Randomizer deps file")
        _required_path(
            macos_root.joinpath("MP3Randomizer.runtimeconfig.json"),
            "Missing macOS MP3Randomizer runtimeconfig file",
        )

        return Prime3Toolchain(
            # Use the runtime matching the current process architecture. The app bundle carries both runtime trees even
            # though one Universal2 launch uses only a single architecture at a time.
            randomizer_command=(
                _required_path(runtime_root.joinpath("dotnet"), "Missing bundled macOS dotnet runtime"),
                _required_path(macos_root.joinpath("MP3Randomizer.dll"), "Missing macOS MP3Randomizer managed payload"),
            ),
            # hpatchz and WIT are Universal2 executables and therefore do not need architecture-specific paths.
            hpatchz_command=(_required_path(macos_root.joinpath("hpatchz"), "Missing macOS hpatchz"),),
            wit_command=(_required_path(macos_root.joinpath("wit"), "Missing macOS wit"),),
            extractor_command=(),
            uses_python_nod=True,
            # Force the managed helper to remain self-contained within the app instead of consulting a system-wide .NET
            # installation that may be missing, incompatible, or for the other architecture.
            randomizer_environment={
                "DOTNET_ROOT": os.fspath(runtime_root),
                "DOTNET_MULTILEVEL_LOOKUP": "0",
                "PATH": f"{runtime_root}{os.pathsep}{os.environ.get('PATH', '')}",
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
    """Extract a Prime 3 disc image into the DATA layout consumed by the remaining export steps."""
    if toolchain.uses_python_nod:
        # The legacy nodtool executable is Windows-only. macOS uses the same nod library through its Python bindings,
        # which are already packaged as the correct native architecture inside the Universal2 application.
        disc, _is_wii = nod.open_disc_from_image(input_path)
        data_partition = disc.get_data_partition()
        if data_partition is None:
            raise RuntimeError(f"Could not find a Wii data partition in '{input_path}'.")

        context = nod.ExtractionContext()
        context.set_progress_callback(progress_update)
        data_partition.extract_to_directory(os.fspath(extract_path), context)

        # Later patching assumes nod's standard DATA/files and DATA/sys layout. Validate it here so malformed images or
        # extraction regressions fail before hpatchz or MP3Randomizer receive confusing missing-file paths.
        if not extract_path.joinpath("DATA", "files").is_dir() or not extract_path.joinpath("DATA", "sys").is_dir():
            raise RuntimeError(f"Prime 3 extraction did not produce DATA/files and DATA/sys under '{extract_path}'.")
        return

    # Windows retains the pre-existing nodtool command path to avoid altering the proven exporter behavior there.
    subprocess.run([*toolchain.extractor_command, os.fspath(input_path), os.fspath(extract_path)], check=True)