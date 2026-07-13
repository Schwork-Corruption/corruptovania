using System;
using System.IO;
using System.Text;

namespace MP3Randomizer;

public class Resource
{
	public uint compression_flag;

	public byte[] resource_type;

	public ulong resource_id;

	public uint original_size;

	public uint ending_size;

	public uint original_offset;

	public uint ending_offset;

	public byte[] modified_data;

	public uint get_size()
	{
		return (uint)(Conversion.u32_to_4b(compression_flag).Length + resource_type.Length + Conversion.u64_to_8b(resource_id).Length + Conversion.u32_to_4b(ending_size).Length + Conversion.u32_to_4b(ending_offset).Length);
	}

	public uint get_data_size()
	{
		if (modified_data.Length == 0)
		{
			return ending_size;
		}
		return (uint)modified_data.Length;
	}

	public static Resource to_resource(ulong resource_id, byte[] resource_type, uint compression_flag, byte[] data)
	{
		return new Resource
		{
			compression_flag = compression_flag,
			resource_type = resource_type,
			resource_id = resource_id,
			modified_data = data,
			original_size = (uint)data.Length,
			ending_size = (uint)data.Length
		};
	}

	public static Resource to_resource(ulong resource_id, string resource_type, uint compression_flag, byte[] data)
	{
		return to_resource(resource_id, Encoding.UTF8.GetBytes(resource_type), compression_flag, data);
	}

	public static Resource import(BinaryFileReader bin_r)
	{
		Resource resource = new Resource();
		resource.compression_flag = bin_r.read_u32();
		if ((resource.compression_flag != 0) & (resource.compression_flag != 1))
		{
			throw new ArgumentException("Compression flag should be 0 or 1, not " + resource.compression_flag);
		}
		resource.resource_type = bin_r.read(4);
		resource.resource_id = bin_r.read_u64();
		resource.original_size = bin_r.read_u32();
		resource.ending_size = resource.original_size;
		resource.original_offset = bin_r.read_u32();
		resource.ending_offset = resource.original_offset;
		resource.modified_data = new byte[0];
		return resource;
	}

	public void fix_data_size()
	{
		ending_size = get_data_size();
	}

	public void fix_data_offset(uint current_offset)
	{
		ending_offset = current_offset;
	}

	public void export_metadata(FileStream writer)
	{
		IO.write_b(writer, Conversion.u32_to_4b(compression_flag));
		IO.write_b(writer, resource_type);
		IO.write_b(writer, Conversion.u64_to_8b(resource_id));
		IO.write_b(writer, Conversion.u32_to_4b(ending_size));
		if (ending_size % 64 != 0)
		{
			throw new ArgumentException("Size for resource should be multiple of 64");
		}
		IO.write_b(writer, Conversion.u32_to_4b(ending_offset));
	}

	public void export_file_data(FileStream writer, BinaryFileReader bin_r, uint start_of_original_file_data_index)
	{
		if (modified_data.Length == 0)
		{
			bin_r.bin_reader.BaseStream.Seek(start_of_original_file_data_index + original_offset, SeekOrigin.Begin);
			byte[] b_data = bin_r.read((int)original_size);
			IO.write_b(writer, b_data);
		}
		else
		{
			IO.write_b(writer, modified_data);
		}
	}
}
