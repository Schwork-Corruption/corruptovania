namespace MP3Randomizer;

public class ItemType
{
	public byte[] item_type;

	public static ItemType create_item_type(byte[] input_item_type)
	{
		return new ItemType
		{
			item_type = input_item_type
		};
	}
}
