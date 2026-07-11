using System.IO;

namespace MP3Randomizer;

public class IO
{
	public static void write_b(byte[] b_data, string filename)
	{
		using FileStream fileStream = File.Open(filename, FileMode.Truncate);
		fileStream.Write(b_data, 0, b_data.Length);
	}

	public static void write_b(FileStream writer, byte[] b_data)
	{
		writer.Write(b_data, 0, b_data.Length);
	}
}
