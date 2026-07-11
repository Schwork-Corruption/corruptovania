namespace MP3Randomizer;

public abstract class PropertyValue
{
	public abstract bool needs_original_value();

	public abstract uint get_original_value_length();

	public abstract byte[] get_value();

	public abstract byte[] get_value(byte[] original_value);

	public abstract uint get_length();
}
