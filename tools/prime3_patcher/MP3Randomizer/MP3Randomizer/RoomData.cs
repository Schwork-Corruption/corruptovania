namespace MP3Randomizer;

public class RoomData
{
	public ulong world_id;

	public ulong name_strg_id;

	public ulong mrea_id;

	public RoomData(ulong world_id, ulong name_strg_id, ulong mrea_id)
	{
		this.world_id = world_id;
		this.name_strg_id = name_strg_id;
		this.mrea_id = mrea_id;
	}
}
