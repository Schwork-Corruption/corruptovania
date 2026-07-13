using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class BinaryArrayReader
{
	public byte[] input_array;

	public List<byte> output_list;

	public uint current_index;

	public BinaryArrayReader(byte[] user_b)
	{
		input_array = user_b;
		output_list = new List<byte>();
		current_index = 0u;
	}

	public byte[] read_and_append(uint number_of_b_to_read)
	{
		byte[] array = read(number_of_b_to_read);
		append_to_list(array);
		return array;
	}

	public uint get_input_length()
	{
		return (uint)input_array.Length;
	}

	public byte read_u8()
	{
		return Conversion.b_to_u8(read(1u));
	}

	public ushort read_u16()
	{
		return Conversion.b_to_u16(read(2u));
	}

	public uint read_u32()
	{
		return Conversion.b_to_u32(read(4u));
	}

	public ulong read_u64()
	{
		return Conversion.b_to_u64(read(8u));
	}

	public short read_i16()
	{
		return Conversion.b_to_i16(read(2u));
	}

	public int read_i32()
	{
		return Conversion.b_to_i32(read(4u));
	}

	public long read_i64()
	{
		return Conversion.b_to_i64(read(8u));
	}

	public byte[] read_u8(uint count)
	{
		byte[] array = new byte[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_u8(read(1u));
		}
		return array;
	}

	public ushort[] read_u16(uint count)
	{
		ushort[] array = new ushort[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_u16(read(2u));
		}
		return array;
	}

	public uint[] read_u32(uint count)
	{
		uint[] array = new uint[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_u32(read(4u));
		}
		return array;
	}

	public ulong[] read_u64(uint count)
	{
		ulong[] array = new ulong[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_u64(read(8u));
		}
		return array;
	}

	public short[] read_i16(uint count)
	{
		short[] array = new short[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_i16(read(2u));
		}
		return array;
	}

	public int[] read_i32(uint count)
	{
		int[] array = new int[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_i32(read(4u));
		}
		return array;
	}

	public long[] read_i64(uint count)
	{
		long[] array = new long[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = Conversion.b_to_i64(read(8u));
		}
		return array;
	}

	public string read_string(byte terminating_byte, EncodingType encoding)
	{
		return encoding switch
		{
			EncodingType.UTF8 => Encoding.UTF8.GetString(read_up_to(terminating_byte)), 
			EncodingType.UTF16 => Encoding.Unicode.GetString(read_up_to(terminating_byte)), 
			_ => throw new ArgumentException("Unsupported encoding"), 
		};
	}

	public string[] read_string(byte terminating_byte, EncodingType encoding, uint count)
	{
		string[] array = new string[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = read_string(terminating_byte, encoding);
		}
		return array;
	}

	public byte[] read(uint number_of_b_to_read)
	{
		if (number_of_b_to_read == 0)
		{
			return new byte[0];
		}
		byte[] array = new byte[number_of_b_to_read];
		Buffer.BlockCopy(input_array, (int)current_index, array, 0, (int)number_of_b_to_read);
		current_index += number_of_b_to_read;
		return array;
	}

	public void append_to_list(byte[] array_to_append)
	{
		output_list.AddRange(array_to_append);
	}

	public byte[] read_and_append_remainder()
	{
		return read_and_append((uint)input_array.Length - current_index);
	}

	public byte[] read_up_to(byte terminating_byte)
	{
		List<byte> list = new List<byte>();
		byte b;
		do
		{
			b = read(1u)[0];
			list.Add(b);
		}
		while (b != terminating_byte);
		return list.ToArray();
	}

	public byte[] read_and_append_until_multiple(uint multiple)
	{
		uint num = 0u;
		List<byte> list = new List<byte>();
		while (current_index % multiple != 0)
		{
			list.Add(read_and_append(1u)[0]);
			num++;
		}
		return list.ToArray();
	}

	public byte[] read_until_multiple(uint multiple)
	{
		uint num = 0u;
		List<byte> list = new List<byte>();
		while (current_index % multiple != 0)
		{
			list.Add(read(1u)[0]);
			num++;
		}
		return list.ToArray();
	}
}
