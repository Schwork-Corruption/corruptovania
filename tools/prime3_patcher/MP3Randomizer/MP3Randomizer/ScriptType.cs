namespace MP3Randomizer;

public class ScriptType
{
	public string fourCC;

	public uint[] properties;

	public static ScriptType import(string fourCC, uint[] properties)
	{
		return new ScriptType
		{
			fourCC = fourCC,
			properties = properties
		};
	}
}
