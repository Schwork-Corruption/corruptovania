using System.Collections.Generic;

namespace MP3Randomizer;

public class ControllerAction
{
	public static ScriptObject create_controller_action(byte[] id, byte[] position, Connection[] the_connections, byte[] controller_action_type)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("CNTA", id, the_connections);
		uint[] controller_action_subproperties = get_controller_action_subproperties();
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(controller_action_subproperties, new Dictionary<uint, PropertyValue> { [1099641890u] = new BPropertyValue(controller_action_type) });
		return scriptObject;
	}

	public static uint[] get_controller_action_subproperties()
	{
		return ScriptTypeData.get_all_types()["CNTA"].properties;
	}
}
