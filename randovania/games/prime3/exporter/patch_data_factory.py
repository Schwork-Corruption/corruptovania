from __future__ import annotations

from randovania.exporter.patch_data_factory import PatchDataFactory
from randovania.game.game_enum import RandovaniaGame
from randovania.game_description.resources.pickup_index import PickupIndex
from randovania.games.prime3.layout.corruption_configuration import CorruptionConfiguration
from randovania.games.prime3.layout.corruption_cosmetic_patches import CorruptionCosmeticPatches, CorruptionSuit
from randovania.games.prime3.patcher import gollop_corruption_patcher


class CorruptionPatchDataFactory(PatchDataFactory):
    configuration: CorruptionConfiguration
    cosmetic_patches: CorruptionCosmeticPatches

    def game_enum(self) -> RandovaniaGame:
        return RandovaniaGame.METROID_PRIME_CORRUPTION

    def create_game_specific_data(self) -> dict:
        cosmetic = self.cosmetic_patches
        assert isinstance(cosmetic, CorruptionCosmeticPatches)
        configuration = self.configuration
        assert isinstance(configuration, CorruptionConfiguration)
        patches = self.patches
        game = self.game

        pickup_names = []
        for index in range(game.region_list.num_pickup_nodes):
            p_index = PickupIndex(index)
            if p_index in patches.pickup_assignment:
                name = patches.pickup_assignment[p_index].pickup.name
            else:
                name = "Missile Expansion"
            pickup_names.append(name)

        layout_string = gollop_corruption_patcher.layout_string_for_items(pickup_names)
        starting_location = patches.starting_location

        missile_required_mains = [
            ammo_state.requires_main_item
            for ammo_definition, ammo_state in self.configuration.ammo_pickup_configuration.pickups_state.items()
            if ammo_definition.name == "Missile Expansion"
        ][0]

        ship_missile_required_mains = [
            ammo_state.requires_main_item
            for ammo_definition, ammo_state in self.configuration.ammo_pickup_configuration.pickups_state.items()
            if ammo_definition.name == "Ship Missile Expansion"
        ][0]

        mp3_update = self.configuration.MP3Update
        phaaze_skip = self.configuration.teleporters.skip_final_bosses

        starting_items = patches.starting_resources()
        starting_items.add_resource_gain(
            [
                (
                    game.resource_database.get_item_by_name("Suit Type"),
                    cosmetic.player_suit.value,
                ),
            ]
        )

        player_suit_value = self.cosmetic_patches.player_suit.value
        suit_type_tuple = [
            (resource, quantity)
            for resource, quantity in starting_items.as_resource_gain()
            if resource.long_name == "Suit Type"
        ]
        if len(suit_type_tuple) > 0:
            suit_type_resource, suit_type_quantity = suit_type_tuple[0]
            if suit_type_quantity > player_suit_value and suit_type_quantity < CorruptionSuit.CORRUPTED_50.value:
                starting_items.add_resource_gain(
                    [
                        (suit_type_resource, CorruptionSuit.CORRUPTED_50.value - suit_type_quantity + 1),
                    ]
                )

        ship_grapple_tuple = [
            (resource, quantity)
            for resource, quantity in starting_items.as_resource_gain()
            if resource.long_name == "Ship Grapple"
        ]
        if len(ship_grapple_tuple) > 0:
            _, ship_grapple_quantity = ship_grapple_tuple[0]
            if ship_grapple_quantity > 0 and not mp3_update:
                raise ValueError("Ship Grapple is not a possible starting item without MP3Update enabled.")

        if configuration.start_with_corrupted_hypermode:
            hypermode_original = 0
        else:
            hypermode_original = 1

        starting_items_text = gollop_corruption_patcher.starting_items_for(starting_items, hypermode_original)
        starting_location_text = gollop_corruption_patcher.starting_location_for(
            game, starting_location.area_identifier
        )
        commands = "\n".join(
            [
                f'set seed="{layout_string}"',
                f'set "starting_items={starting_items_text}"',
                f'set "starting_location={starting_location_text}"',
                f'set "random_door_colors={str(cosmetic.random_door_colors).lower()}"',
                f'set "random_welding_colors={str(cosmetic.random_welding_colors).lower()}"',
            ]
        )

        return {
            "commands": commands,
            "seed": layout_string,
            "starting_items": starting_items_text,
            "starting_location": starting_location_text,
            "random_door_colors": cosmetic.random_door_colors,
            "random_welding_colors": cosmetic.random_welding_colors,
            "missile_required_mains": missile_required_mains,
            "ship_missile_required_mains": ship_missile_required_mains,
            "phaaze_skip": phaaze_skip,
            "mp3_update": mp3_update,
        }
