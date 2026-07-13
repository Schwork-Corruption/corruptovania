namespace MP3Randomizer;

public class FrontEndPatches
{
	public static void patch_attract_videos(Patches patches)
	{
		patches.connection_deletion_patches.Add(ScriptConnectionDeletionPatch.import(new ulong[1] { 15355308818766275996uL }, new string[1] { "TIMR" }, new uint[1], new uint[1] { 13u }, new string[0], new string[0], new uint[0]));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15355308818766275996uL }, new string[0], new uint[1], new uint[2] { 17u, 39u }));
		patches.connection_deletion_patches.Add(ScriptConnectionDeletionPatch.import(new ulong[1] { 15355308818766275996uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 27u }, new string[0], new string[1] { "LOAD" }, new uint[0]));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 15355308818766275996uL }, new string[0], new uint[1], new uint[1] { 27u }, new Connection[1] { Connection.make_connection("RLAY", "INCR", 19) }));
	}
}
