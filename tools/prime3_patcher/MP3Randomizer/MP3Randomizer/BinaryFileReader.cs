using System.Collections.Generic;
using System.IO;

namespace MP3Randomizer;

public class BinaryFileReader
{
	public BinaryReader bin_reader;

	public uint current_index;

	public BinaryFileReader(FileStream user_file_stream)
	{
		bin_reader = new BinaryReader(user_file_stream);
		current_index = 0u;
	}

	public BinaryFileReader(FileStream user_file_stream, uint user_current_index)
	{
		bin_reader = new BinaryReader(user_file_stream);
		current_index = user_current_index;
	}

	public BinaryFileReader(BinaryReader user_bin_reader)
	{
		bin_reader = user_bin_reader;
		current_index = 0u;
	}

	public byte[] read(int number_of_b_to_read)
	{
		byte[] result = BinaryHelper.get_b(bin_reader, number_of_b_to_read);
		current_index += (uint)number_of_b_to_read;
		return result;
	}

	public uint read_u32()
	{
		return Conversion.b_to_u32(read(4));
	}

	public ulong read_u64()
	{
		return Conversion.b_to_u64(read(8));
	}

	public byte[] read_until_multiple(int multiple)
	{
		uint number_of_b_to_read = 64 - current_index % 64;
		return read((int)number_of_b_to_read);
	}

	public byte[] read_until(byte terminating_byte)
	{
		byte[] array = read(1);
		List<byte> list = new List<byte>();
		list.AddRange(array);
		while (array[0] != terminating_byte)
		{
			array = read(1);
			list.AddRange(array);
		}
		return list.ToArray();
	}

	public void set_position(ulong byte_index)
	{
		bin_reader.BaseStream.Position = (long)byte_index;
	}
}
