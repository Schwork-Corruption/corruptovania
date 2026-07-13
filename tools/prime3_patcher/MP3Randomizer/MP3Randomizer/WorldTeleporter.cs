using System.Collections.Generic;

namespace MP3Randomizer;

public class WorldTeleporter
{
	public static ScriptObject create_world_teleporter(byte[] id, byte[] position, Connection[] the_connections, byte[] world_id, byte[] mrea_id)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("TEL1", id, the_connections);
		uint[] world_teleporter_subproperties = get_world_teleporter_subproperties();
		Dictionary<uint, PropertyValue> dictionary = new Dictionary<uint, PropertyValue>();
		dictionary[1481003597u] = new BPropertyValue(position);
		dictionary[837555388u] = new BPropertyValue(world_id);
		dictionary[3770775556u] = new BPropertyValue(mrea_id);
		dictionary[1813474774u] = new BPropertyValue(Conversion.u64_to_8b(520877543450287337uL));
		dictionary[2441225484u] = new BPropertyValue(Conversion.u64_to_8b(5047729426257305854uL));
		dictionary[1196149987u] = new BPropertyValue(new byte[4] { 249, 200, 133, 255 });
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(world_teleporter_subproperties, dictionary);
		return scriptObject;
	}

	public static uint[] get_world_teleporter_subproperties()
	{
		return ScriptTypeData.get_all_types()["TEL1"].properties;
	}
}
