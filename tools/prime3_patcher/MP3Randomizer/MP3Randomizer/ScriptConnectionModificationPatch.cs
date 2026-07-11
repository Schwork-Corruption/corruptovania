using System.Linq;

namespace MP3Randomizer;

public class ScriptConnectionModificationPatch
{
	public ulong[] mrea_ids;

	public string[] script_types;

	public uint[] layer_indexes;

	public uint[] source_object_ids;

	public string[] states;

	public string[] messages;

	public uint[] target_ids;

	public string new_state;

	public string new_message;

	public uint[] new_target;

	public static ScriptConnectionModificationPatch import(ulong[] mrea_ids, string[] script_types, uint[] layer_indexes, uint[] source_object_ids, string[] states, string[] messages, uint[] target_ids, string new_state, string new_message, uint[] new_target)
	{
		return new ScriptConnectionModificationPatch
		{
			mrea_ids = mrea_ids,
			script_types = script_types,
			layer_indexes = layer_indexes,
			source_object_ids = source_object_ids,
			states = states,
			messages = messages,
			target_ids = target_ids,
			new_state = new_state,
			new_message = new_message,
			new_target = new_target
		};
	}

	public bool could_apply_patch(ScriptObject script_object)
	{
		if ((script_types.Length == 0 || script_types.Contains(script_object.type)) && (source_object_ids.Length == 0 || source_object_ids.Contains(script_object.id)))
		{
			return true;
		}
		return false;
	}

	public bool should_apply_patch(Connection connection)
	{
		if ((states.Length == 0 || states.Contains(connection.state)) && (messages.Length == 0 || messages.Contains(connection.message)) && (target_ids.Length == 0 || target_ids.Contains(connection.target)))
		{
			return true;
		}
		return false;
	}

	public void apply_patch(Connection connection)
	{
		if (new_state.Length != 4)
		{
			connection.state = new_state;
		}
		if (new_message.Length != 4)
		{
			connection.message = new_message;
		}
		if (new_target.Length != 0)
		{
			connection.target = new_target[0];
		}
	}
}
