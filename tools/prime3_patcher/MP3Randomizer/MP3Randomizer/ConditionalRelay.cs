using System.Collections.Generic;

namespace MP3Randomizer;

public class ConditionalRelay
{
	public static ScriptObject create_progressive_conditional_relay(byte[] id, byte[] position, Connection[] the_connections, byte[] item_type)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("CRLY", id, the_connections);
		uint[] conditional_relay_subproperties = get_conditional_relay_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		List<byte[]> list = new List<byte[]>();
		list.Add(BinaryConstant.U32_ONE);
		list.Add(BinaryConstant.U32_ZERO);
		list.Add(BinaryConstant.U32_ZERO);
		list.Add(BinaryConstant.U32_ZERO);
		dictionary[3728621731u] = new RepeatPropertyValue(list);
		List<byte[]> list2 = new List<byte[]>();
		list2.Add(new byte[4] { 0, 0, 0, 2 });
		list2.Add(BinaryConstant.U32_ZERO);
		list2.Add(BinaryConstant.U32_ZERO);
		list2.Add(BinaryConstant.U32_ZERO);
		dictionary[1886557028u] = new RepeatPropertyValue(list2);
		List<byte[]> list3 = new List<byte[]>();
		list3.Add(item_type);
		list3.Add(new byte[4] { 251, 115, 242, 184 });
		list3.Add(new byte[4] { 251, 115, 242, 184 });
		list3.Add(new byte[4] { 251, 115, 242, 184 });
		dictionary[3551497586u] = new RepeatPropertyValue(list3);
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(conditional_relay_subproperties, dictionary);
		return scriptObject;
	}

	public static ScriptObject create_main_required_conditional_relay(byte[] id, byte[] position, Connection[] the_connections, byte[] item_type)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("CRLY", id, the_connections);
		uint[] conditional_relay_subproperties = get_conditional_relay_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		List<byte[]> list = new List<byte[]>();
		list.Add(BinaryConstant.U32_ONE);
		list.Add(BinaryConstant.U32_ZERO);
		list.Add(BinaryConstant.U32_ZERO);
		list.Add(BinaryConstant.U32_ZERO);
		dictionary[3728621731u] = new RepeatPropertyValue(list);
		List<byte[]> list2 = new List<byte[]>();
		list2.Add(new byte[4] { 0, 0, 0, 2 });
		list2.Add(BinaryConstant.U32_ZERO);
		list2.Add(BinaryConstant.U32_ZERO);
		list2.Add(BinaryConstant.U32_ZERO);
		dictionary[1886557028u] = new RepeatPropertyValue(list2);
		List<byte[]> list3 = new List<byte[]>();
		list3.Add(item_type);
		list3.Add(new byte[4] { 251, 115, 242, 184 });
		list3.Add(new byte[4] { 251, 115, 242, 184 });
		list3.Add(new byte[4] { 251, 115, 242, 184 });
		dictionary[3551497586u] = new RepeatPropertyValue(list3);
		List<byte[]> list4 = new List<byte[]>();
		list4.Add(new byte[4] { 255, 255, 255, 255 });
		list4.Add(new byte[4]);
		list4.Add(new byte[4]);
		list4.Add(new byte[4]);
		dictionary[62778008u] = new RepeatPropertyValue(list4);
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(conditional_relay_subproperties, dictionary);
		return scriptObject;
	}

	public static uint[] get_conditional_relay_subproperties()
	{
		return ScriptTypeData.get_all_types()["CRLY"].properties;
	}
}
