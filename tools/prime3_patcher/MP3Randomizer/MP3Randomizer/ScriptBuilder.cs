using System;
using System.Collections.Generic;

namespace MP3Randomizer;

public class ScriptBuilder
{
	public static ScriptObject deal_with_up_to_connections(string fourCC, byte[] id, Connection[] connections)
	{
		if (fourCC.Length != 4)
		{
			throw new ArgumentException("fourCC is not four characters long: " + fourCC);
		}
		ScriptObject scriptObject = new ScriptObject();
		scriptObject.type = fourCC;
		scriptObject.id = Conversion.b_to_u16(id);
		List<Connection> list = new List<Connection>();
		foreach (Connection item in connections)
		{
			list.Add(item);
		}
		scriptObject.connections = list;
		return scriptObject;
	}

	public static byte[] deal_with_subproperties(uint[] subproperty_id_list, Dictionary<uint, PropertyValue> subproperty_values)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u16_to_2b((uint)subproperty_id_list.Length));
		foreach (uint subproperty_id in subproperty_id_list)
		{
			ScriptParts.handle_subproperty(list, subproperty_id, subproperty_values);
		}
		list.InsertRange(0, Conversion.u16_to_2b((uint)list.Count));
		list.InsertRange(0, new byte[4] { 255, 255, 255, 255 });
		return list.ToArray();
	}
}
