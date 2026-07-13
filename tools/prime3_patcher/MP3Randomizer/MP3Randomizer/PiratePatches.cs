namespace MP3Randomizer;

public class PiratePatches
{
	public static void add_proving_grounds_elevator_patch(Patches patches)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 3594029436312475339uL }, new string[0], new uint[1], new uint[1] { 469u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 65, 67, 84, 86 }, new BPropertyValue(new byte[1])) }));
		Connection[] the_connections = new Connection[1] { Connection.make_connection("ZERO", "ACTV", new byte[2] { 1, 213 }) };
		ScriptObject scriptObject = Timer.create_fast_timer(new byte[2] { 204, 192 }, new byte[36]
		{
			67, 36, 128, 0, 0, 0, 0, 0, 194, 112,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, the_connections);
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 3594029436312475339uL }, new uint[1] { 15u }, new ScriptObject[1] { scriptObject }));
		Connection[] the_connections2 = new Connection[1] { Connection.make_connection("RLAY", "DCTV", new byte[2] { 3, 1 }) };
		ScriptObject scriptObject2 = Relay.create_relay(new byte[2] { 204, 192 }, new byte[36]
		{
			67, 36, 129, 0, 0, 0, 0, 0, 194, 112,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, the_connections2);
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 3594029436312475339uL }, new string[0], new uint[1] { 2u }, new uint[1] { 697u }, new Connection[1] { Connection.make_connection("ZERO", "ACTN", 52416) }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 3594029436312475339uL }, new uint[1] { 2u }, new ScriptObject[1] { scriptObject2 }));
	}

	public static void add_craneyard_item_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(1184305208322576857uL, 4u, new uint[2] { 2u, 4u }, new uint[1] { 3u }));
	}

	public static void add_command_station_xray_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(4037904934597342930uL, 6u, new uint[3] { 10u, 13u, 20u }, new uint[2] { 2u, 6u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3558406334082684652uL }, new string[0], new uint[1], new uint[5] { 998u, 8u, 28u, 1400u, 1399u }));
	}

	public static void add_proving_grounds_lift_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(1184305208322576857uL, 10u, new uint[1] { 6u }, new uint[2] { 2u, 4u }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 17474188290326019383uL }, new uint[1], new ScriptObject[1] { Timer.create_fast_timer(new byte[2] { 4, 0 }, new byte[36]
		{
			67, 62, 0, 0, 65, 160, 0, 0, 195, 12,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 64, 0, 0, 0, 64, 0,
			0, 0, 64, 0, 0, 0
		}, new Connection[6]
		{
			Connection.make_connection("ZERO", "ACTV", new byte[2] { 1, 82 }),
			Connection.make_connection("ZERO", "ACTV", new byte[2] { 0, 20 }),
			Connection.make_connection("ZERO", "ACTV", new byte[2] { 0, 90 }),
			Connection.make_connection("ZERO", "ACTN", new byte[2] { 0, 87 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 28 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 118 })
		}) }));
	}

	public static void add_demolition_patch(Patches patches)
	{
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 8444926274755356434uL }, new uint[1] { 3u }, new ScriptObject[1] { Timer.create_fast_timer(new byte[2] { 6, 0 }, new byte[36]
		{
			67, 62, 0, 0, 65, 160, 0, 0, 195, 12,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 64, 0, 0, 0, 64, 0,
			0, 0, 64, 0, 0, 0
		}, new Connection[51]
		{
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 243 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 247 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 250 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 203 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 172 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 171 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 214 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 181 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 184 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 251 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 200 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 213 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 186 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 223 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 0, 245 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 14 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 16 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 209 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 211 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 139 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 147 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 155 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 157 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 217 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 225 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 159 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 162 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 170 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 171 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 189 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 190 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 233 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 234 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 194 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 199 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 240 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 246 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 207 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 142 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 150 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 221 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 160 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 113 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 104 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 99 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 42 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 40 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 43 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 3, 41 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 2, 252 }),
			Connection.make_connection("ZERO", "DCTV", new byte[2] { 1, 249 })
		}) }));
	}

	public static void add_main_cavern_terminal_patch(Patches patches)
	{
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3558406334082684652uL }, new string[0], new uint[0], new uint[2] { 1404u, 1402u }));
	}

	public static void add_processing_access_roof_patch(Patches patches)
	{
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 11685491285383767107uL }, new string[0], new uint[0], new uint[1] { 421u }, new Connection[1] { Connection.make_connection("ACTV", "ACTV", 70) }));
	}

	public static void add_airshaft_layer_change_patch(Patches patches)
	{
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3594029436312475339uL }, new string[1] { "SLCT" }, new uint[1], new uint[2] { 811u, 812u }));
	}
}
