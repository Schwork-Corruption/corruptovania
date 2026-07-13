using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class ScriptObject
{
	public string type = "";

	public uint size;

	public uint id;

	public List<Connection> connections;

	public byte[] script_data;

	public byte[] export(uint area_index, uint layer_index)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Encoding.UTF8.GetBytes(type));
		uint num = (uint)(6 + connections.Count * 12 + script_data.Length);
		list.AddRange(Conversion.u16_to_2b(num));
		list.AddRange(Conversion.u8_to_1b(layer_index * 4));
		list.AddRange(Conversion.u8_to_1b(area_index));
		list.AddRange(Conversion.u16_to_2b(id));
		list.AddRange(Conversion.u16_to_2b((uint)connections.Count));
		foreach (Connection connection in connections)
		{
			list.AddRange(connection.export(area_index));
		}
		list.AddRange(script_data);
		return list.ToArray();
	}
}
