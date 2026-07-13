using System;

namespace MP3Randomizer;

public class MLVLFactory
{
	public static MLVL create_mlvl(Version game_version)
	{
		return game_version switch
		{
			Version.MP2 => new MP2MLVL(), 
			Version.MP3 => new MP3MLVL(), 
			_ => throw new ArgumentException("Unsupported game version for MLVL"), 
		};
	}
}
