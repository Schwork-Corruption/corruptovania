using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class Conversion
{
	public static short b_to_i16(byte[] b_i16)
	{
		return BitConverter.ToInt16(handle_endiness(new byte[2]
		{
			b_i16[0],
			b_i16[1]
		}), 0);
	}

	public static int b_to_i32(byte[] b_i32)
	{
		return BitConverter.ToInt32(handle_endiness(new byte[4]
		{
			b_i32[0],
			b_i32[1],
			b_i32[2],
			b_i32[3]
		}), 0);
	}

	public static long b_to_i64(byte[] b_i64)
	{
		return BitConverter.ToInt64(handle_endiness(new byte[8]
		{
			b_i64[0],
			b_i64[1],
			b_i64[2],
			b_i64[3],
			b_i64[4],
			b_i64[5],
			b_i64[6],
			b_i64[7]
		}), 0);
	}

	public static byte b_to_u8(byte[] b_u8)
	{
		return handle_endiness(new byte[1] { b_u8[0] })[0];
	}

	public static byte b_to_u8(byte b_u8)
	{
		return handle_endiness(new byte[1] { b_u8 })[0];
	}

	public static ushort b_to_u16(byte[] b_u16)
	{
		return BitConverter.ToUInt16(handle_endiness(new byte[2]
		{
			b_u16[0],
			b_u16[1]
		}), 0);
	}

	public static uint b_to_u32(byte[] b_u32)
	{
		return BitConverter.ToUInt32(handle_endiness(new byte[4]
		{
			b_u32[0],
			b_u32[1],
			b_u32[2],
			b_u32[3]
		}), 0);
	}

	public static ulong b_to_u64(byte[] b_u64)
	{
		return BitConverter.ToUInt64(handle_endiness(new byte[8]
		{
			b_u64[0],
			b_u64[1],
			b_u64[2],
			b_u64[3],
			b_u64[4],
			b_u64[5],
			b_u64[6],
			b_u64[7]
		}), 0);
	}

	public static byte[] i32_to_4b(int num)
	{
		return handle_endiness(BitConverter.GetBytes(Convert.ToInt32(num)));
	}

	public static byte[] i32s_to_128b(int num1, int num2, int num3, int num4)
	{
		byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(num1));
		byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(num2));
		byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(num3));
		byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(num4));
		bytes = handle_endiness(bytes);
		bytes2 = handle_endiness(bytes2);
		bytes3 = handle_endiness(bytes3);
		bytes4 = handle_endiness(bytes4);
		List<byte> list = new List<byte>();
		list.AddRange(bytes);
		list.AddRange(bytes2);
		list.AddRange(bytes3);
		list.AddRange(bytes4);
		return list.ToArray();
	}

	public static byte[] i16_to_2b(int num)
	{
		return handle_endiness(BitConverter.GetBytes(Convert.ToInt16(num)));
	}

	public static byte[] u8_to_1b(uint num)
	{
		return handle_endiness(new byte[1] { (byte)num });
	}

	public static byte[] u32_to_4b(uint num)
	{
		return handle_endiness(BitConverter.GetBytes(Convert.ToUInt32(num)));
	}

	public static byte[] u64_to_8b(ulong num)
	{
		return handle_endiness(BitConverter.GetBytes(Convert.ToUInt64(num)));
	}

	public static byte[] float_to_4b(float fnum)
	{
		return handle_endiness(BitConverter.GetBytes(fnum));
	}

	public static byte[] u16_to_2b(uint num)
	{
		return handle_endiness(BitConverter.GetBytes(Convert.ToUInt16(num)));
	}

	public static byte[] bool_to_b(bool boolean)
	{
		if (!boolean)
		{
			return new byte[1];
		}
		return new byte[1] { 1 };
	}

	public static byte[] string_to_b(string a_string, EncodingType encoding_type)
	{
		return encoding_type switch
		{
			EncodingType.UTF8 => Encoding.UTF8.GetBytes(a_string), 
			EncodingType.UTF16 => Encoding.Unicode.GetBytes(a_string), 
			_ => throw new ArgumentException("Unsupported encoding type: " + encoding_type), 
		};
	}

	public static byte[][] to_null_terminated(string[] strings, EncodingType encoding_type)
	{
		byte[][] array = new byte[strings.Length][];
		for (int i = 0; i < strings.Length; i++)
		{
			array[i] = to_null_terminated(strings[i], encoding_type);
		}
		return array;
	}

	public static byte[] to_null_terminated(string a_string, EncodingType encoding_type)
	{
		return string_to_b(a_string + "\0", encoding_type);
	}

	public static byte[] handle_endiness(byte[] b_array)
	{
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(b_array);
		}
		return b_array;
	}
}
