using System.Text;

namespace MP3Randomizer;

public class Dependency
{
	public ulong file_id;

	public byte[] resource_type;

	public static Dependency import(ulong user_file_id, byte[] user_resource_type)
	{
		return new Dependency
		{
			file_id = user_file_id,
			resource_type = user_resource_type
		};
	}

	public static Dependency import(ulong user_file_id, string user_resource_type)
	{
		return new Dependency
		{
			file_id = user_file_id,
			resource_type = Encoding.ASCII.GetBytes(user_resource_type)
		};
	}
}
