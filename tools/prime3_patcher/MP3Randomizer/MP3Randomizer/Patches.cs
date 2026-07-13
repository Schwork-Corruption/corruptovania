using System;
using System.Collections.Generic;
using System.Linq;

namespace MP3Randomizer;

public class Patches
{
	public List<LayerTogglePatch> layer_toggle_patches;

	public List<LayerClearPatch> layer_clear_patches;

	public List<ScriptObjectDeletionPatch> object_deletion_patches;

	public List<ScriptObjectAdditionPatch> object_addition_patches;

	public List<ScriptObjectModificationPatch> object_modification_patches;

	public List<ScriptConnectionDeletionPatch> connection_deletion_patches;

	public List<ScriptConnectionAdditionPatch> connection_addition_patches;

	public List<ScriptConnectionModificationPatch> connection_modification_patches;

	public Dictionary<ulong, List<Dependency>> dependency_patches;

	public Patches()
	{
		layer_toggle_patches = new List<LayerTogglePatch>();
		layer_clear_patches = new List<LayerClearPatch>();
		object_deletion_patches = new List<ScriptObjectDeletionPatch>();
		object_addition_patches = new List<ScriptObjectAdditionPatch>();
		object_modification_patches = new List<ScriptObjectModificationPatch>();
		connection_deletion_patches = new List<ScriptConnectionDeletionPatch>();
		connection_addition_patches = new List<ScriptConnectionAdditionPatch>();
		connection_modification_patches = new List<ScriptConnectionModificationPatch>();
		dependency_patches = new Dictionary<ulong, List<Dependency>>();
	}

	public LayerTogglePatch[] get_appropriate_mlvl_layer_toggle_patches(ulong resource_id)
	{
		List<LayerTogglePatch> list = new List<LayerTogglePatch>();
		foreach (LayerTogglePatch layer_toggle_patch in layer_toggle_patches)
		{
			if (resource_id == layer_toggle_patch.mlvl_id)
			{
				list.Add(layer_toggle_patch);
			}
		}
		return list.ToArray();
	}

	public bool has_mrea_patches(ulong mrea_id)
	{
		if (layer_clear_patches.Count <= 0 && object_deletion_patches.Count <= 0 && object_addition_patches.Count <= 0 && object_modification_patches.Count <= 0 && connection_deletion_patches.Count <= 0 && connection_addition_patches.Count <= 0 && connection_modification_patches.Count <= 0)
		{
			if (dependency_patches.ContainsKey(mrea_id))
			{
				return dependency_patches[mrea_id].Count >= 0;
			}
			return false;
		}
		return true;
	}

	public Patches get_patches_for_resource(ulong resource_id)
	{
		Patches patches = new Patches();
		foreach (LayerClearPatch layer_clear_patch in layer_clear_patches)
		{
			if (layer_clear_patch.mrea_ids.Length == 0 || layer_clear_patch.mrea_ids.Contains(resource_id))
			{
				patches.layer_clear_patches.Add(layer_clear_patch);
			}
		}
		foreach (ScriptObjectDeletionPatch object_deletion_patch in object_deletion_patches)
		{
			if (object_deletion_patch.mrea_ids.Length == 0 || object_deletion_patch.mrea_ids.Contains(resource_id))
			{
				patches.object_deletion_patches.Add(object_deletion_patch);
			}
		}
		foreach (ScriptObjectAdditionPatch object_addition_patch in object_addition_patches)
		{
			if (object_addition_patch.mrea_ids.Length == 0 || object_addition_patch.mrea_ids.Contains(resource_id))
			{
				patches.object_addition_patches.Add(object_addition_patch);
			}
		}
		foreach (ScriptObjectModificationPatch object_modification_patch in object_modification_patches)
		{
			if (object_modification_patch.mrea_ids.Length == 0 || object_modification_patch.mrea_ids.Contains(resource_id))
			{
				patches.object_modification_patches.Add(object_modification_patch);
			}
		}
		foreach (ScriptConnectionDeletionPatch connection_deletion_patch in connection_deletion_patches)
		{
			if (connection_deletion_patch.mrea_ids.Length == 0 || connection_deletion_patch.mrea_ids.Contains(resource_id))
			{
				patches.connection_deletion_patches.Add(connection_deletion_patch);
			}
		}
		foreach (ScriptConnectionAdditionPatch connection_addition_patch in connection_addition_patches)
		{
			if (connection_addition_patch.mrea_ids.Length == 0 || connection_addition_patch.mrea_ids.Contains(resource_id))
			{
				patches.connection_addition_patches.Add(connection_addition_patch);
			}
		}
		foreach (ScriptConnectionModificationPatch connection_modification_patch in connection_modification_patches)
		{
			if (connection_modification_patch.mrea_ids.Length == 0 || connection_modification_patch.mrea_ids.Contains(resource_id))
			{
				patches.connection_modification_patches.Add(connection_modification_patch);
			}
		}
		patches.dependency_patches = new Dictionary<ulong, List<Dependency>>();
		if (dependency_patches.ContainsKey(resource_id) && dependency_patches[resource_id].Count >= 0)
		{
			patches.dependency_patches[resource_id] = dependency_patches[resource_id];
		}
		return patches;
	}

	public Patches get_patches_for_layer(uint layer_index)
	{
		Patches patches = new Patches();
		foreach (LayerClearPatch layer_clear_patch in layer_clear_patches)
		{
			if (layer_clear_patch.layer_indexes.Length == 0 || layer_clear_patch.layer_indexes.Contains(layer_index))
			{
				patches.layer_clear_patches.Add(layer_clear_patch);
			}
		}
		foreach (ScriptObjectDeletionPatch object_deletion_patch in object_deletion_patches)
		{
			if (object_deletion_patch.layer_indexes.Length == 0 || object_deletion_patch.layer_indexes.Contains(layer_index))
			{
				patches.object_deletion_patches.Add(object_deletion_patch);
			}
		}
		foreach (ScriptObjectAdditionPatch object_addition_patch in object_addition_patches)
		{
			if (object_addition_patch.layer_indexes.Length == 0 || object_addition_patch.layer_indexes.Contains(layer_index))
			{
				patches.object_addition_patches.Add(object_addition_patch);
			}
		}
		foreach (ScriptObjectModificationPatch object_modification_patch in object_modification_patches)
		{
			if (object_modification_patch.layer_indexes.Length == 0 || object_modification_patch.layer_indexes.Contains(layer_index))
			{
				patches.object_modification_patches.Add(object_modification_patch);
			}
		}
		foreach (ScriptConnectionDeletionPatch connection_deletion_patch in connection_deletion_patches)
		{
			if (connection_deletion_patch.layer_indexes.Length == 0 || connection_deletion_patch.layer_indexes.Contains(layer_index))
			{
				patches.connection_deletion_patches.Add(connection_deletion_patch);
			}
		}
		foreach (ScriptConnectionAdditionPatch connection_addition_patch in connection_addition_patches)
		{
			if (connection_addition_patch.layer_indexes.Length == 0 || connection_addition_patch.layer_indexes.Contains(layer_index))
			{
				patches.connection_addition_patches.Add(connection_addition_patch);
			}
		}
		foreach (ScriptConnectionModificationPatch connection_modification_patch in connection_modification_patches)
		{
			if (connection_modification_patch.layer_indexes.Length == 0 || connection_modification_patch.layer_indexes.Contains(layer_index))
			{
				patches.connection_modification_patches.Add(connection_modification_patch);
			}
		}
		return patches;
	}

	public void apply_patches_to_layer(ScriptLayer script_layer, uint area_index, uint layer_index, ulong mrea_id)
	{
		if (layer_clear_patches.Count > 0)
		{
			script_layer.list_of_objects = new List<ScriptObject>();
		}
		for (int i = 0; i < script_layer.list_of_objects.Count; i++)
		{
			foreach (ScriptObjectDeletionPatch object_deletion_patch in object_deletion_patches)
			{
				if (object_deletion_patch.should_apply_patch(script_layer.list_of_objects[i]))
				{
					script_layer.list_of_objects.RemoveAt(i);
					i--;
					break;
				}
			}
		}
		foreach (ScriptObjectAdditionPatch object_addition_patch in object_addition_patches)
		{
			ScriptObject[] script_objects = object_addition_patch.script_objects;
			foreach (ScriptObject script_object in script_objects)
			{
				script_layer.add_object(script_object);
			}
		}
		for (int k = 0; k < script_layer.list_of_objects.Count; k++)
		{
			foreach (ScriptObjectModificationPatch object_modification_patch in object_modification_patches)
			{
				if (object_modification_patch.should_apply_patch(script_layer.list_of_objects[k]))
				{
					script_layer.list_of_objects[k].script_data = SimpleScriptDataModifier.modify_script_data(script_layer.list_of_objects[k].script_data, object_modification_patch.property_modifications, mrea_id);
				}
			}
		}
		for (int l = 0; l < script_layer.list_of_objects.Count; l++)
		{
			foreach (ScriptConnectionDeletionPatch connection_deletion_patch in connection_deletion_patches)
			{
				if (!connection_deletion_patch.could_apply_patch(script_layer.list_of_objects[l]))
				{
					continue;
				}
				for (int m = 0; m < script_layer.list_of_objects[l].connections.Count; m++)
				{
					if (connection_deletion_patch.should_apply_patch(script_layer.list_of_objects[l].connections[m]))
					{
						script_layer.list_of_objects[l].connections.RemoveAt(m);
						m--;
					}
				}
			}
		}
		for (int n = 0; n < script_layer.list_of_objects.Count; n++)
		{
			foreach (ScriptConnectionAdditionPatch connection_addition_patch in connection_addition_patches)
			{
				if (connection_addition_patch.should_apply_patch(script_layer.list_of_objects[n]))
				{
					Connection[] connections = connection_addition_patch.connections;
					foreach (Connection item in connections)
					{
						script_layer.list_of_objects[n].connections.Add(item);
					}
				}
			}
		}
		for (int num = 0; num < script_layer.list_of_objects.Count; num++)
		{
			foreach (ScriptConnectionModificationPatch connection_modification_patch in connection_modification_patches)
			{
				if (!connection_modification_patch.could_apply_patch(script_layer.list_of_objects[num]))
				{
					continue;
				}
				foreach (Connection connection in script_layer.list_of_objects[num].connections)
				{
					if (connection_modification_patch.should_apply_patch(connection))
					{
						connection_modification_patch.apply_patch(connection);
					}
				}
			}
		}
	}

	public void add_patches(Random rng, PickupLocation[] pickup_locations, FakePickup[] fake_pickup_locations, ItemName[] item_list, MP3Inventory inventory, StartingArea starting_area, bool is_intro_skipped, bool random_door_colors, bool random_welding_colors, bool add_fast_flying, bool phaaze_skip, bool require_launcher, bool require_ship_missile)
	{
		FrontEndPatches.patch_attract_videos(this);
		StartPatches.add_reveal_map_patch(this, starting_area.get_area_id());
		StartPatches.add_starting_items_patch(this, inventory, starting_area.get_area_id());
		StartPatches.add_starting_location_patch(this, starting_area);
		GeneralPatches.add_bombing_run_patches(this);
		GeneralPatches.add_ship_strike_patches(this);
		GeneralPatches.add_ship_grapple_patches(this);
		GeneralPatches.add_space_removal_patches(this);
		GeneralPatches.add_room_reveal_cutscene_patches(this);
		OlympusPatches.add_olympus_teleporter_patch(this);
		NorionPatches.add_norion_elevator_patch(this);
		NorionPatches.add_post_norion_invasion_patches(this);
		NorionPatches.add_cargo_hub_floater_patch(this);
		NorionPatches.add_cargo_dock_a_command_patch(this);
		NorionPatches.add_docking_hub_alpha_tutorial_patch(this);
		BryyoPatches.add_bryyo_temple_missile_patch(this);
		BryyoPatches.add_corrupted_pool_grapple_patch(this);
		BryyoPatches.add_grand_court_golem_patch(this);
		BryyoPatches.add_cliffside_airdock_command_patch(this);
		ElysiaPatches.add_ballista_storage_patch(this);
		ElysiaPatches.add_aurora_chamber_patches(this);
		ElysiaPatches.add_arrival_station_mbc_patch(this);
		ElysiaPatches.add_broken_ship_patch(this);
		ElysiaPatches.add_main_docking_bay_command_visor_patch(this);
		ElysiaPatches.add_skybridge_hera_mbc_patch(this);
		PiratePatches.add_craneyard_item_patch(this);
		PiratePatches.add_proving_grounds_lift_patch(this);
		PiratePatches.add_command_station_xray_patch(this);
		PiratePatches.add_proving_grounds_elevator_patch(this);
		PiratePatches.add_demolition_patch(this);
		PiratePatches.add_main_cavern_terminal_patch(this);
		PiratePatches.add_processing_access_roof_patch(this);
		PiratePatches.add_airshaft_layer_change_patch(this);
		if (is_intro_skipped)
		{
			NorionPatches.add_control_tower_norion_layer_change_patches(this);
		}
		if (add_fast_flying)
		{
			GeneralPatches.add_fast_flying_patches(this);
		}
		if (phaaze_skip)
		{
			GeneralPatches.add_phaaze_skip_patches(this);
		}
		IftPatches.add_ift_patches(this);
		CinematicSkipPatches.add_cinematic_skip_patches(this);
		Dictionary<ulong, Dependency[]> file_dependencies = MP3Dependencies.get_file_dependencies();
		PickupPatches.add_pickup_patches(this, pickup_locations, item_list, require_launcher, require_ship_missile, file_dependencies);
		PickupPatches.add_fake_pickup_patches(this, fake_pickup_locations, item_list, file_dependencies);
		PickupPatches.add_special_pickup_patches(this);
		if (random_door_colors)
		{
			CosmeticPatches.add_random_door_color_patch(this, rng);
		}
		if (random_welding_colors)
		{
			CosmeticPatches.add_context_welding_color_patch(this, rng);
		}
	}
}
