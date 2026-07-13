using System.Collections.Generic;

namespace MP3Randomizer;

public class MP2Area
{
	private uint area_name_resource_id;

	private byte[] transform;

	private byte[] bounding_box;

	private uint mrea_id;

	private uint internal_id;

	private ushort[] attached_areas;

	private AreaDependencies dependencies;

	private Dock[] docks;

	private AreaModuleDependencies module_dependencies;

	private string internal_area_name;

	public static MP2Area[] import(BinaryArrayReader bin_r)
	{
		uint num = bin_r.read_u32();
		MP2Area[] array = new MP2Area[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			array[num2] = import_single_area(bin_r);
		}
		return array;
	}

	public static MP2Area import_single_area(BinaryArrayReader bin_r)
	{
		MP2Area obj = new MP2Area
		{
			area_name_resource_id = bin_r.read_u32(),
			transform = bin_r.read(48u),
			bounding_box = bin_r.read(24u),
			mrea_id = bin_r.read_u32(),
			internal_id = bin_r.read_u32()
		};
		uint count = bin_r.read_u32();
		obj.attached_areas = bin_r.read_u16(count);
		obj.dependencies = AreaDependencies.import(bin_r);
		uint dock_count = bin_r.read_u32();
		obj.docks = Dock.import(bin_r, dock_count);
		obj.module_dependencies = AreaModuleDependencies.import(bin_r);
		obj.internal_area_name = bin_r.read_string(0, EncodingType.UTF16);
		return obj;
	}

	public static byte[] export(MP2Area[] areas)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u32_to_4b((uint)areas.Length));
		foreach (MP2Area mP2Area in areas)
		{
			list.AddRange(mP2Area.export());
		}
		return list.ToArray();
	}

	public byte[] export()
	{
		List<byte> list = new List<byte>();
		list.AddRange(Conversion.u32_to_4b(area_name_resource_id));
		list.AddRange(transform);
		list.AddRange(bounding_box);
		list.AddRange(Conversion.u32_to_4b(mrea_id));
		list.AddRange(Conversion.u32_to_4b(internal_id));
		list.AddRange(Conversion.u32_to_4b((uint)attached_areas.Length));
		ushort[] array = attached_areas;
		foreach (ushort num in array)
		{
			list.AddRange(Conversion.u16_to_2b(num));
		}
		list.AddRange(dependencies.export());
		list.AddRange(Dock.export(docks));
		list.AddRange(module_dependencies.export());
		list.AddRange(Conversion.string_to_b(internal_area_name, EncodingType.UTF16));
		return list.ToArray();
	}
}
