using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MP3Randomizer;

public class Compression
{
	private const string LzOkayLibrary = "lzokay";

	public static uint MAX_BLOCK_SIZE = 16384u;

	static Compression()
	{
		NativeLibrary.SetDllImportResolver(typeof(Compression).Assembly, ResolveLibrary);
	}

	[DllImport(LzOkayLibrary, CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern void compress_without_dict(byte* src_array_start, int src_len, byte* dest_array_start, int dest_start_length, ref int dest_final_length);

	[DllImport(LzOkayLibrary, CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern void decompress(byte* src_array_start, int src_len, byte* dest_array_start, int dest_start_length, ref int dest_final_length);

	private static IntPtr ResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		if (libraryName != LzOkayLibrary)
		{
			return IntPtr.Zero;
		}

		string baseDirectory = AppContext.BaseDirectory;
		string[] candidates = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
			? new string[]
			{
				Path.Combine(baseDirectory, "lzokay.dll"),
				Path.Combine(baseDirectory, "lzokay", "lzokay.dll"),
			}
			: RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
				? new string[]
				{
					Path.Combine(baseDirectory, "liblzokay.dylib"),
				}
				: new string[]
				{
					Path.Combine(baseDirectory, "liblzokay.so"),
				};

		foreach (string candidate in candidates)
		{
			if (File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out IntPtr handle))
			{
				return handle;
			}
		}

		return IntPtr.Zero;
	}

	public unsafe static byte[] decompress_mrea_block(byte[] compressed_b)
	{
		List<byte> list = new List<byte>();
		byte[] array = new byte[MAX_BLOCK_SIZE];
		_ = new byte[1];
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(compressed_b);
		while (binaryArrayReader.current_index < binaryArrayReader.get_input_length() - 1)
		{
			short num = binaryArrayReader.read_i16();
			if (num < 0)
			{
				list.AddRange(binaryArrayReader.read((uint)Math.Abs(num)));
				continue;
			}
			array = new byte[MAX_BLOCK_SIZE];
			byte[] array2 = binaryArrayReader.read((uint)num);
			int num2 = array.Length;
			int dest_final_length = num2;
			fixed (byte* src_array_start = &array2[0])
			{
				fixed (byte* dest_array_start = &array[0])
				{
					decompress(src_array_start, num, dest_array_start, num2, ref dest_final_length);
				}
			}
			Array.Resize(ref array, dest_final_length);
			list.AddRange(array);
		}
		return list.ToArray();
	}

	public unsafe static byte[] compress_mrea_block(byte[] decompressed_b)
	{
		List<byte> list = new List<byte>();
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(decompressed_b);
		byte[] array = new byte[1];
		byte[] array2 = new byte[1];
		_ = new byte[2];
		while (binaryArrayReader.current_index < decompressed_b.Length)
		{
			int num = Math.Min(16384, decompressed_b.Length - (int)binaryArrayReader.current_index);
			array = binaryArrayReader.read((uint)num);
			array2 = new byte[array.Length * 2];
			int num2 = array2.Length;
			int dest_final_length = num2;
			fixed (byte* src_array_start = &array[0])
			{
				fixed (byte* dest_array_start = &array2[0])
				{
					compress_without_dict(src_array_start, num, dest_array_start, num2, ref dest_final_length);
				}
			}
			Array.Resize(ref array2, dest_final_length);
			if (array2.Length < array.Length)
			{
				list.AddRange(Conversion.i16_to_2b((short)dest_final_length));
				list.AddRange(array2);
			}
			else
			{
				list.AddRange(Conversion.i16_to_2b((short)(array.Length * -1)));
				list.AddRange(array);
			}
		}
		return list.ToArray();
	}
}
