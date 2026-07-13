using System.Collections.Generic;

namespace MP3Randomizer;

public class RepeatPropertyValue : PropertyValue
{
	private List<byte[]> property_values;

	private uint current_index;

	public RepeatPropertyValue(List<byte[]> property_values)
	{
		this.property_values = property_values;
	}

	public override bool needs_original_value()
	{
		return false;
	}

	public override uint get_original_value_length()
	{
		return 0u;
	}

	public override byte[] get_value()
	{
		byte[] result = property_values[(int)current_index];
		current_index++;
		if (current_index == property_values.Count)
		{
			current_index = 0u;
		}
		return result;
	}

	public override byte[] get_value(byte[] original_value)
	{
		return get_value();
	}

	public override uint get_length()
	{
		return (uint)property_values[(int)current_index].Length;
	}
}
