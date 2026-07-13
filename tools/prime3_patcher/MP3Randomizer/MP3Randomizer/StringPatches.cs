using System.Collections.Generic;

namespace MP3Randomizer;

public class StringPatches
{
	public static Dictionary<ulong, Resource> get_string_resources_to_modify(bool add_hyper_hints, string hyper_missile_planet, string hyper_grapple_planet)
	{
		Dictionary<ulong, Resource> dictionary = new Dictionary<ulong, Resource>();
		STRGModification[] array = STRGModificationData.get_strg_modifications(add_hyper_hints, hyper_missile_planet, hyper_grapple_planet);
		foreach (STRGModification sTRGModification in array)
		{
			STRG sTRG = STRG.import();
			LanguageModification[] language_modifications = sTRGModification.language_modifications;
			foreach (LanguageModification languageModification in language_modifications)
			{
				sTRG.add_entry(languageModification.language, languageModification.strings);
			}
			byte[] data = BinaryHelper.pad_to_multiple(sTRG.export(Version.MP3), byte.MaxValue, 64u);
			dictionary[sTRGModification.resource_id] = Resource.to_resource(sTRGModification.resource_id, "STRG", 0u, data);
		}
		return dictionary;
	}
}
