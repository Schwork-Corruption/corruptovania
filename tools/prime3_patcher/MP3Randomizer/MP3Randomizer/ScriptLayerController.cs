using System.Collections.Generic;

namespace MP3Randomizer;

public class ScriptLayerController
{
	public static ScriptObject create_script_layer_controller(byte[] id, byte[] position, Connection[] the_connections, byte[] internal_id, int id_part_1, int id_part_2, int id_part_3, int id_part_4)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("SLCT", id, the_connections);
		uint[] script_layer_controller_subproperties = get_script_layer_controller_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		List<byte> list = new List<byte>();
		list.AddRange(internal_id);
		list.AddRange(Conversion.i32_to_4b(id_part_1));
		list.AddRange(Conversion.i32_to_4b(id_part_2));
		list.AddRange(Conversion.i32_to_4b(id_part_3));
		list.AddRange(Conversion.i32_to_4b(id_part_4));
		dictionary[2185885383u] = new BPropertyValue(list.ToArray());
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(script_layer_controller_subproperties, dictionary);
		return scriptObject;
	}

	public static uint[] get_script_layer_controller_subproperties()
	{
		return ScriptTypeData.get_all_types()["SLCT"].properties;
	}
}
