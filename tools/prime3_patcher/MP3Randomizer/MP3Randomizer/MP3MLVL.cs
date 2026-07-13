using System.Collections.Generic;

namespace MP3Randomizer;

public class MP3MLVL : MLVL
{
	public readonly byte[] VERSION = new byte[4] { 0, 0, 0, 25 };

	public ulong world_name_resource_id;

	public uint temple_key_world_index;

	public ulong savw_resource_id;

	public ulong skybox_resource_id;

	public MP3Area[] areas;

	public ulong mapw_resource_id;

	public uint[] layer_guids;

	public override void import(byte[] mlvl_data)
	{
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(mlvl_data);
		binaryArrayReader.read_u32();
		binaryArrayReader.read_u32();
		world_name_resource_id = binaryArrayReader.read_u64();
		temple_key_world_index = binaryArrayReader.read_u32();
		savw_resource_id = binaryArrayReader.read_u64();
		skybox_resource_id = binaryArrayReader.read_u64();
		areas = MP3Area.import(binaryArrayReader);
		mapw_resource_id = binaryArrayReader.read_u64();
		binaryArrayReader.read_u8();
		binaryArrayReader.read_u32();
		layer_flags = AreaLayerFlags.import(binaryArrayReader);
		uint count = binaryArrayReader.read_u32();
		layer_names = binaryArrayReader.read_string(0, EncodingType.UTF8, count);
		uint num = binaryArrayReader.read_u32();
		layer_guids = binaryArrayReader.read_u32(num * 4);
		uint count2 = binaryArrayReader.read_u32();
		layer_name_offsets = binaryArrayReader.read_u32(count2);
	}

	public override byte[] export()
	{
		List<byte> list = new List<byte>();
		list.AddRange(MAGIC);
		list.AddRange(VERSION);
		list.AddRange(Conversion.u64_to_8b(world_name_resource_id));
		list.AddRange(Conversion.u32_to_4b(temple_key_world_index));
		list.AddRange(Conversion.u64_to_8b(savw_resource_id));
		list.AddRange(Conversion.u64_to_8b(skybox_resource_id));
		list.AddRange(MP3Area.export(areas));
		list.AddRange(Conversion.u64_to_8b(mapw_resource_id));
		list.AddRange(UNKNOWN_SCLY);
		list.AddRange(BinaryConstant.U32_ZERO);
		list.AddRange(AreaLayerFlags.export(layer_flags));
		list.AddRange(Conversion.u32_to_4b((uint)layer_names.Length));
		string[] array = layer_names;
		foreach (string a_string in array)
		{
			list.AddRange(Conversion.string_to_b(a_string, EncodingType.UTF8));
		}
		list.AddRange(Conversion.u32_to_4b((uint)layer_guids.Length / 4u));
		uint[] array2 = layer_guids;
		foreach (uint num in array2)
		{
			list.AddRange(Conversion.u32_to_4b(num));
		}
		list.AddRange(Conversion.u32_to_4b((uint)layer_name_offsets.Length));
		array2 = layer_name_offsets;
		foreach (uint num2 in array2)
		{
			list.AddRange(Conversion.u32_to_4b(num2));
		}
		return BinaryHelper.pad_to_multiple(list.ToArray(), byte.MaxValue, 64u);
	}
}
