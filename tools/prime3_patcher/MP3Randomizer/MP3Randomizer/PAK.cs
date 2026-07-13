using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MP3Randomizer;

public class PAK
{
	public PakHeader header;

	public TableOfContents table_of_contents;

	public NamedResourceTable named_resources_table;

	public ResourceTable resource_table;

	public void update_table_of_contents()
	{
		table_of_contents.update_named_resources_size((uint)named_resources_table.get_size());
		table_of_contents.update_resource_table_size(resource_table.get_size());
		table_of_contents.update_file_data_size(resource_table.get_data_size());
	}

	public void write_to_file(string dest_pak_location, FileStream file_stream, uint start_of_original_file_data_index)
	{
		Console.WriteLine("Writing data to " + dest_pak_location);
		using FileStream fileStream = File.Open(dest_pak_location, FileMode.Create, FileAccess.Write);
		header.export(fileStream);
		table_of_contents.export(fileStream);
		named_resources_table.export(fileStream);
		resource_table.export(fileStream, file_stream, start_of_original_file_data_index);
		byte[] buffer = new byte[1];
		while (fileStream.Position % 64 != 0L)
		{
			fileStream.Write(buffer, 0, 1);
		}
		Console.WriteLine("Finished writing to " + dest_pak_location + "!");
	}

	public static Dictionary<ulong, Resource> gather_resources(string input_path, string[] pak_filenames, Patches patches, Dictionary<ulong, Resource> modified_resources)
	{
		Dictionary<ulong, Resource> dictionary = new Dictionary<ulong, Resource>();
		foreach (ulong key in patches.dependency_patches.Keys)
		{
			foreach (Dependency item in patches.dependency_patches[key])
			{
				dictionary[item.file_id] = new Resource();
			}
		}
		PAK pAK = new PAK();
		uint num = 0u;
		foreach (string text in pak_filenames)
		{
			using FileStream user_file_stream = File.Open(input_path + text, FileMode.Open);
			BinaryFileReader binaryFileReader = new BinaryFileReader(user_file_stream);
			pAK.header = PakHeader.import(binaryFileReader);
			pAK.table_of_contents = TableOfContents.import(binaryFileReader);
			pAK.named_resources_table = NamedResourceTable.import(binaryFileReader);
			pAK.resource_table = ResourceTable.import(binaryFileReader);
			num = binaryFileReader.current_index;
			foreach (ulong item2 in new List<ulong>(dictionary.Keys))
			{
				if (pAK.resource_table.contains_id(item2))
				{
					Resource resource = pAK.resource_table.get_resource_by_id(item2);
					binaryFileReader.set_position(num + resource.original_offset);
					resource.modified_data = binaryFileReader.read((int)resource.get_data_size());
					dictionary[item2] = resource;
				}
			}
		}
		foreach (ulong item3 in dictionary.Keys.ToList())
		{
			if (dictionary[item3].modified_data != null)
			{
				continue;
			}
			foreach (ulong key2 in modified_resources.Keys)
			{
				if (item3 == modified_resources[key2].resource_id)
				{
					dictionary[item3] = modified_resources[key2];
				}
			}
			if (dictionary[item3].modified_data == null)
			{
				throw new ArgumentException("Failed to find dependency " + item3);
			}
		}
		return dictionary;
	}

	public static void modify_pak(string orig_pak_location, string dest_pak_location, Dictionary<ulong, Resource> gathered_dependencies, Dictionary<ulong, Resource> modified_resources, Patches patches, uint starting_area_index, Version game_version, bool clear_pak)
	{
		Console.WriteLine("Modifying " + orig_pak_location);
		PAK pAK = new PAK();
		uint num = 0u;
		using FileStream fileStream = File.Open(orig_pak_location, FileMode.Open, FileAccess.Read);
		BinaryFileReader binaryFileReader = new BinaryFileReader(fileStream);
		pAK.header = PakHeader.import(binaryFileReader);
		pAK.table_of_contents = TableOfContents.import(binaryFileReader);
		pAK.named_resources_table = NamedResourceTable.import(binaryFileReader);
		pAK.resource_table = ResourceTable.import(binaryFileReader);
		num = binaryFileReader.current_index;
		if (clear_pak)
		{
			pAK.named_resources_table.clear();
			pAK.resource_table.clear();
		}
		else
		{
			FileModifier.modify_resource_table(binaryFileReader, pAK.resource_table, num, gathered_dependencies, modified_resources, patches, starting_area_index, game_version);
		}
		pAK.named_resources_table.fix_padding();
		pAK.resource_table.fix_data_sizes();
		pAK.resource_table.fix_data_offsets();
		pAK.resource_table.fix_padding();
		pAK.update_table_of_contents();
		pAK.write_to_file(dest_pak_location, fileStream, num);
	}
}
