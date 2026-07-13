namespace MP3Randomizer;

public class U32AdditionPropertyValue : PropertyValue
{
	private byte[] value;

	public U32AdditionPropertyValue(byte[] property_value)
	{
		value = property_value;
	}

	public override bool needs_original_value()
	{
		return true;
	}

	public override uint get_original_value_length()
	{
		return 4u;
	}

	public override byte[] get_value()
	{
		return value;
	}

	public override byte[] get_value(byte[] original_value)
	{
		return Conversion.u32_to_4b(Conversion.b_to_u32(value) + Conversion.b_to_u32(original_value));
	}

	public override uint get_length()
	{
		return 4u;
	}
}
