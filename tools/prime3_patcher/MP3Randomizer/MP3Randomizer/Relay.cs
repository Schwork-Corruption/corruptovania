using System.Collections.Generic;

namespace MP3Randomizer;

public class Relay
{
	public static ScriptObject create_relay(byte[] id, byte[] position, Connection[] the_connections)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("SRLY", id, the_connections);
		uint[] relay_subproperties = get_relay_subproperties();
		Dictionary<uint, PropertyValue> subproperty_values = new Dictionary<uint, PropertyValue>();
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(relay_subproperties, subproperty_values);
		return scriptObject;
	}

	public static uint[] get_relay_subproperties()
	{
		return ScriptTypeData.get_all_types()["SRLY"].properties;
	}
}
