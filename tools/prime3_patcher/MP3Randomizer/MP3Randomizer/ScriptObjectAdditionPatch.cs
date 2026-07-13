namespace MP3Randomizer;

public class ScriptObjectAdditionPatch
{
	public ulong[] mrea_ids;

	public uint[] layer_indexes;

	public ScriptObject[] script_objects;

	public static ScriptObjectAdditionPatch import(ulong[] mrea_ids, uint[] layer_indexes, ScriptObject[] script_objects)
	{
		return new ScriptObjectAdditionPatch
		{
			mrea_ids = mrea_ids,
			layer_indexes = layer_indexes,
			script_objects = script_objects
		};
	}
}
