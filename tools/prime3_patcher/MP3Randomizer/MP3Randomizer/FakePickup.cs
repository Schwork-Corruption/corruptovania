namespace MP3Randomizer;

public class FakePickup
{
	public ulong mrea_id;

	public uint scly_section;

	public byte[] instance_id;

	public uint item_index;

	public static FakePickup create_fake_pickup(ulong mrea_id, uint scly_section, byte[] instance_id, uint item_index)
	{
		return new FakePickup
		{
			mrea_id = mrea_id,
			scly_section = scly_section,
			instance_id = instance_id,
			item_index = item_index
		};
	}
}
