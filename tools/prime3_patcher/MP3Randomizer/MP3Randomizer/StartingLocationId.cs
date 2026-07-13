using System;

namespace MP3Randomizer;

public class StartingLocationId
{
	public static StartingArea get_starting_location(StartingLocationType starting_location_type, ulong world_id, ulong area_id)
	{
		return starting_location_type switch
		{
			StartingLocationType.Olympus => StartingArea.import(4010992506757754735uL, 3586057064387876334uL), 
			StartingLocationType.Norion => StartingArea.import(8050447300094575427uL, 1594033074927626820uL), 
			StartingLocationType.Valhalla => StartingArea.import(13921744762140409337uL, 15622764306970326849uL), 
			StartingLocationType.Custom => StartingArea.import(world_id, area_id), 
			_ => throw new ArgumentException("Starting location does not have an associated ID"), 
		};
	}
}
