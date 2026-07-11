namespace MP3Randomizer;

public class BryyoPatches
{
	public static void add_bryyo_temple_missile_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11216541621678862008uL, 10u, new uint[2] { 8u, 9u }, new uint[0]));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13296637487518400273uL }, new string[0], new uint[1], new uint[2] { 689u, 712u }));
	}

	public static void add_grand_court_golem_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 11u, new uint[2] { 4u, 6u }, new uint[1] { 9u }));
	}

	public static void add_corrupted_pool_grapple_patch(Patches patches)
	{
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 4196997332781103286uL }, new uint[1], new ScriptObject[1] { Timer.create_fast_timer(new byte[2] { 4, 0 }, new byte[36]
		{
			66, 160, 0, 0, 194, 140, 0, 0, 193, 160,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 64, 0, 0, 0, 64, 0,
			0, 0, 64, 0, 0, 0
		}, new Connection[1] { Connection.make_connection("ZERO", "ACTN", new byte[2] { 2, 32 }) }) }));
	}

	public static void add_cliffside_airdock_command_patch(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 2u, new uint[1] { 3u }, new uint[1] { 13u }));
	}
}
