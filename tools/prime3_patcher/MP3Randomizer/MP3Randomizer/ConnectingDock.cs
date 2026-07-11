using System.Collections.Generic;

namespace MP3Randomizer;

public class ConnectingDock
{
	private uint area_index;

	private uint dock_index;

	public static ConnectingDock[] import(BinaryArrayReader bin_r, uint connecting_dock_count)
	{
		ConnectingDock[] array = new ConnectingDock[connecting_dock_count];
		for (uint num = 0u; num < connecting_dock_count; num++)
		{
			array[num] = import(bin_r);
		}
		return array;
	}

	public static ConnectingDock import(BinaryArrayReader bin_r)
	{
		return new ConnectingDock
		{
			area_index = bin_r.read_u32(),
			dock_index = bin_r.read_u32()
		};
	}

	public static byte[] export(ConnectingDock[] connecting_docks)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u32_to_4b((uint)connecting_docks.Length));
		foreach (ConnectingDock connectingDock in connecting_docks)
		{
			list.AddRange(Conversion.u32_to_4b(connectingDock.area_index));
			list.AddRange(Conversion.u32_to_4b(connectingDock.dock_index));
		}
		return list.ToArray();
	}
}
