using System.Linq;

namespace MP3Randomizer;

public class ScriptConnectionAdditionPatch
{
	public ulong[] mrea_ids;

	public string[] script_types;

	public uint[] layer_indexes;

	public uint[] source_object_ids;

	public Connection[] connections;

	public static ScriptConnectionAdditionPatch import(ulong[] mrea_ids, string[] script_types, uint[] layer_indexes, uint[] source_object_ids, Connection[] connections)
	{
		return new ScriptConnectionAdditionPatch
		{
			mrea_ids = mrea_ids,
			script_types = script_types,
			layer_indexes = layer_indexes,
			source_object_ids = source_object_ids,
			connections = connections
		};
	}

	public bool should_apply_patch(ScriptObject script_object)
	{
		if ((script_types.Length == 0 || script_types.Contains(script_object.type)) && (source_object_ids.Length == 0 || source_object_ids.Contains(script_object.id)))
		{
			return true;
		}
		return false;
	}
}
