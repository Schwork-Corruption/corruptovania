using System;

namespace MP3Randomizer;

public class LanguageCC
{
	public static byte[] get_cc(Language language)
	{
		return language switch
		{
			Language.English => Conversion.string_to_b("ENGL", EncodingType.UTF8), 
			Language.German => Conversion.string_to_b("GERM", EncodingType.UTF8), 
			Language.French => Conversion.string_to_b("FREN", EncodingType.UTF8), 
			Language.Spanish => Conversion.string_to_b("SPAN", EncodingType.UTF8), 
			Language.Italian => Conversion.string_to_b("ITAL", EncodingType.UTF8), 
			Language.Dutch => Conversion.string_to_b("DUTC", EncodingType.UTF8), 
			Language.Japanese => Conversion.string_to_b("JAPN", EncodingType.UTF8), 
			_ => throw new ArgumentException("CC not found for language " + language), 
		};
	}
}
