using System.Collections.Generic;

namespace MP3Randomizer;

public class Dock
{
	private ConnectingDock[] connected_docks;

	private byte[] dock_coordinates;

	public static Dock[] import(BinaryArrayReader bin_r, uint dock_count)
	{
		Dock[] array = new Dock[dock_count];
		for (uint num = 0u; num < dock_count; num++)
		{
			array[num] = import(bin_r);
		}
		return array;
	}

	public static Dock import(BinaryArrayReader bin_r)
	{
		Dock dock = new Dock();
		uint connecting_dock_count = bin_r.read_u32();
		dock.connected_docks = ConnectingDock.import(bin_r, connecting_dock_count);
		uint num = bin_r.read_u32();
		dock.dock_coordinates = bin_r.read(num * 12);
		return dock;
	}

	public static byte[] export(Dock[] docks)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u32_to_4b((uint)docks.Length));
		foreach (Dock dock in docks)
		{
			list.AddRange(dock.export());
		}
		return list.ToArray();
	}

	public byte[] export()
	{
		List<byte> list = new List<byte>();
		list.AddRange(ConnectingDock.export(connected_docks));
		list.AddRange(Conversion.u32_to_4b((uint)dock_coordinates.Length / 12u));
		list.AddRange(dock_coordinates);
		return list.ToArray();
	}
}
