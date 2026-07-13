using System;

namespace MP3Randomizer;

public class RandomColorPropertyValue : PropertyValue
{
	private Random rng;

	public override bool needs_original_value()
	{
		return false;
	}

	public override uint get_original_value_length()
	{
		return 0u;
	}

	public RandomColorPropertyValue(Random rng)
	{
		this.rng = rng;
	}

	public override byte[] get_value()
	{
		return Color.get_random_rgba(rng);
	}

	public override byte[] get_value(byte[] original_value)
	{
		return get_value();
	}

	public override uint get_length()
	{
		return 16u;
	}
}
