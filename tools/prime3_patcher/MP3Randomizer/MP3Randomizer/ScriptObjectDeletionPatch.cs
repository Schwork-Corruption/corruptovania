using System.Linq;

namespace MP3Randomizer;

public class ScriptObjectDeletionPatch
{
	public ulong[] mrea_ids;

	public string[] script_types;

	public uint[] layer_indexes;

	public uint[] object_ids;

	public static ScriptObjectDeletionPatch import(ulong[] mrea_ids, string[] script_types, uint[] layer_indexes, uint[] object_ids)
	{
		return new ScriptObjectDeletionPatch
		{
			mrea_ids = mrea_ids,
			script_types = script_types,
			layer_indexes = layer_indexes,
			object_ids = object_ids
		};
	}

	public bool should_apply_patch(ScriptObject script_object)
	{
		if ((script_types.Length == 0 || script_types.Contains(script_object.type)) && (object_ids.Length == 0 || object_ids.Contains(script_object.id)))
		{
			return true;
		}
		return false;
	}
}
