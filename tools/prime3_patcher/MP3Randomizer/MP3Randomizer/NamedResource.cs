using System.IO;

namespace MP3Randomizer;

public struct NamedResource
{
	public byte[] name;

	public byte[] resource_type;

	public ulong resource_id;

	public ulong get_size()
	{
		return (ulong)((long)name.Length + (long)resource_type.Length + Conversion.u64_to_8b(resource_id).Length);
	}

	public static NamedResource import(BinaryFileReader bin_r)
	{
		return new NamedResource
		{
			name = bin_r.read_until(0),
			resource_type = bin_r.read(4),
			resource_id = bin_r.read_u64()
		};
	}

	public void export(FileStream write_file_stream)
	{
		IO.write_b(write_file_stream, name);
		IO.write_b(write_file_stream, resource_type);
		IO.write_b(write_file_stream, Conversion.u64_to_8b(resource_id));
	}
}
