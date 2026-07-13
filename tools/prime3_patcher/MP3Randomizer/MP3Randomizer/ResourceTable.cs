using System.Collections.Generic;
using System.IO;

namespace MP3Randomizer;

public class ResourceTable
{
	public uint number_of_resources;

	public List<Resource> resources;

	public byte[] padding;

	public uint get_size()
	{
		uint num = 0u;
		foreach (Resource resource in resources)
		{
			num += resource.get_size();
		}
		return get_size_without_padding() + (uint)padding.Length;
	}

	public uint get_size_without_padding()
	{
		uint num = 0u;
		foreach (Resource resource in resources)
		{
			num += resource.get_size();
		}
		return (uint)Conversion.u32_to_4b(number_of_resources).Length + num;
	}

	public void insert_resource(Resource resource, int index)
	{
		resources.Insert(index, resource);
		number_of_resources++;
	}

	public bool contains_id(ulong resource_id)
	{
		foreach (Resource resource in resources)
		{
			if (resource.resource_id == resource_id)
			{
				return true;
			}
		}
		return false;
	}

	public Resource get_resource_by_id(ulong resource_id)
	{
		foreach (Resource resource in resources)
		{
			if (resource.resource_id == resource_id)
			{
				return resource;
			}
		}
		throw new FileNotFoundException("PAK resource cannot be found: " + resource_id);
	}

	public uint get_data_size()
	{
		uint num = 0u;
		foreach (Resource resource in resources)
		{
			num += resource.get_data_size();
		}
		return num;
	}

	public static ResourceTable import(BinaryFileReader bin_r)
	{
		ResourceTable resourceTable = new ResourceTable();
		byte[] b_u = bin_r.read(4);
		resourceTable.number_of_resources = Conversion.b_to_u32(b_u);
		resourceTable.resources = new List<Resource>();
		for (uint num = 0u; num < resourceTable.number_of_resources; num++)
		{
			resourceTable.resources.Add(Resource.import(bin_r));
		}
		resourceTable.padding = bin_r.read_until_multiple(64);
		return resourceTable;
	}

	public void fix_data_sizes()
	{
		foreach (Resource resource in resources)
		{
			resource.fix_data_size();
		}
	}

	public void fix_data_offsets()
	{
		uint num = 0u;
		foreach (Resource resource in resources)
		{
			resource.fix_data_offset(num);
			num += resource.get_data_size();
		}
	}

	public void clear()
	{
		number_of_resources = 0u;
		resources = new List<Resource>();
		padding = new byte[0];
	}

	public void fix_padding()
	{
		uint size_without_padding = get_size_without_padding();
		if (size_without_padding % 64 == 0)
		{
			padding = new byte[0];
		}
		else
		{
			padding = new byte[64 - size_without_padding % 64];
		}
	}

	public void export(FileStream write_file_stream, FileStream orig_file_stream, uint start_of_original_file_data_index)
	{
		IO.write_b(write_file_stream, Conversion.u32_to_4b(number_of_resources));
		for (uint num = 0u; num < resources.Count; num++)
		{
			resources[(int)num].export_metadata(write_file_stream);
		}
		while (write_file_stream.Position % 64 != 0L)
		{
			write_file_stream.Write(new byte[1], 0, 1);
		}
		orig_file_stream.Seek(start_of_original_file_data_index, SeekOrigin.Begin);
		BinaryFileReader bin_r = new BinaryFileReader(orig_file_stream, start_of_original_file_data_index);
		foreach (Resource resource in resources)
		{
			resource.export_file_data(write_file_stream, bin_r, start_of_original_file_data_index);
		}
	}
}
