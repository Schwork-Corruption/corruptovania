using System.Collections.Generic;

namespace MP3Randomizer;

public class AreaModuleDependencies
{
	private byte[] rel_data;

	public static AreaModuleDependencies import(BinaryArrayReader bin_r)
	{
		AreaModuleDependencies areaModuleDependencies = new AreaModuleDependencies();
		List<byte> list = new List<byte>();
		uint num = bin_r.read_u32();
		list.AddRange(Conversion.u32_to_4b(num));
		for (uint num2 = 0u; num2 < num; num2++)
		{
			list.AddRange(bin_r.read_up_to(0));
		}
		uint num3 = bin_r.read_u32();
		list.AddRange(Conversion.u32_to_4b(num3));
		list.AddRange(bin_r.read(4 * num3));
		areaModuleDependencies.rel_data = list.ToArray();
		return areaModuleDependencies;
	}

	public byte[] export()
	{
		return rel_data;
	}
}
