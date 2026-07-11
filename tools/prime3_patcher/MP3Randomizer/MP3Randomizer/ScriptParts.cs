using System;
using System.Collections.Generic;

namespace MP3Randomizer;

public class ScriptParts
{
	public static void handle_subproperty(List<byte> script_object, uint subproperty_id, Dictionary<uint, PropertyValue> override_values)
	{
		Dictionary<uint, ScriptPart> all_parts = ScriptPartData.get_all_parts();
		if (!all_parts.ContainsKey(subproperty_id))
		{
			throw new ArgumentException("Don't have data for subproperty id: " + subproperty_id);
		}
		ScriptPart scriptPart = all_parts[subproperty_id];
		script_object.AddRange(scriptPart.identifier);
		if (override_values.ContainsKey(subproperty_id) && scriptPart.type == "property" && Conversion.b_to_u16(scriptPart.size) != override_values[subproperty_id].get_length())
		{
			scriptPart.size = Conversion.u32_to_4b(override_values[subproperty_id].get_length());
		}
		script_object.AddRange(scriptPart.size);
		if (scriptPart.type == "struct")
		{
			script_object.AddRange(Conversion.u16_to_2b((uint)scriptPart.subproperties.Length));
			uint[] subproperties = scriptPart.subproperties;
			foreach (uint subproperty_id2 in subproperties)
			{
				handle_subproperty(script_object, subproperty_id2, override_values);
			}
		}
		else
		{
			if (!(scriptPart.type == "property"))
			{
				throw new ArgumentException("Invalid ScriptPart type: " + scriptPart.type);
			}
			if (override_values.ContainsKey(subproperty_id))
			{
				script_object.AddRange(override_values[subproperty_id].get_value());
			}
			else
			{
				script_object.AddRange(scriptPart.default_value);
			}
		}
	}
}
