namespace MP3Randomizer;

public class ElysiaPatches
{
	public static void add_broken_ship_patch(Patches patches)
	{
		ScriptObject scriptObject = ScriptLayerController.create_script_layer_controller(new byte[2] { 32, 0 }, new byte[36]
		{
			196, 122, 128, 0, 68, 187, 128, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 255, 137, 136, 43, 84, 47, 68, 102 }, 1696751433, 1863615562, -1916620194, 470698984);
		ScriptLayerController.create_script_layer_controller(new byte[2] { 32, 1 }, new byte[36]
		{
			196, 122, 128, 0, 68, 187, 160, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 255, 137, 136, 43, 84, 47, 68, 102 }, 284603822, 650331204, -1581495672, 569513855);
		Connection[] the_connections = new Connection[2]
		{
			Connection.make_connection("ZERO", "DECR", new byte[2] { 32, 0 }),
			Connection.make_connection("ZERO", "INCR", new byte[2] { 32, 1 })
		};
		ScriptObject scriptObject2 = Timer.create_fast_timer(new byte[2] { 32, 2 }, new byte[36]
		{
			196, 122, 128, 0, 68, 187, 192, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, the_connections);
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 4133901881028310574uL }, new uint[1], new ScriptObject[1] { scriptObject }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 4133901881028310574uL }, new uint[1] { 18u }, new ScriptObject[1] { scriptObject2 }));
	}

	public static void add_arrival_station_mbc_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(14087060452406742136uL, 4u, new uint[1] { 4u }, new uint[0]));
	}

	public static void add_skybridge_hera_mbc_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(14087060452406742136uL, 11u, new uint[1] { 5u }, new uint[0]));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 10733512082794532665uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 335u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "INCR", new byte[2] { 1, 153 }),
			Connection.make_connection("RLAY", "DECR", new byte[2] { 1, 151 })
		}));
	}

	public static void add_ballista_storage_patch(Patches patches)
	{
		patches.layer_clear_patches.Add(LayerClearPatch.import(new ulong[1] { 9955656508473190866uL }, new uint[2] { 4u, 6u }));
	}

	public static void add_main_docking_bay_command_visor_patch(Patches patches)
	{
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 4133901881028310574uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 146u }, new Connection[1] { Connection.make_connection("RLAY", "DCTV", new byte[2] { 5, 196 }) }));
	}

	public static void add_aurora_chamber_patches(Patches patches)
	{
		patches.connection_deletion_patches.Add(ScriptConnectionDeletionPatch.import(new ulong[1] { 3066396911819856814uL }, new string[1] { "SRLY" }, new uint[1] { 5u }, new uint[1] { 279u }, new string[0], new string[0], new uint[335]));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 3066396911819856814uL }, new string[1] { "SRLY" }, new uint[1], new uint[1] { 108u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "INCR", new byte[2] { 2, 179 }),
			Connection.make_connection("RLAY", "INCR", new byte[2] { 1, 79 })
		}));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9955656508473190866uL }, new string[0], new uint[1], new uint[3] { 310u, 771u, 602u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(14087060452406742136uL, 9u, new uint[3] { 2u, 3u, 4u }, new uint[0]));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3066396911819856814uL }, new string[0], new uint[1] { 4u }, new uint[1] { 1222u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 3066396911819856814uL }, new string[1] { "SRLY" }, new uint[1], new uint[1] { 1340u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "LOCK", new byte[2] { 0, 48 }),
			Connection.make_connection("RLAY", "LOCK", new byte[2] { 0, 51 })
		}));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 3066396911819856814uL }, new string[1] { "SRLY" }, new uint[1], new uint[1] { 232u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "ULCK", new byte[2] { 0, 48 }),
			Connection.make_connection("RLAY", "ULCK", new byte[2] { 0, 51 })
		}));
	}
}
