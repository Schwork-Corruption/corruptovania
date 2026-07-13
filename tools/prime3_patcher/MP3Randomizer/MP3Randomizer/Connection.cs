using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class Connection
{
	public string state = "";

	public string message = "";

	public uint target;

	public static Connection make_connection(string state, string message, byte[] target)
	{
		return new Connection
		{
			state = state,
			message = message,
			target = Conversion.b_to_u16(target)
		};
	}

	public static Connection make_connection(string state, string message, ushort target)
	{
		return new Connection
		{
			state = state,
			message = message,
			target = target
		};
	}

	public static byte[] export(Connection[] connections, uint area_index)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u16_to_2b((uint)connections.Length));
		foreach (Connection connection in connections)
		{
			list.AddRange(connection.export(area_index));
		}
		return list.ToArray();
	}

	public byte[] export(uint area_index)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Encoding.UTF8.GetBytes(state));
		list.AddRange(Encoding.UTF8.GetBytes(message));
		list.Add(0);
		list.AddRange(Conversion.u8_to_1b(area_index));
		list.AddRange(Conversion.u16_to_2b(target));
		return list.ToArray();
	}
}
