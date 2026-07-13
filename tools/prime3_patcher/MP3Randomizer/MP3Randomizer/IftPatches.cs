namespace MP3Randomizer;

public class IftPatches
{
	public static void add_ift_patches(Patches patches)
	{
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2349002151496990705uL }, new string[0], new uint[1] { 8u }, new uint[2] { 632u, 638u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 10553270987934706862uL }, new string[0], new uint[1], new uint[2] { 190u, 205u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18221971457754325372uL }, new string[0], new uint[1], new uint[2] { 50u, 51u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 201801993056581673uL }, new string[0], new uint[1] { 4u }, new uint[1] { 405u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8195940946934839837uL }, new string[0], new uint[1] { 4u }, new uint[2] { 294u, 464u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 265878788849725085uL }, new string[0], new uint[1], new uint[6] { 815u, 941u, 942u, 816u, 817u, 818u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18200553231954089224uL }, new string[0], new uint[1], new uint[1] { 469u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18200553231954089224uL }, new string[0], new uint[1] { 6u }, new uint[3] { 473u, 475u, 476u }));
		patches.layer_clear_patches.Add(LayerClearPatch.import(new ulong[1] { 3066396911819856814uL }, new uint[2] { 9u, 12u }));
		patches.layer_clear_patches.Add(LayerClearPatch.import(new ulong[1] { 9934831212540578712uL }, new uint[1] { 4u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4196997332781103286uL }, new string[0], new uint[1] { 5u }, new uint[1] { 468u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6613311822671481119uL }, new string[0], new uint[1], new uint[2] { 172u, 1211u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17919508762406024111uL }, new string[0], new uint[0], new uint[3] { 282u, 74u, 497u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1808913861159744919uL }, new string[0], new uint[1], new uint[1] { 878u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 5682718801820042955uL }, new string[0], new uint[1] { 4u }, new uint[1] { 121u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3594029436312475339uL }, new string[0], new uint[1], new uint[4] { 778u, 775u, 739u, 776u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13589229454537797972uL }, new string[0], new uint[1], new uint[1] { 566u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 5604040344596242484uL }, new string[0], new uint[1] { 2u }, new uint[1] { 89u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 7293006450314500398uL }, new string[0], new uint[1] { 3u }, new uint[1] { 270u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4133901881028310574uL }, new string[0], new uint[1] { 6u }, new uint[1] { 1175u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4133901881028310574uL }, new string[0], new uint[1] { 12u }, new uint[1] { 1177u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3166066018495772067uL }, new string[0], new uint[1], new uint[1] { 789u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 14006603351279167667uL }, new string[0], new uint[1] { 11u }, new uint[1] { 1069u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18200553231954089224uL }, new string[1] { "SPFN" }, new uint[1], new uint[2] { 470u, 471u }));
	}
}
