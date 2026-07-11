namespace MP3Randomizer;

public class STRGModification
{
	public ulong resource_id;

	public LanguageModification[] language_modifications;

	public static STRGModification import(ulong resource_id, LanguageModification[] language_modifications)
	{
		return new STRGModification
		{
			resource_id = resource_id,
			language_modifications = language_modifications
		};
	}
}
