from __future__ import annotations

import dataclasses
import os
import shutil
import subprocess
import tempfile
from enum import Enum
from pathlib import Path
from typing import TYPE_CHECKING

import randovania
from randovania.exporter.game_exporter import GameExporter, GameExportParams
from randovania.games.prime3.exporter.toolchain import (
    Prime3Toolchain,
    extract_prime3_disc_image,
    resolve_prime3_toolchain,
)

if TYPE_CHECKING:
    from randovania.lib import status_update_lib


@dataclasses.dataclass(frozen=True)
class CorruptionGameExportParams(GameExportParams):
    input_path: Path
    output_path: Path
    output_format: CorruptionOutputFormats
    mp3_update: bool


class CorruptionOutputFormats(Enum):
    WBFS = "wbfs"
    ISO = "iso"


class CorruptionGameExporter(GameExporter):
    _busy: bool = False

    @property
    def can_start_new_export(self) -> bool:
        """
        Checks if the exporter is busy right now
        """
        return self._busy

    @property
    def export_can_be_aborted(self) -> bool:
        """
        Checks if export_game can be aborted
        """
        return False

    def export_params_type(self) -> type[GameExportParams]:
        """
        Returns the type of the GameExportParams expected by this exporter.
        """
        return CorruptionGameExportParams

    def _do_export_game(
        self,
        patch_data: dict,
        export_params: GameExportParams,
        progress_update: status_update_lib.ProgressUpdateCallable,
    ) -> None:
        assert isinstance(export_params, CorruptionGameExportParams)

        # Static patches and replacement assets remain in the normal Randovania data tree. Executable helpers are
        # resolved separately because frozen macOS builds install their Universal2 tools under the app Resources tree.
        patcher_path = randovania.get_data_path().joinpath("gollop_mp3_patcher")
        toolchain = resolve_prime3_toolchain()

        # Every export receives fresh extraction and staging directories. This prevents a failed export from leaving
        # stale files that could affect the next attempt, and the finally block removes both directories on all paths.
        extract_path = Path(tempfile.mkdtemp())
        paks_path: Path | None = None
        try:
            progress_update("Extracting ISO...", 0.1)
            extract_prime3_disc_image(toolchain, export_params.input_path, extract_path, progress_update)

            progress_update("Removing attract videos...", 0.2)
            dummy_attracts = ["attract01.thp", "Attract02.thp"]
            for name in dummy_attracts:
                shutil.copy(
                    Path(patcher_path).joinpath("dummy_attract", name),
                    extract_path.joinpath("DATA", "files", "Video", "FrontEnd", name),
                )

            if patch_data["disable_deflicker"]:
                progress_update("Disabling Deflicker...", 0.3)
                # hpatchz supports using the same file as its input and output, so the DOL patch is applied in place.
                _run_process(
                    _build_hpatchz_command(
                        toolchain,
                        extract_path.joinpath("DATA", "sys", "main.dol"),
                        patcher_path.joinpath("MP3Update", "main.hdiff"),
                    ),
                )

            if patch_data["mp3_update"]:
                progress_update("Applying Update...", 0.4)

                update_elements = [
                    "FrontEnd",
                    "InGameAudio",
                    "NoARAM",
                    "Metroid1",
                    "Metroid3",
                    "Metroid4",
                    "Metroid5",
                    "Metroid6",
                    "Metroid7",
                    "UniverseArea",
                ]
                for element in update_elements:
                    _run_process(
                        _build_hpatchz_command(
                            toolchain,
                            extract_path.joinpath("DATA", "files", f"{element}.pak"),
                            patcher_path.joinpath("MP3Update", f"{element}.hdiff"),
                        ),
                    )

            # MP3Randomizer only needs a subset of the extracted files as inputs. Stage those files separately so the
            # randomizer can write its results back into the complete extracted DATA tree without duplicating the disc.
            paks_path = Path(tempfile.mkdtemp())
            randomize_elements = [
                "FrontEnd.pak",
                "Logbook.pak",
                "Metroid1.pak",
                "Metroid3.pak",
                "Metroid4.pak",
                "Metroid5.pak",
                "Metroid6.pak",
                "Metroid7.pak",
                "Metroid8.pak",
                "MiscData.pak",
                "UniverseArea.pak",
                "Worlds.pak",
                "Standard.ntwk",
            ]
            progress_update("Copying Paks...", 0.5)
            for name in randomize_elements:
                shutil.copy(extract_path.joinpath("DATA", "files", name), paks_path.joinpath(name))

            progress_update("Randomizing Paks...", 0.6)
            _run_process(
                _build_randomizer_command(toolchain, patch_data, paks_path, extract_path.joinpath("DATA", "files")),
                env=toolchain.randomizer_environment,
            )

            progress_update(
                "Exporting to ISO..."
                if export_params.output_format == CorruptionOutputFormats.ISO
                else "Exporting to WBFS...",
                0.7,
            )
            # WIT rebuilds the final image from the modified DATA directory and writes it directly to the requested path.
            _run_process(_build_wit_command(toolchain, extract_path.joinpath("DATA"), export_params))
        finally:
            # Cleanup failures should not hide the helper or patching error that caused the export to abort.
            shutil.rmtree(extract_path, ignore_errors=True)
            if paks_path is not None:
                shutil.rmtree(paks_path, ignore_errors=True)


def _optional_flag(flag: str, enabled: bool) -> tuple[str, ...]:
    """Return a one-element argument tuple when an optional command-line flag is enabled."""
    if enabled:
        return (flag,)
    return ()


def _run_process(command: tuple[str, ...], env: dict[str, str] | None = None) -> None:
    """Run a Prime 3 helper and preserve useful stdout/stderr when it fails.

    ``env`` contains only tool-specific overrides. They are merged with the current process environment so helpers keep
    ordinary system settings while the macOS randomizer is directed to its bundled .NET runtime.
    """
    process_environment = None if env is None else {**os.environ, **env}
    try:
        subprocess.run(
            command,
            check=True,
            env=process_environment,
            capture_output=True,
            text=True,
        )
    except subprocess.CalledProcessError as exception:
        # Both streams are useful because the bundled helpers are inconsistent about which one receives diagnostics.
        diagnostic_parts = [
            part.strip()
            for part in (exception.stdout, exception.stderr)
            if isinstance(part, str) and part.strip()
        ]
        diagnostics = "\n".join(diagnostic_parts)

        # Keep enough output to diagnose the failure without producing an unbounded GUI error report.
        if len(diagnostics) > 12000:
            diagnostics = diagnostics[-12000:]

        message = (
            f"Prime 3 helper failed "
            f"({Path(command[0]).name}, exit code {exception.returncode}): "
            f"{command}"
        )
        if diagnostics:
            message += f"\n\nHelper output:\n{diagnostics}"

        raise RuntimeError(message) from exception


def _build_hpatchz_command(toolchain: Prime3Toolchain, target_file: Path, patch_file: Path) -> tuple[str, ...]:
    """Build an in-place hpatchz invocation for a DOL or PAK binary patch."""
    return (
        *toolchain.hpatchz_command,
        "-f",
        os.fspath(target_file),
        os.fspath(patch_file),
        os.fspath(target_file),
    )


def _build_randomizer_command(
    toolchain: Prime3Toolchain,
    patch_data: dict,
    input_path: Path,
    output_path: Path,
) -> tuple[str, ...]:
    """Translate seed patch data into the platform-specific MP3Randomizer command line."""
    starting_items = patch_data["starting_items"].split()
    starting_location = patch_data["starting_location"].split()

    # Preserve the trailing directory separators used by the original exporter. MP3Randomizer accepts directory paths,
    # and retaining the established form avoids platform-specific differences in its path concatenation behavior.
    return (
        *toolchain.randomizer_command,
        "--input-path",
        os.fspath(input_path) + os.sep,
        "--output-path",
        os.fspath(output_path) + os.sep,
        "--layout",
        patch_data["seed"],
        "--starting-items",
        *starting_items,
        "--starting-location",
        *starting_location,
        *_optional_flag("--random-door-colors", patch_data["random_door_colors"]),
        *_optional_flag("--random-welding-colors", patch_data["random_welding_colors"]),
        "--hyper-hints",
        "--fast-flying",
        *_optional_flag("--require-launcher", patch_data["missile_required_mains"]),
        *_optional_flag("--require-ship-missile", patch_data["ship_missile_required_mains"]),
        *_optional_flag("--phaaze-skip", patch_data["phaaze_skip"]),
    )


def _build_wit_command(
    toolchain: Prime3Toolchain,
    extracted_data_path: Path,
    export_params: CorruptionGameExportParams,
) -> tuple[str, ...]:
    """Build the WIT command that converts the patched DATA tree into the requested disc-image format."""
    return (
        *toolchain.wit_command,
        "COPY",
        # WIT uses -I for ISO output and -B for WBFS output; the remaining flags preserve the legacy exporter behavior.
        "-I" if export_params.output_format == CorruptionOutputFormats.ISO else "-B",
        "-z",
        "--trunc",
        "--auto-split",
        "--overwrite",
        os.fspath(extracted_data_path),
        os.fspath(export_params.output_path),
    )