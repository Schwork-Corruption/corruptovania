namespace MP3Randomizer;

public class OlympusPatches
{
	public static void add_olympus_teleporter_patch(Patches patches)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 15628730931753443250uL }, new string[1] { "TEL1" }, new uint[1] { 2u }, new uint[1] { 797u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(new byte[8] { 1, 209, 81, 76, 25, 165, 250, 17 })) }));
	}
}
