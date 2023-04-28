from PySide6 import QtCore

from randovania.games.prime3.gui.dialog.corruption_cosmetic_patches_dialog import CorruptionCosmeticPatchesDialog
from randovania.games.prime3.layout.corruption_cosmetic_patches import CorruptionCosmeticPatches, CorruptionSuit
from randovania.gui.lib.signal_handling import set_combo_with_value


def test_random_welding_colors(skip_qtbot):
    cosmetic_patches = CorruptionCosmeticPatches(random_welding_colors=False)

    dialog = CorruptionCosmeticPatchesDialog(None, cosmetic_patches)
    skip_qtbot.addWidget(dialog)

    skip_qtbot.mouseClick(dialog.random_welding_colors_check, QtCore.Qt.MouseButton.LeftButton)

    assert dialog.cosmetic_patches == CorruptionCosmeticPatches(random_welding_colors=True)


def test_player_suit(skip_qtbot):
    cosmetic_patches = CorruptionCosmeticPatches(player_suit=CorruptionSuit.CORRUPTED_25)

    dialog = CorruptionCosmeticPatchesDialog(None, cosmetic_patches)
    skip_qtbot.addWidget(dialog)

    set_combo_with_value(dialog.suit_combo, CorruptionSuit.PED)

    assert dialog.cosmetic_patches == CorruptionCosmeticPatches(player_suit=CorruptionSuit.PED)
