from __future__ import annotations

from typing import TYPE_CHECKING

from randovania.exporter.hints import guaranteed_item_hint
from randovania.game.game_enum import RandovaniaGame
from randovania.game_description import default_database
from randovania.game_description.hint import HintDarkTemple
from randovania.games.prime2.patcher import echoes_items

if TYPE_CHECKING:
    from randovania.game_description.game_patches import GamePatches
    from randovania.games.prime2.exporter.hint_namer import EchoesHintNamer


def create_temple_key_hint(
    all_patches: dict[int, GamePatches],
    player_index: int,
    temple: HintDarkTemple,
    namer: EchoesHintNamer,
    with_color: bool,
) -> str:
    """
    Creates the text for .
    :param all_patches:
    :param player_index:
    :param temple:
    :param namer:
    :param with_color:
    :return:
    """
    all_region_names = {}

    _TEMPLE_NAMES = ["Dark Agon Temple", "Dark Torvus Temple", "Hive Temple"]
    temple_index = [HintDarkTemple.AGON_WASTES, HintDarkTemple.TORVUS_BOG, HintDarkTemple.SANCTUARY_FORTRESS].index(
        temple
    )

    db = default_database.resource_database_for(RandovaniaGame.METROID_PRIME_ECHOES)
    items = [db.get_item(index) for index in echoes_items.DARK_TEMPLE_KEY_ITEMS[temple_index]]

    locations_for_items = guaranteed_item_hint.find_locations_that_gives_items(items, all_patches, player_index)

    for options in locations_for_items.values():
        for player, location in options:
            all_region_names[namer.format_region(location, with_color=False)] = (player, location)
            break

    temple_name = namer.format_temple_name(_TEMPLE_NAMES[temple_index], with_color=with_color)
    names_sorted = [
        namer.format_region(location, with_color=with_color)
        for name, (_, location) in sorted(all_region_names.items(), key=lambda it: it[0])
    ]
    if len(names_sorted) == 0:
        return f"The keys to {temple_name} are nowhere to be found."
    elif len(names_sorted) == 1:
        return f"The keys to {temple_name} can all be found in {names_sorted[0]}."
    else:
        last = names_sorted.pop()
        front = ", ".join(names_sorted)
        return f"The keys to {temple_name} can be found in {front} and {last}."
