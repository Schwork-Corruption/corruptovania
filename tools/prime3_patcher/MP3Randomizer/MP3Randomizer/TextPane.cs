using System.Collections.Generic;

namespace MP3Randomizer;

public class TextPane
{
	public static ScriptObject create_text_pane(byte[] id, byte[] position, Connection[] the_connections, byte[] strg_id)
	{
		ScriptObject scriptObject = ScriptBuilder.deal_with_up_to_connections("TXPN", id, the_connections);
		uint[] text_pane_subproperties = get_text_pane_subproperties();
		scriptObject.script_data = ScriptBuilder.deal_with_subproperties(text_pane_subproperties, new Dictionary<uint, PropertyValue> { [3886823719u] = new BPropertyValue(strg_id) });
		return scriptObject;
	}

	public static uint[] get_text_pane_subproperties()
	{
		return ScriptTypeData.get_all_types()["TXPN"].properties;
	}
}
