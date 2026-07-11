using System.Collections.Generic;

namespace MP3Randomizer;

public class AreaDependencies
{
	private byte[] dependency_data;

	public static AreaDependencies import(BinaryArrayReader bin_r)
	{
		AreaDependencies areaDependencies = new AreaDependencies();
		List<byte> list = new List<byte>();
		list.AddRange(bin_r.read(4u));
		uint num = bin_r.read_u32();
		list.AddRange(Conversion.u32_to_4b(num));
		for (uint num2 = 0u; num2 < num; num2++)
		{
			list.AddRange(bin_r.read(12u));
		}
		uint num3 = bin_r.read_u32();
		list.AddRange(Conversion.u32_to_4b(num3));
		list.AddRange(bin_r.read(4 * num3));
		areaDependencies.dependency_data = list.ToArray();
		return areaDependencies;
	}

	public byte[] export()
	{
		return dependency_data;
	}
}
