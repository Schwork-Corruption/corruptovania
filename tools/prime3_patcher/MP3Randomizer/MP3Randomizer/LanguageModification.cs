namespace MP3Randomizer;

public class LanguageModification
{
	public Language language;

	public string[] strings;

	public static LanguageModification import(Language language, string[] strings)
	{
		return new LanguageModification
		{
			language = language,
			strings = strings
		};
	}
}
