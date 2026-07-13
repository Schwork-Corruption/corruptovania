using System.Collections.Generic;

namespace MP3Randomizer;

public class SpecialFunction
{
	public static ScriptObject create_inventory_giver(byte[] id, byte[] position, Connection[] the_connections, byte[] item_to_give)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("SPFN", id, the_connections);
		uint[] special_function_subproperties = get_special_function_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		dictionary[3098529569u] = new BPropertyValue(new byte[4] { 147, 73, 197, 109 });
		dictionary[3045152587u] = new BPropertyValue(new byte[4] { 0, 0, 0, 1 });
		dictionary[1067541692u] = new BPropertyValue(item_to_give);
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(special_function_subproperties, dictionary);
		return scriptObject;
	}

	public static ScriptObject create_inventory_taker(byte[] id, byte[] position, Connection[] the_connections, byte[] item_to_give)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("SPFN", id, the_connections);
		uint[] special_function_subproperties = get_special_function_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		dictionary[3098529569u] = new BPropertyValue(new byte[4] { 147, 73, 197, 109 });
		dictionary[3045152587u] = new BPropertyValue(new byte[4] { 255, 255, 255, 255 });
		dictionary[1067541692u] = new BPropertyValue(item_to_give);
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(special_function_subproperties, dictionary);
		return scriptObject;
	}

	public static ScriptObject create_main_inventory_giver(byte[] id, byte[] position, Connection[] the_connections, byte[] item_to_give)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("SPFN", id, the_connections);
		uint[] special_function_subproperties = get_special_function_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		dictionary[3098529569u] = new BPropertyValue(new byte[4] { 105, 138, 171, 26 });
		dictionary[3045152587u] = new BPropertyValue(new byte[4] { 0, 0, 0, 1 });
		dictionary[1067541692u] = new BPropertyValue(item_to_give);
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(special_function_subproperties, dictionary);
		return scriptObject;
	}

	public static ScriptObject create_main_inventory_taker(byte[] id, byte[] position, Connection[] the_connections, byte[] item_to_give)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("SPFN", id, the_connections);
		uint[] special_function_subproperties = get_special_function_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		dictionary[3098529569u] = new BPropertyValue(new byte[4] { 105, 138, 171, 26 });
		dictionary[3045152587u] = new BPropertyValue(new byte[4] { 255, 255, 255, 255 });
		dictionary[1067541692u] = new BPropertyValue(item_to_give);
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(special_function_subproperties, dictionary);
		return scriptObject;
	}

	public static uint[] get_special_function_subproperties()
	{
		return ScriptTypeData.get_all_types()["SPFN"].properties;
	}
}
