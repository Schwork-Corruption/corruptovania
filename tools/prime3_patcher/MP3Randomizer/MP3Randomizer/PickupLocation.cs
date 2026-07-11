namespace MP3Randomizer;

public class PickupLocation
{
	public ulong mrea_id;

	public uint scly_section;

	public string type;

	public byte[] instance_id;

	public byte[] memo_id;

	public byte[] streamed_audio_id;

	public byte[] percentage_pickup_id;

	public byte[] end_relay_id;

	public bool should_modify_hud_type;

	public uint item_index;

	public static PickupLocation create_pickup_location(ulong mrea_id, uint scly_section, string type, byte[] instance_id, byte[] memo_id, byte[] streamed_audio_id, byte[] percentage_pickup_id, byte[] end_relay_id, bool should_modify_hud_type, uint item_index)
	{
		return new PickupLocation
		{
			mrea_id = mrea_id,
			scly_section = scly_section,
			type = type,
			instance_id = instance_id,
			memo_id = memo_id,
			streamed_audio_id = streamed_audio_id,
			percentage_pickup_id = percentage_pickup_id,
			end_relay_id = end_relay_id,
			should_modify_hud_type = should_modify_hud_type,
			item_index = item_index
		};
	}
}
