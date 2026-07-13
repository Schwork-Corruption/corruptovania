using System;
using System.Collections.Generic;

namespace MP3Randomizer;

public class MREANew
{
	public static byte[] modify_mrea_new(byte[] mrea_info, ulong mrea_id, Patches patches, uint area_index)
	{
		new List<byte>(mrea_info.Length + 200000);
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(mrea_info);
		_ = new byte[1];
		byte[] array = binaryArrayReader.read_and_append(4u);
		if (array[0] != 222 && array[1] != 173 && array[2] != 190 && array[3] != 239)
		{
			throw new ArgumentException("Wrong magic for MREA. Magic should be 0xDEADBEEF");
		}
		binaryArrayReader.read_and_append(52u);
		binaryArrayReader.read_and_append(4u);
		int num = Conversion.b_to_i32(binaryArrayReader.read_and_append(4u));
		uint num2 = Conversion.b_to_u32(binaryArrayReader.read_and_append(4u));
		int num3 = Conversion.b_to_i32(binaryArrayReader.read_and_append(4u));
		int num4 = Conversion.b_to_i32(binaryArrayReader.read_and_append(4u));
		binaryArrayReader.read_and_append(20u);
		uint[] array2 = new uint[num2];
		for (uint num5 = 0u; num5 < array2.Length; num5++)
		{
			array2[num5] = Conversion.b_to_u32(binaryArrayReader.read(4u));
		}
		uint num6 = (uint)binaryArrayReader.read_until_multiple(32u).Length;
		uint[] array3 = new uint[num3];
		uint[] array4 = new uint[num3];
		uint[] array5 = new uint[num3];
		uint[] array6 = new uint[num3];
		int i;
		for (i = 0; i < num3; i++)
		{
			array3[i] = Conversion.b_to_u32(binaryArrayReader.read(4u));
			array4[i] = Conversion.b_to_u32(binaryArrayReader.read(4u));
			array5[i] = Conversion.b_to_u32(binaryArrayReader.read(4u));
			array6[i] = Conversion.b_to_u32(binaryArrayReader.read(4u));
		}
		uint num7 = (uint)binaryArrayReader.read_until_multiple(32u).Length;
		i = 0;
		List<byte> list = new List<byte>();
		uint num8 = 20000000u;
		uint num9 = 20000000u;
		uint num10 = 20000000u;
		for (int j = 0; j < num4; j++)
		{
			byte[] array7 = binaryArrayReader.read(4u);
			list.AddRange(array7);
			if (array7[0] == 83 && array7[1] == 79)
			{
				num8 = Conversion.b_to_u32(binaryArrayReader.read(4u));
				list.AddRange(Conversion.u32_to_4b(num8));
			}
			else if (array7[0] == 68 && array7[1] == 69)
			{
				num9 = Conversion.b_to_u32(binaryArrayReader.read(4u));
				list.AddRange(Conversion.u32_to_4b(num9));
			}
			else if (array7[0] == 82 && array7[1] == 83)
			{
				num10 = Conversion.b_to_u32(binaryArrayReader.read(4u));
				list.AddRange(Conversion.u32_to_4b(num10));
			}
			else
			{
				list.AddRange(binaryArrayReader.read(4u));
			}
		}
		uint num11 = (uint)binaryArrayReader.read_until_multiple(32u).Length;
		list.AddRange(new byte[num11]);
		List<byte> list2 = new List<byte>();
		uint num12 = 0u;
		for (uint num13 = 0u; num13 < num3; num13++)
		{
			if (array5[num13] == 0)
			{
				if (num12 != num9)
				{
					_ = num12 + array6[num13];
					_ = num9 + 1;
				}
				if (num12 >= num8 && num12 < num8 + num)
				{
					byte[] array8 = binaryArrayReader.read(array4[num13]);
					int num14 = array8.Length;
					array8 = ScriptLayerHandler.modify_script_layers(array8, patches.get_patches_for_layer(num12 - num8), area_index, mrea_id);
					uint num15 = (uint)array8.Length;
					list2.AddRange(array8);
					if (num14 != (int)num15)
					{
						throw new ArgumentException("Changed length of uncompressed SCLY?");
					}
				}
				else
				{
					list2.AddRange(binaryArrayReader.read(array4[num13]));
				}
			}
			else if ((num12 < num8 || num12 >= num8 + num + 1) && num12 + array6[num13] != num9 + 1)
			{
				uint num16 = 32 - array5[num13] % 32;
				if (num16 != 32)
				{
					list2.AddRange(binaryArrayReader.read(num16));
				}
				list2.AddRange(binaryArrayReader.read(array5[num13]));
			}
			else if (num12 == num9 || num12 + array6[num13] == num9 + 1)
			{
				uint num17 = 32 - array5[num13] % 32;
				if (num17 != 32)
				{
					byte[] array9 = binaryArrayReader.read(num17);
					for (int k = 0; k < array9.Length; k++)
					{
						if (array9[k] != 0)
						{
							throw new ArgumentException("SCLY padding contains non-zero values?");
						}
					}
				}
				else
				{
					num17 = 0u;
				}
				byte[] array10 = Compression.decompress_mrea_block(binaryArrayReader.read(array5[num13]));
				uint num18 = array2[num9];
				BinaryArrayReader binaryArrayReader2 = new BinaryArrayReader(array10);
				if ((uint)array10.Length - num18 != 0)
				{
					binaryArrayReader2.read_and_append((uint)array10.Length - num18);
				}
				byte[] array11 = binaryArrayReader2.read(num18);
				if (patches.dependency_patches.ContainsKey(mrea_id))
				{
					array11 = DependencyHandler.add_dependencies(array11, patches.dependency_patches[mrea_id]);
				}
				array2[num9] = (uint)array11.Length;
				binaryArrayReader2.append_to_list(array11);
				array10 = binaryArrayReader2.output_list.ToArray();
				uint num19 = (uint)(32 - array10.Length % 32);
				if (num19 == 32)
				{
					num19 = 0u;
				}
				array4[num13] = (uint)array10.Length + num19;
				array3[num13] = array4[num13] + 288;
				List<byte> list3 = new List<byte>(array10);
				for (uint num20 = 0u; num20 < num19; num20++)
				{
					list3.AddRange(new byte[1]);
				}
				array10 = list3.ToArray();
				byte[] array12 = Compression.compress_mrea_block(array10);
				num17 = (uint)(32 - array12.Length % 32);
				array5[num13] = (uint)array12.Length;
				if (num17 != 32)
				{
					list2.AddRange(new byte[num17]);
				}
				list2.AddRange(array12);
			}
			else
			{
				uint num21 = 32 - array5[num13] % 32;
				if (num21 != 32)
				{
					byte[] array9 = binaryArrayReader.read(num21);
					for (int k = 0; k < array9.Length; k++)
					{
						if (array9[k] != 0)
						{
							throw new ArgumentException("SCLY compression padding should be 0x00.");
						}
					}
				}
				else
				{
					num21 = 0u;
				}
				byte[] scly_data = Compression.decompress_mrea_block(binaryArrayReader.read(array5[num13]));
				scly_data = ScriptLayerHandler.modify_script_layers(scly_data, patches.get_patches_for_layer(num12 - num8), area_index, mrea_id);
				uint num22 = (uint)(32 - scly_data.Length % 32);
				if (num22 == 32)
				{
					num22 = 0u;
				}
				array4[num13] = (uint)scly_data.Length + num22;
				array3[num13] = array4[num13] + 288;
				List<byte> list4 = new List<byte>(scly_data);
				for (uint num23 = 0u; num23 < num22; num23++)
				{
					list4.AddRange(new byte[1]);
				}
				scly_data = list4.ToArray();
				byte[] array13 = Compression.compress_mrea_block(scly_data);
				num21 = (uint)(32 - array13.Length % 32);
				array5[num13] = (uint)array13.Length;
				if (num21 != 32)
				{
					list2.AddRange(new byte[num21]);
				}
				list2.AddRange(array13);
				array2[num12] = array4[num13];
			}
			num12 += array6[num13];
		}
		for (uint num24 = 0u; num24 < array2.Length; num24++)
		{
			binaryArrayReader.append_to_list(Conversion.u32_to_4b(array2[num24]));
		}
		binaryArrayReader.append_to_list(new byte[num6]);
		for (i = 0; i < num3; i++)
		{
			byte[] array_to_append = Conversion.u32_to_4b(array3[i]);
			binaryArrayReader.append_to_list(array_to_append);
			byte[] array_to_append2 = Conversion.u32_to_4b(array4[i]);
			binaryArrayReader.append_to_list(array_to_append2);
			byte[] array_to_append3 = Conversion.u32_to_4b(array5[i]);
			binaryArrayReader.append_to_list(array_to_append3);
			byte[] array_to_append4 = Conversion.u32_to_4b(array6[i]);
			binaryArrayReader.append_to_list(array_to_append4);
		}
		binaryArrayReader.append_to_list(new byte[num7]);
		binaryArrayReader.append_to_list(list.ToArray());
		binaryArrayReader.append_to_list(list2.ToArray());
		byte[] array_to_append5 = new byte[1] { 255 };
		while (binaryArrayReader.output_list.Count % 64 != 0)
		{
			binaryArrayReader.append_to_list(array_to_append5);
		}
		return binaryArrayReader.output_list.ToArray();
	}
}
