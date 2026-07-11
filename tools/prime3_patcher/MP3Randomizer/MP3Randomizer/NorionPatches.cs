namespace MP3Randomizer;

public class NorionPatches
{
	public static void add_control_tower_norion_layer_change_patches(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 1u, new uint[0], new uint[1] { 3u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 2u, new uint[2] { 12u, 17u }, new uint[4] { 3u, 7u, 10u, 13u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 3u, new uint[1] { 7u }, new uint[2] { 4u, 6u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 4u, new uint[1] { 12u }, new uint[5] { 5u, 6u, 8u, 9u, 10u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 6u, new uint[0], new uint[3] { 4u, 5u, 7u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 7u, new uint[1] { 4u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 8u, new uint[1] { 6u }, new uint[3] { 2u, 3u, 4u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 9u, new uint[1] { 12u }, new uint[5] { 5u, 7u, 9u, 10u, 11u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 12u, new uint[1] { 12u }, new uint[2] { 7u, 13u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 13u, new uint[2] { 10u, 24u }, new uint[4] { 5u, 11u, 15u, 16u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 14u, new uint[1] { 10u }, new uint[3] { 5u, 6u, 9u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 17u, new uint[3] { 4u, 18u, 23u }, new uint[5] { 5u, 11u, 12u, 16u, 21u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 19u, new uint[0], new uint[4] { 5u, 6u, 7u, 8u }));
	}

	public static void add_post_norion_invasion_patches(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 2u, new uint[1] { 16u }, new uint[3] { 2u, 8u, 9u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 17u, new uint[1] { 10u }, new uint[1] { 9u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 13u, new uint[1] { 24u }, new uint[3] { 4u, 5u, 21u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 14u, new uint[0], new uint[2] { 2u, 9u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 4u, new uint[0], new uint[1] { 2u }));
		patches.layer_clear_patches.Add(LayerClearPatch.import(new ulong[1] { 10152623521318090708uL }, new uint[3] { 7u, 8u, 9u }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 6692819360230093549uL }, new uint[1], new ScriptObject[1] { Timer.create_fast_timer(new byte[2] { 17, 17 }, new byte[36]
		{
			67, 32, 0, 0, 0, 0, 0, 0, 67, 250,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 64, 0, 0, 0, 64, 0,
			0, 0, 64, 0, 0, 0
		}, new Connection[2]
		{
			Connection.make_connection("ZERO", "ACTV", new byte[2] { 7, 119 }),
			Connection.make_connection("ZERO", "ACTV", new byte[2] { 6, 138 })
		}) }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 9u, new uint[0], new uint[1] { 4u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 12u, new uint[0], new uint[3] { 2u, 3u, 13u }));
	}

	public static void add_docking_hub_alpha_tutorial_patch(Patches patches)
	{
		patches.layer_clear_patches.Add(LayerClearPatch.import(new ulong[1] { 1594033074927626820uL }, new uint[1] { 11u }));
	}

	public static void add_cargo_dock_a_command_patch(Patches patches)
	{
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6692819360230093549uL }, new string[0], new uint[1], new uint[1] { 601u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 6692819360230093549uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 2505u }, new Connection[1] { Connection.make_connection("RLAY", "INCR", new byte[2] { 0, 148 }) }));
	}

	public static void add_norion_elevator_patch(Patches patches)
	{
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1594033074927626820uL }, new string[1] { "MRLY" }, new uint[1], new uint[1] { 963u }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 1594033074927626820uL }, new uint[1], new ScriptObject[1] { Timer.create_fast_timer(new byte[2] { 3, 195 }, new byte[36]
		{
			194, 72, 0, 0, 67, 145, 0, 0, 67, 200,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 64, 0, 0, 0, 64, 0,
			0, 0, 64, 0, 0, 0
		}, new Connection[4]
		{
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 4, 5 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 243 }),
			Connection.make_connection("ZERO", "ACTN", new byte[2] { 4, 49 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 231 })
		}) }));
	}

	public static void add_cargo_hub_floater_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 17u, new uint[0], new uint[1] { 13u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3044064450317642212uL }, new string[0], new uint[1], new uint[1] { 167u }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 3044064450317642212uL }, new uint[1], new ScriptObject[1] { Timer.create_fast_timer(new byte[2] { 0, 167 }, new byte[36]
		{
			194, 72, 0, 0, 67, 145, 0, 0, 67, 200,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 64, 0, 0, 0, 64, 0,
			0, 0, 64, 0, 0, 0
		}, new Connection[3]
		{
			Connection.make_connection("ZERO", "INCR", new byte[2] { 7, 30 }),
			Connection.make_connection("ZERO", "FADI", new byte[2] { 0, 159 }),
			Connection.make_connection("ZERO", "FADO", new byte[2] { 4, 18 })
		}) }));
	}
}
