namespace MP3Randomizer;

public class BPropertyValue : PropertyValue
{
	private byte[] value;

	public override bool needs_original_value()
	{
		return false;
	}

	public override uint get_original_value_length()
	{
		return 0u;
	}

	public BPropertyValue(byte[] property_value)
	{
		value = property_value;
	}

	public override byte[] get_value()
	{
		return value;
	}

	public override byte[] get_value(byte[] original_value)
	{
		return get_value();
	}

	public override uint get_length()
	{
		return (uint)value.Length;
	}
}
