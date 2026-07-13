using System;
using System.Collections.Generic;

namespace MP3Randomizer;

public class STRG
{
	private readonly byte[] MAGIC = new byte[4] { 135, 101, 67, 33 };

	private Dictionary<Language, string[]> language_strings;

	private Dependency[] dependencies = new Dependency[0];

	public static STRG import(Dictionary<Language, string[]> language_strings, Dependency[] dependencies)
	{
		return new STRG
		{
			language_strings = language_strings,
			dependencies = dependencies
		};
	}

	public static STRG import()
	{
		return new STRG
		{
			language_strings = new Dictionary<Language, string[]>(),
			dependencies = new Dependency[0]
		};
	}

	public void add_entry(Language language, string[] string_data)
	{
		language_strings[language] = string_data;
	}

	public uint get_number_of_strings_per_language(Language[] used_languages)
	{
		if (used_languages.Length == 0)
		{
			return 0u;
		}
		return (uint)language_strings[used_languages[0]].Length;
	}

	public Language[] get_used_languages()
	{
		List<Language> list = new List<Language>();
		foreach (Language value in Enum.GetValues(typeof(Language)))
		{
			if (language_strings.ContainsKey(value))
			{
				list.Add(value);
			}
		}
		return list.ToArray();
	}

	public byte[] export(Version game_type)
	{
		List<byte> list = new List<byte>();
		if (game_type != Version.MP3)
		{
			throw new ArgumentException("Game version currently not supported for STRG: " + game_type);
		}
		uint num = 0u;
		num = game_type switch
		{
			Version.MP3 => 3u, 
			Version.MP2 => 1u, 
			_ => throw new ArgumentException("Game version not supported for STRG: " + game_type), 
		};
		Language[] used_languages = get_used_languages();
		uint num2 = get_number_of_strings_per_language(used_languages);
		byte[] u64_ZERO = BinaryConstant.U64_ZERO;
		List<byte> list2 = new List<byte>();
		List<byte> list3 = new List<byte>();
		Language[] array = used_languages;
		foreach (Language key in array)
		{
			byte[][] array2 = Conversion.to_null_terminated(language_strings[key], EncodingType.UTF8);
			uint num3 = 0u;
			byte[][] array3 = array2;
			foreach (byte[] array4 in array3)
			{
				num3 += (uint)array4.Length;
			}
			list2.AddRange(Conversion.u32_to_4b(num3));
			array3 = array2;
			foreach (byte[] array5 in array3)
			{
				list2.AddRange(Conversion.u32_to_4b((uint)list3.Count));
				list3.AddRange(Conversion.u32_to_4b((uint)array5.Length));
				list3.AddRange(array5);
			}
		}
		list.AddRange(MAGIC);
		list.AddRange(Conversion.u32_to_4b(num));
		list.AddRange(Conversion.u32_to_4b((uint)used_languages.Length));
		list.AddRange(Conversion.u32_to_4b(num2));
		list.AddRange(u64_ZERO);
		array = used_languages;
		foreach (Language language in array)
		{
			list.AddRange(LanguageCC.get_cc(language));
		}
		list.AddRange(list2.ToArray());
		list.AddRange(list3.ToArray());
		return list.ToArray();
	}
}
