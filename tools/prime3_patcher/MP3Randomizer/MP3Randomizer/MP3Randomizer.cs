using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MP3Randomizer;

public class MP3Randomizer
{
	public static int Main(string[] args)
	{
		Configuration configuration = Configuration.get_configuration(args);
		ItemName[] array = MP3Permalink.decode_permalink(configuration.encoded_permalink);
		for (int i = 0; i < array.Length; i++)
		{
			if (configuration.require_launcher && array[i] == ItemName.MissileExpansion)
			{
				array[i] = ItemName.MainRequiredMissileExpansion;
			}
			else if (configuration.require_ship_missile && array[i] == ItemName.ShipMissileExpansion)
			{
				array[i] = ItemName.MainRequiredShipMissileExpansion;
			}
			else if (configuration.require_launcher && array[i] == ItemName.MissileLauncher)
			{
				array[i] = ItemName.ConverterMissileLauncher;
			}
			else if (configuration.require_ship_missile && array[i] == ItemName.ShipMissile)
			{
				array[i] = ItemName.ConverterShipMissile;
			}
		}
		string hyper_missile_planet = "an unknown location.";
		string hyper_grapple_planet = "an unknown location.";
		int num = Array.IndexOf(array, ItemName.HyperMissile);
		int num2 = Array.IndexOf(array, ItemName.HyperGrapple);
		if (num >= 0)
		{
			hyper_missile_planet = ((num <= 2) ? "Olympus" : ((num <= 10) ? "Norion" : ((num <= 16) ? "Valhalla" : ((num > 50 && num != 98) ? ((num > 74 && num != 97) ? "the Pirate Homeworld" : "Elysia") : "Bryyo"))));
		}
		if (num2 >= 0)
		{
			hyper_grapple_planet = ((num2 <= 2) ? "Olympus" : ((num2 <= 10) ? "Norion" : ((num2 <= 16) ? "Valhalla" : ((num2 > 50 && num2 != 98) ? ((num2 > 74 && num2 != 97) ? "the Pirate Homeworld" : "Elysia") : "Bryyo"))));
		}
		Dictionary<ulong, Resource> modified_resources = StringPatches.get_string_resources_to_modify(configuration.add_hyper_hints, hyper_missile_planet, hyper_grapple_planet);
		Random rng = new Random();
		bool is_intro_skipped = ((configuration.starting_location_type != StartingLocationType.Olympus) ? true : false);
		Patches patches = new Patches();
		MP3Inventory inventory = MP3Inventory.create_inventory(configuration.starting_items_type, configuration.starting_items_custom);
		patches.add_patches(rng, PickupLocations.get_pickup_locations(), FakePickupLocations.get_fake_pickup_locations(), array, inventory, StartingLocationId.get_starting_location(configuration.starting_location_type, configuration.starting_world, configuration.starting_area), is_intro_skipped, configuration.random_door_colors, configuration.random_welding_colors, configuration.add_fast_flying, configuration.phaaze_skip, configuration.require_launcher, configuration.require_ship_missile);
		string[] pak_filenames = new string[9] { "FrontEnd.pak", "Metroid1.pak", "Metroid3.pak", "Metroid4.pak", "Metroid5.pak", "Metroid7.pak", "Metroid8.pak", "Logbook.pak", "MiscData.pak" };
		string[] array2 = new string[10] { "Metroid1.pak", "Metroid3.pak", "Metroid4.pak", "Metroid5.pak", "Metroid6.pak", "Metroid7.pak", "Metroid8.pak", "FrontEnd.pak", "UniverseArea.pak", "Worlds.pak" };
		string[] source = new string[1] { "Metroid8.pak" };
		Dictionary<ulong, Resource> gathered_dependencies = PAK.gather_resources(configuration.input_path, pak_filenames, patches, modified_resources);
		string[] array3 = array2;
		foreach (string text in array3)
		{
			bool clear_pak = (source.Contains(text) ? true : false);
			uint starting_area_index = 1u;
			if (text == "UniverseArea.pak")
			{
				starting_area_index = 0u;
			}
			PAK.modify_pak(Path.Combine(configuration.input_path, text), Path.Combine(configuration.output_path, text), gathered_dependencies, modified_resources, patches, starting_area_index, Version.MP3, clear_pak);
		}
		NTWK.modify_ntwk(Path.Combine(configuration.input_path, "Standard.ntwk"), Path.Combine(configuration.output_path, "Standard.ntwk"));
		return 0;
	}
}
