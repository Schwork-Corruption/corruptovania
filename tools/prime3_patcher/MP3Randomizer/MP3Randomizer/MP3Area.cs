using System.Collections.Generic;

namespace MP3Randomizer;

public class MP3Area
{
	private ulong area_name_resource_id;

	private byte[] transform;

	private byte[] bounding_box;

	private ulong mrea_id;

	private ulong internal_id;

	private ushort[] attached_areas;

	private Dock[] docks;

	private string internal_area_name;

	public static MP3Area[] import(BinaryArrayReader bin_r)
	{
		uint num = bin_r.read_u32();
		MP3Area[] array = new MP3Area[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			array[num2] = import_single_area(bin_r);
		}
		return array;
	}

	public static MP3Area import_single_area(BinaryArrayReader bin_r)
	{
		MP3Area obj = new MP3Area
		{
			area_name_resource_id = bin_r.read_u64(),
			transform = bin_r.read(48u),
			bounding_box = bin_r.read(24u),
			mrea_id = bin_r.read_u64(),
			internal_id = bin_r.read_u64()
		};
		uint count = bin_r.read_u32();
		obj.attached_areas = bin_r.read_u16(count);
		uint dock_count = bin_r.read_u32();
		obj.docks = Dock.import(bin_r, dock_count);
		obj.internal_area_name = bin_r.read_string(0, EncodingType.UTF8);
		return obj;
	}

	public static byte[] export(MP3Area[] areas)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u32_to_4b((uint)areas.Length));
		foreach (MP3Area mP3Area in areas)
		{
			list.AddRange(mP3Area.export());
		}
		return list.ToArray();
	}

	public byte[] export()
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u64_to_8b(area_name_resource_id));
		list.AddRange(transform);
		list.AddRange(bounding_box);
		list.AddRange(Conversion.u64_to_8b(mrea_id));
		list.AddRange(Conversion.u64_to_8b(internal_id));
		list.AddRange(Conversion.u32_to_4b((uint)attached_areas.Length));
		ushort[] array = attached_areas;
		foreach (ushort num in array)
		{
			list.AddRange(Conversion.u16_to_2b(num));
		}
		list.AddRange(Dock.export(docks));
		list.AddRange(Conversion.string_to_b(internal_area_name, EncodingType.UTF8));
		return list.ToArray();
	}
}
