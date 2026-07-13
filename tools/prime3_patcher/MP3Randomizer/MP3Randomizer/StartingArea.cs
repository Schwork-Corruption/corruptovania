namespace MP3Randomizer;

public class StartingArea
{
	public ulong world_id;

	public ulong area_id;

	public static StartingArea import(ulong world_id, ulong area_id)
	{
		return new StartingArea
		{
			world_id = world_id,
			area_id = area_id
		};
	}

	public ulong get_world_id()
	{
		return world_id;
	}

	public ulong get_area_id()
	{
		return area_id;
	}

	public byte[] get_world_id_b()
	{
		return Conversion.u64_to_8b(get_world_id());
	}

	public byte[] get_area_id_b()
	{
		return Conversion.u64_to_8b(get_area_id());
	}
}
