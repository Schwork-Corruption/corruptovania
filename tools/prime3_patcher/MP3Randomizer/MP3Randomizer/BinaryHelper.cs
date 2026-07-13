using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MP3Randomizer;

public class BinaryHelper
{
	public static byte[] get_b(BinaryReader b_reader, int number_of_b_to_read)
	{
		return b_reader.ReadBytes(number_of_b_to_read);
	}

	public static byte[] get_b(byte[] the_array, int pos, int number_of_b)
	{
		byte[] array = new byte[number_of_b];
		Buffer.BlockCopy(the_array, pos, array, 0, number_of_b);
		return array;
	}

	public static byte[] take_range(List<byte> b_list, uint index, uint number_to_take)
	{
		byte[] result = b_list.GetRange((int)index, (int)number_to_take).ToArray();
		b_list.RemoveRange((int)index, (int)number_to_take);
		return result;
	}

	public static bool is_equal(byte[] b_num, int int_num)
	{
		byte[] bytes = BitConverter.GetBytes(int_num);
		bytes = Conversion.handle_endiness(bytes);
		return b_num.SequenceEqual(bytes);
	}

	public static byte[] pad_to_multiple(byte[] b_data, byte pad_byte, uint multiple)
	{
		if (b_data.Length % multiple == 0L)
		{
			return b_data;
		}
		List<byte> list = new List<byte>();
		foreach (byte item in b_data)
		{
			list.Add(item);
		}
		while (list.Count % multiple != 0L)
		{
			list.Add(pad_byte);
		}
		return list.ToArray();
	}
}
