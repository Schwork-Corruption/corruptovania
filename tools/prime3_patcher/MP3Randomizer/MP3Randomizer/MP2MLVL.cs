using System.Collections.Generic;

namespace MP3Randomizer;

public class MP2MLVL : MLVL
{
	public readonly byte[] VERSION = new byte[4] { 0, 0, 0, 23 };

	public uint world_name_resource_id;

	public uint world_name_dark_resource_id;

	public uint temple_key_world_index;

	public uint savw_resource_id;

	public uint skybox_resource_id;

	public MP2Area[] areas;

	public uint mapw_resource_id;

	public override void import(byte[] mlvl_data)
	{
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(mlvl_data);
		binaryArrayReader.read_u32();
		binaryArrayReader.read_u32();
		world_name_resource_id = binaryArrayReader.read_u32();
		world_name_dark_resource_id = binaryArrayReader.read_u32();
		temple_key_world_index = binaryArrayReader.read_u32();
		savw_resource_id = binaryArrayReader.read_u32();
		skybox_resource_id = binaryArrayReader.read_u32();
		areas = MP2Area.import(binaryArrayReader);
		mapw_resource_id = binaryArrayReader.read_u32();
		binaryArrayReader.read_u8();
		binaryArrayReader.read_u32();
		layer_flags = AreaLayerFlags.import(binaryArrayReader);
		uint count = binaryArrayReader.read_u32();
		layer_names = binaryArrayReader.read_string(0, EncodingType.UTF16, count);
		uint count2 = binaryArrayReader.read_u32();
		layer_name_offsets = binaryArrayReader.read_u32(count2);
	}

	public override byte[] export()
	{
		List<byte> list = new List<byte>();
		list.AddRange(MAGIC);
		list.AddRange(VERSION);
		list.AddRange(Conversion.u32_to_4b(world_name_resource_id));
		list.AddRange(Conversion.u32_to_4b(world_name_dark_resource_id));
		list.AddRange(Conversion.u32_to_4b(temple_key_world_index));
		list.AddRange(Conversion.u32_to_4b(savw_resource_id));
		list.AddRange(Conversion.u32_to_4b(skybox_resource_id));
		list.AddRange(MP2Area.export(areas));
		list.AddRange(Conversion.u32_to_4b(mapw_resource_id));
		list.AddRange(UNKNOWN_SCLY);
		list.AddRange(BinaryConstant.U32_ZERO);
		list.AddRange(AreaLayerFlags.export(layer_flags));
		list.AddRange(Conversion.u32_to_4b((uint)layer_names.Length));
		string[] array = layer_names;
		foreach (string a_string in array)
		{
			list.AddRange(Conversion.string_to_b(a_string, EncodingType.UTF16));
		}
		list.AddRange(Conversion.u32_to_4b((uint)layer_name_offsets.Length));
		uint[] array2 = layer_name_offsets;
		foreach (uint num in array2)
		{
			list.AddRange(Conversion.u32_to_4b(num));
		}
		return BinaryHelper.pad_to_multiple(list.ToArray(), byte.MaxValue, 32u);
	}
}
