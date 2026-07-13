using System.Collections.Generic;

namespace MP3Randomizer;

public class Timer
{
	public static ScriptObject create_fast_timer(byte[] id, byte[] position, Connection[] the_connections)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("TIMR", id, the_connections);
		uint[] timer_subproperties = get_timer_subproperties();
		Dictionary<uint, PropertyValue> subproperty_values = new Dictionary<uint, PropertyValue>();
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(timer_subproperties, subproperty_values);
		return scriptObject;
	}

	public static uint[] get_timer_subproperties()
	{
		return ScriptTypeData.get_all_types()["TIMR"].properties;
	}
}
