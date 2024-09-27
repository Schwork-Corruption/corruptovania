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


class CorruptionOutputFormats(Enum):
    WBFS = "wbfs"
    ISO = "iso"


class CorruptionGameExporter(GameExporter):
    _busy: bool = False

    @property
    def is_busy(self) -> bool:
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
        patcher_path = randovania.get_data_path().joinpath("gollop_mp3_patcher")
        extract_path = tempfile.mkdtemp()
        paks_path = tempfile.mkdtemp()

        # Extract Iso to Temp
        progress_update("Extracting ISO...", 0.0)
        subprocess.run(
            [patcher_path.joinpath("nodtool", "nodtool.exe"), "extract", export_params.input_path, extract_path],
            check=True,
        )
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
        for name in randomize_elements:
            shutil.copy(Path(extract_path).joinpath("DATA", "files", name), Path(paks_path).joinpath(name))

        # remove attract videos
        dummy_attracts = ["attract01.thp", "Attract02.thp"]
        for name in dummy_attracts:
            shutil.copy(
                Path(patcher_path).joinpath("dummy_attract", name),
                Path(extract_path).joinpath("DATA", "files", "Video", "FrontEnd", name),
            )

        # randomize paks
        progress_update("Randomizing Paks...", 0.2)
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
                "--hyper-hints",
                "--fast-flying",
                "--require-launcher" if patch_data["missile_required_mains"] else "",
                "--require-ship-missile" if patch_data["ship_missile_required_mains"] else "",
            ],
            check=True,
        )
        # --input-path "%input_path%"
        # --output-path "%output_path%"
        # --layout %seed%
        # --starting-items %starting_items%
        # --starting-location %starting_location%
        # %random_door_colors%
        # %random_welding_colors%
        # %hyper_hints%
        # %fast_flying%
        # %phaaze_skip%
        # %require_launcher%
        # %require_ship_missile%

        # create iso/wbfs
        progress_update("Converting to ISO...", 0.6)
        subprocess.run(
            [patcher_path.joinpath("nodtool", "nodtool.exe"), "makewii", extract_path, export_params.output_path],
            check=True,
        )
        shutil.rmtree(extract_path)
        shutil.rmtree(paks_path)
