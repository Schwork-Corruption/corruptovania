from __future__ import annotations

import dataclasses
from pathlib import Path
from typing import TYPE_CHECKING

from randovania.games.game import RandovaniaGame
from randovania.games.prime3.exporter.game_exporter import CorruptionGameExportParams, CorruptionOutputFormats
from randovania.games.prime3.exporter.options import CorruptionPerGameOptions
from randovania.games.prime3.gui.generated.corruption_game_export_dialog_ui import Ui_CorruptionGameExportDialog
from randovania.gui.dialog.game_export_dialog import (
    GameExportDialog,
    add_field_validation,
    output_file_validator,
    prompt_for_input_file,
    prompt_for_output_file,
    spoiler_path_for,
)
from randovania.gui.lib.multi_format_output_mixin import MultiFormatOutputMixin

if TYPE_CHECKING:
    from randovania.exporter.game_exporter import GameExportParams
    from randovania.interface_common.options import Options, PerGameOptions


class CorruptionGameExportDialog(GameExportDialog, Ui_CorruptionGameExportDialog, MultiFormatOutputMixin):
    """A window for asking the user for what is needed to export this specific game.

    The provided implementation assumes you need an ISO/ROM file, and produces a new ISO/ROM file."""

    @classmethod
    def game_enum(cls) -> RandovaniaGame:
        return RandovaniaGame.METROID_PRIME_CORRUPTION

    def __init__(self, options: Options, patch_data: dict, word_hash: str, spoiler: bool, games: list[RandovaniaGame]):
        super().__init__(options, patch_data, word_hash, spoiler, games)

        # support wbfs someday tm
        self.wbfs_radio.setVisible(False)
        self.iso_radio.setVisible(False)
        self.output_format_label.setVisible(False)
        self._selected_output_format = self.output_format
        per_game = options.options_for_game(self.game_enum())
        self._base_output_name = f"Corruption Randomizer - {word_hash}"

        assert isinstance(per_game, CorruptionPerGameOptions)

        # commands = patch_data["commands"]
        # common_qt_lib.set_clipboard(commands)
        # self.commands_label.setText(commands)

        # Input
        self.input_file_button.clicked.connect(self._on_input_file_button)

        # Output
        self.output_file_button.clicked.connect(self._on_output_file_button)

        # Output Format
        if per_game.output_format == CorruptionOutputFormats.WBFS and False:
            self.wbfs_radio.setChecked(True)
        else:
            self.iso_radio.setChecked(True)

        if per_game.input_path is not None:
            self.input_file_edit.setText(str(per_game.input_path))
        if per_game.output_path is not None:
            output_path = per_game.output_path.joinpath(f"{self._base_output_name}.{self._selected_output_format}")
            self.output_file_edit.setText(str(output_path))

        self.iso_radio.toggled.connect(self._on_update_output_format)
        self.wbfs_radio.toggled.connect(self._on_update_output_format)
        self._on_update_output_format()

        add_field_validation(
            accept_button=self.accept_button,
            fields={
                self.output_file_edit: lambda: output_file_validator(self.output_file),
            },
        )

    def update_per_game_options(self, per_game: PerGameOptions) -> PerGameOptions:
        assert isinstance(per_game, CorruptionPerGameOptions)
        return dataclasses.replace(
            per_game,
            input_path=Path(self.input_file),
            output_format=CorruptionOutputFormats(self.output_format),
            output_path=Path(self.output_file).parent,
        )

    @property
    def valid_input_file_types(self) -> list[str]:
        return ["iso"]

    @property
    def valid_output_file_types(self) -> list[str]:
        return ["iso"]

    # Getters
    @property
    def input_file(self) -> Path:
        return Path(self.input_file_edit.text())

    @property
    def output_file(self) -> Path:
        return Path(self.output_file_edit.text())

    @property
    def available_output_file_types(self) -> list[str]:
        return self.valid_output_file_types

    @property
    def auto_save_spoiler(self) -> bool:
        return self.auto_save_spoiler_check.isChecked()

    @property
    def output_format(self) -> str:
        if self.wbfs_radio.isChecked():
            return CorruptionOutputFormats.WBFS.value
        else:
            return CorruptionOutputFormats.ISO.value

    # Input file
    def _on_input_file_button(self) -> None:
        input_file = prompt_for_input_file(self, self.input_file_edit, self.valid_input_file_types)
        if input_file is not None:
            self.input_file_edit.setText(str(input_file.absolute()))

    # Output File
    def _on_output_file_button(self) -> None:
        output_file = prompt_for_output_file(
            self, self.available_output_file_types, self.default_output_name, self.output_file_edit
        )
        if output_file is not None:
            self.output_file_edit.setText(str(output_file))

    # Update
    def _on_update_output_format(self) -> None:
        self._selected_output_format = self.output_format

    def get_game_export_params(self) -> GameExportParams:
        spoiler_output = spoiler_path_for(self.auto_save_spoiler, self.output_file)

        return CorruptionGameExportParams(
            spoiler_output=spoiler_output,
            input_path=Path(self.input_file),
            output_path=Path(self.output_file),
            output_format=CorruptionOutputFormats(self.output_format),
        )
