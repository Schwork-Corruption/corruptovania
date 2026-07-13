using System.IO;

namespace MP3Randomizer;

public class PakHeader
{
	public byte[] unknown_value;

	public uint header_size;

	public byte[] hash;

	public byte[] padding;

	public int get_size()
	{
		return unknown_value.Length + Conversion.u32_to_4b(header_size).Length + hash.Length + padding.Length;
	}

	public static PakHeader import(BinaryFileReader bin_r)
	{
		return new PakHeader
		{
			unknown_value = bin_r.read(4),
			header_size = bin_r.read_u32(),
			hash = bin_r.read(16),
			padding = bin_r.read(40)
		};
	}

	public void export(FileStream write_file_stream)
	{
		IO.write_b(write_file_stream, unknown_value);
		IO.write_b(write_file_stream, Conversion.u32_to_4b(header_size));
		IO.write_b(write_file_stream, hash);
		IO.write_b(write_file_stream, padding);
	}
}
