using System;
using System.Collections.Generic;

namespace MP3Randomizer;

public class AreaLayerFlags
{
	public const uint NUMBER_OF_FLAGS = 64u;

	public uint layer_count;

	public bool[] layer_flags;

	public static AreaLayerFlags[] import(BinaryArrayReader bin_r)
	{
		uint num = bin_r.read_u32();
		AreaLayerFlags[] array = new AreaLayerFlags[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			array[num2] = import_single_layer_flags(bin_r);
		}
		return array;
	}

	public static AreaLayerFlags import_single_layer_flags(BinaryArrayReader bin_r)
	{
		AreaLayerFlags areaLayerFlags = new AreaLayerFlags();
		areaLayerFlags.layer_count = bin_r.read_u32();
		ulong num = bin_r.read_u64();
		areaLayerFlags.layer_flags = new bool[64];
		for (int i = 0; (long)i < 64L; i++)
		{
			if ((double)num >= Math.Pow(2.0, 63L - (long)i))
			{
				areaLayerFlags.layer_flags[i] = true;
				num -= (ulong)Math.Pow(2.0, 63L - (long)i);
			}
		}
		Array.Reverse(areaLayerFlags.layer_flags);
		return areaLayerFlags;
	}

	public static byte[] export(AreaLayerFlags[] area_flags_array)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u32_to_4b((uint)area_flags_array.Length));
		foreach (AreaLayerFlags areaLayerFlags in area_flags_array)
		{
			list.AddRange(Conversion.u32_to_4b(areaLayerFlags.layer_count));
			list.AddRange(Conversion.u64_to_8b(areaLayerFlags.export()));
		}
		return list.ToArray();
	}

	public ulong export()
	{
		ulong num = 0uL;
		for (int i = 0; (long)i < 64L; i++)
		{
			if (layer_flags[i])
			{
				num += (ulong)Math.Pow(2.0, i);
			}
		}
		return num;
	}
}
