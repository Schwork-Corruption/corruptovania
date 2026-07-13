using System;

namespace MP3Randomizer;

public class PropertyModification
{
	public byte[] property_id;

	private PropertyValue property_value;

	public static PropertyModification import(byte[] property_id, PropertyValue property_value)
	{
		return new PropertyModification
		{
			property_id = property_id,
			property_value = property_value
		};
	}

	public uint get_property_value_length()
	{
		return property_value.get_length();
	}

	public byte[] get_property_value(byte[] data, uint index)
	{
		if (property_value.needs_original_value())
		{
			uint original_value_length = property_value.get_original_value_length();
			byte[] array = new byte[original_value_length];
			Array.Copy(data, index, array, 0L, original_value_length);
			return property_value.get_value(array);
		}
		return property_value.get_value();
	}
}
