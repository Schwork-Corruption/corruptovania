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
        # path to the root of the patcher
        patcher_path = randovania.get_data_path().joinpath("gollop_mp3_patcher")
        # path to where nod extracts the ISO
        extract_path = tempfile.mkdtemp()

        # Extract iso to extract_path
        progress_update("Extracting ISO...", 0.1)
        subprocess.run(
            [patcher_path.joinpath("nodtool", "nodtool.exe"), "extract", export_params.input_path, extract_path],
            check=True,
        )

        # remove attract videos
        progress_update("Removing attract videos...", 0.2)
        dummy_attracts = ["attract01.thp", "Attract02.thp"]
        for name in dummy_attracts:
            # place supplied dummy attract files directly in extract_path
            shutil.copy(
                Path(patcher_path).joinpath("dummy_attract", name),
                Path(extract_path).joinpath("DATA", "files", "Video", "FrontEnd", name),
            )

        if patch_data["disable_deflicker"]:
            progress_update("Disabling Deflicker...", 0.3)
            # run MP3Update on main.dol directly, agnostic to MP3Update itself
            subprocess.run(
                [
                    patcher_path.joinpath("hpatchz.exe"),
                    "-f",
                    Path(extract_path).joinpath("DATA", "sys", "main.dol"),
                    patcher_path.joinpath("MP3Update", "main.hdiff"),
                    Path(extract_path).joinpath("DATA", "sys", "main.dol"),
                ],
                check=True,
            )

        # MP3Update, if applicable
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
            # run MP3Update on files listed above directly
            for element in update_elements:
                subprocess.run(
                    [
                        patcher_path.joinpath("hpatchz.exe"),
                        "-f",
                        Path(extract_path).joinpath("DATA", "files", f"{element}.pak"),
                        patcher_path.joinpath("MP3Update", f"{element}.hdiff"),
                        Path(extract_path).joinpath("DATA", "files", f"{element}.pak"),
                    ],
                    check=True,
                )

        # path to where the paks are placed to be randomized
        paks_path = tempfile.mkdtemp()
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
        # copy files listed above to paks_path
        progress_update("Copying Paks...", 0.5)
        for name in randomize_elements:
            shutil.copy(Path(extract_path).joinpath("DATA", "files", name), Path(paks_path).joinpath(name))

        # randomize paks
        progress_update("Randomizing Paks...", 0.6)
        starting_items = patch_data["starting_items"].split(" ")
        starting_location = patch_data["starting_location"].split(" ")
        subprocess.run(
            [
                patcher_path.joinpath("MP3Randomizer.exe"),
                "--input-path",
                paks_path + os.sep,
                "--output-path",
                str(Path(extract_path).joinpath("DATA", "files")) + os.sep,
                "--layout",
                patch_data["seed"],
                "--starting-items",
                starting_items[0],
                starting_items[1],
                "--starting-location",
                starting_location[0],
                starting_location[1],
                starting_location[2],
                "--random-door-colors" if patch_data["random_door_colors"] else "",
                "--random-welding-colors" if patch_data["random_welding_colors"] else "",
                "--hyper-hints",  # These are forced on because not having them is an active detriment
                "--fast-flying",  # ''
                "--require-launcher" if patch_data["missile_required_mains"] else "",
                "--require-ship-missile" if patch_data["ship_missile_required_mains"] else "",
                "--phaaze-skip" if patch_data["phaaze_skip"] else "",
            ],
            check=True,
        )

        # create iso/wbfs
        progress_update(
            "Exporting to ISO..."
            if export_params.output_format == CorruptionOutputFormats.ISO
            else "Exporting to WBFS...",
            0.7,
        )
        subprocess.run(
            [
                patcher_path.joinpath("wit", "bin", "wit.exe"),
                "COPY",
                "-I" if export_params.output_format == CorruptionOutputFormats.ISO else "-B",
                "-z",
                "--trunc",
                "--auto-split",
                "--overwrite",
                Path(extract_path).joinpath("DATA"),
                export_params.output_path,
            ],
            check=True,
        )
        # clean up all extracted files
        shutil.rmtree(extract_path)
        shutil.rmtree(paks_path)
