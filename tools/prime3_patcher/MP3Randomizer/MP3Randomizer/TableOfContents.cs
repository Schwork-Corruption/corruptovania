using System;
using System.IO;

namespace MP3Randomizer;

public class TableOfContents
{
	public uint section_count;

	public byte[] strg_cc;

	public uint named_resources_size;

	public byte[] rshd_cc;

	public uint resource_table_size;

	public byte[] data_cc;

	public uint file_data_size;

	public byte[] padding;

	public int get_size()
	{
		return Conversion.u32_to_4b(section_count).Length + strg_cc.Length + Conversion.u32_to_4b(named_resources_size).Length + rshd_cc.Length + Conversion.u32_to_4b(resource_table_size).Length + data_cc.Length + Conversion.u32_to_4b(file_data_size).Length + padding.Length;
	}

	public static TableOfContents import(BinaryFileReader bin_r)
	{
		TableOfContents tableOfContents = new TableOfContents();
		tableOfContents.section_count = Conversion.b_to_u32(bin_r.read(4));
		tableOfContents.strg_cc = bin_r.read(4);
		tableOfContents.named_resources_size = Conversion.b_to_u32(bin_r.read(4));
		tableOfContents.rshd_cc = bin_r.read(4);
		tableOfContents.resource_table_size = Conversion.b_to_u32(bin_r.read(4));
		tableOfContents.data_cc = bin_r.read(4);
		if ((tableOfContents.data_cc[0] != 68) | (tableOfContents.data_cc[1] != 65) | (tableOfContents.data_cc[2] != 84) | (tableOfContents.data_cc[3] != 65))
		{
			throw new ArgumentException("Data fourcc is wrong!");
		}
		tableOfContents.file_data_size = Conversion.b_to_u32(bin_r.read(4));
		tableOfContents.padding = bin_r.read(36);
		if ((tableOfContents.padding[0] != 0) | (tableOfContents.padding[35] != 0))
		{
			throw new ArgumentException("Table of contents padding is wrong!");
		}
		return tableOfContents;
	}

	public void update_named_resources_size(uint size)
	{
		named_resources_size = size;
	}

	public void update_resource_table_size(uint size)
	{
		resource_table_size = size;
	}

	public void update_file_data_size(uint size)
	{
		file_data_size = size;
	}

	public void export(FileStream write_file_stream)
	{
		IO.write_b(write_file_stream, Conversion.u32_to_4b(section_count));
		IO.write_b(write_file_stream, strg_cc);
		IO.write_b(write_file_stream, Conversion.u32_to_4b(named_resources_size));
		IO.write_b(write_file_stream, rshd_cc);
		IO.write_b(write_file_stream, Conversion.u32_to_4b(resource_table_size));
		IO.write_b(write_file_stream, data_cc);
		IO.write_b(write_file_stream, Conversion.u32_to_4b(file_data_size));
		IO.write_b(write_file_stream, padding);
	}
}
