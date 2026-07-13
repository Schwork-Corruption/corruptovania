using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class ScriptLayer
{
	public byte[] header = new byte[0];

	public List<ScriptObject> list_of_objects;

	public uint area_index;

	public uint layer_index;

	public static ScriptLayer import(byte[] layer_data, uint area_index)
	{
		ScriptLayer scriptLayer = new ScriptLayer();
		scriptLayer.area_index = area_index;
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(layer_data);
		scriptLayer.header = binaryArrayReader.read(10u);
		scriptLayer.layer_index = Conversion.b_to_u8(scriptLayer.header[8]);
		uint num = Conversion.b_to_u32(binaryArrayReader.read(4u));
		scriptLayer.list_of_objects = new List<ScriptObject>();
		for (uint num2 = 0u; num2 < num; num2++)
		{
			ScriptObject scriptObject = new ScriptObject();
			scriptObject.type = Encoding.UTF8.GetString(binaryArrayReader.read(4u));
			scriptObject.size = Conversion.b_to_u16(binaryArrayReader.read(2u));
			binaryArrayReader.read(2u);
			scriptObject.id = Conversion.b_to_u16(binaryArrayReader.read(2u));
			uint num3 = Conversion.b_to_u16(binaryArrayReader.read(2u));
			scriptObject.connections = new List<Connection>();
			for (uint num4 = 0u; num4 < num3; num4++)
			{
				string state = Encoding.UTF8.GetString(binaryArrayReader.read(4u));
				string message = Encoding.UTF8.GetString(binaryArrayReader.read(4u));
				binaryArrayReader.read(2u);
				scriptObject.connections.Add(Connection.make_connection(state, message, binaryArrayReader.read(2u)));
			}
			scriptObject.script_data = binaryArrayReader.read(scriptObject.size - 4 - 2 - num3 * 12);
			scriptLayer.list_of_objects.Add(scriptObject);
		}
		return scriptLayer;
	}

	public byte[] export()
	{
		List<byte> list = new List<byte>();
		list.AddRange(header);
		list.AddRange(Conversion.u32_to_4b((uint)list_of_objects.Count));
		foreach (ScriptObject list_of_object in list_of_objects)
		{
			list.AddRange(list_of_object.export(area_index, layer_index));
		}
		while (list.Count % 32 != 0)
		{
			list.Add(0);
		}
		return list.ToArray();
	}

	public void add_object(ScriptObject script_object)
	{
		list_of_objects.Add(script_object);
	}
}
