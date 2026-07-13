using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MP3Randomizer;

public class FileModifier
{
	public static void modify_resource_table(BinaryFileReader bin_r, ResourceTable resource_table, uint start_of_original_file_data_index, Dictionary<ulong, Resource> gathered_resources, Dictionary<ulong, Resource> modified_resources, Patches patches, uint starting_area_index, Version game_version)
	{
		HashSet<ulong> hashSet = new HashSet<ulong>();
		HashSet<ulong> hashSet2 = new HashSet<ulong>();
		HashSet<ulong> hashSet3 = new HashSet<ulong>();
		HashSet<ulong> hashSet4 = new HashSet<ulong>();
		uint num = starting_area_index;
		int num2 = resource_table.resources.Count;
		for (int i = 0; i < num2; i++)
		{
			if (modified_resources.ContainsKey(resource_table.resources[i].resource_id))
			{
				resource_table.resources[i] = modified_resources[resource_table.resources[i].resource_id];
				continue;
			}
			ulong resource_id = resource_table.resources[i].resource_id;
			hashSet4.Add(resource_id);
			Patches patches2 = patches.get_patches_for_resource(resource_id);
			string text = Encoding.UTF8.GetString(resource_table.resources[i].resource_type);
			if (text == "MLVL")
			{
				bin_r.current_index = start_of_original_file_data_index + resource_table.resources[i].original_offset;
				bin_r.bin_reader.BaseStream.Seek(bin_r.current_index, SeekOrigin.Begin);
				byte[] mlvl_data = bin_r.read((int)resource_table.resources[i].original_size);
				MLVL mLVL = MLVLFactory.create_mlvl(game_version);
				mLVL.import(mlvl_data);
				mLVL.change_bit_flags(patches.get_appropriate_mlvl_layer_toggle_patches(resource_table.resources[i].resource_id));
				resource_table.resources[i].modified_data = mLVL.export();
				resource_table.resources[i].ending_size = (uint)resource_table.resources[i].modified_data.Length;
				num = starting_area_index;
			}
			else if (text == "MREA" && patches2.has_mrea_patches(resource_id))
			{
				bin_r.current_index = start_of_original_file_data_index + resource_table.resources[i].original_offset;
				bin_r.bin_reader.BaseStream.Seek(bin_r.current_index, SeekOrigin.Begin);
				byte[] mrea_info = bin_r.read((int)resource_table.resources[i].original_size);
				if (patches.dependency_patches.ContainsKey(resource_id))
				{
					foreach (Dependency item in patches.dependency_patches[resource_id])
					{
						if (!hashSet4.Contains(item.file_id) && !hashSet3.Contains(item.file_id) && !hashSet2.Contains(item.file_id) && !hashSet.Contains(item.file_id))
						{
							resource_table.insert_resource(gathered_resources[item.file_id], i);
							hashSet4.Add(item.file_id);
							if (modified_resources.ContainsKey(resource_table.resources[i].resource_id))
							{
								resource_table.resources[i] = modified_resources[resource_table.resources[i].resource_id];
							}
							i++;
							num2++;
						}
					}
				}
				resource_table.resources[i].modified_data = MREANew.modify_mrea_new(mrea_info, resource_id, patches2, num);
				resource_table.resources[i].ending_size = (uint)resource_table.resources[i].modified_data.Length;
			}
			if (text == "MREA" || text == "MLVL")
			{
				if (text == "MREA")
				{
					num++;
				}
				hashSet = hashSet2;
				hashSet2 = hashSet3;
				hashSet3 = hashSet4;
				hashSet4 = new HashSet<ulong>();
			}
		}
	}
}
