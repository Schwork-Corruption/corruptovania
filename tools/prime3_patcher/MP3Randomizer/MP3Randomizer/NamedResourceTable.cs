using System;
using System.IO;

namespace MP3Randomizer;

public struct NamedResourceTable
{
	public uint number_of_named_resources;

	public NamedResource[] named_resources;

	public byte[] padding;

	public ulong get_size()
	{
		return get_size_without_padding() + (ulong)padding.Length;
	}

	public ulong get_size_without_padding()
	{
		uint num = 0u;
		for (uint num2 = 0u; num2 < named_resources.Length; num2++)
		{
			num += (uint)(int)named_resources[num2].get_size();
		}
		return (ulong)(Conversion.u32_to_4b(number_of_named_resources).Length + num);
	}

	public static NamedResourceTable import(BinaryFileReader bin_r)
	{
		NamedResourceTable result = default(NamedResourceTable);
		result.number_of_named_resources = bin_r.read_u32();
		result.named_resources = new NamedResource[result.number_of_named_resources];
		for (uint num = 0u; num < result.named_resources.Length; num++)
		{
			result.named_resources[num] = NamedResource.import(bin_r);
		}
		result.padding = bin_r.read_until_multiple(64);
		byte[] array = result.padding;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != 0)
			{
				throw new ArgumentException("Named resource padding is of the wrong byte.");
			}
		}
		return result;
	}

	public void clear()
	{
		number_of_named_resources = 0u;
		named_resources = new NamedResource[0];
		padding = new byte[0];
	}

	public void fix_padding()
	{
		ulong size_without_padding = get_size_without_padding();
		if (size_without_padding % 64 == 0L)
		{
			padding = new byte[0];
		}
		else
		{
			padding = new byte[64 - size_without_padding % 64];
		}
	}

	public void export(FileStream write_file_stream)
	{
		IO.write_b(write_file_stream, Conversion.u32_to_4b(number_of_named_resources));
		NamedResource[] array = named_resources;
		foreach (NamedResource namedResource in array)
		{
			namedResource.export(write_file_stream);
		}
		IO.write_b(write_file_stream, padding);
	}
}
