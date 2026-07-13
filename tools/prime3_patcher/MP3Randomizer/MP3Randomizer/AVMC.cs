using System.Collections.Generic;

namespace MP3Randomizer;

public class AVMC
{
	public static ScriptObject create_avmc(byte[] id, byte[] position, Connection[] the_connections, byte[] world_id, uint area_index)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("AVMC", id, the_connections);
		uint[] avmc_subproperties = get_avmc_subproperties();
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(avmc_subproperties, new Dictionary<uint, PropertyValue>
		{
			[837555388u] = new BPropertyValue(world_id),
			[4284324222u] = new BPropertyValue(Conversion.u32_to_4b(area_index))
		});
		return scriptObject;
	}

	public static uint[] get_avmc_subproperties()
	{
		return ScriptTypeData.get_all_types()["AVMC"].properties;
	}
}
