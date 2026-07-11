namespace MP3Randomizer;

public class ScriptPart
{
	public byte[] identifier;

	public byte[] size;

	public string type;

	public byte[] default_value;

	public uint[] subproperties;

	public static ScriptPart import(byte[] identifier, byte[] size, string type, byte[] default_value, uint[] subproperties)
	{
		return new ScriptPart
		{
			identifier = identifier,
			size = size,
			type = type,
			default_value = default_value,
			subproperties = subproperties
		};
	}
}
