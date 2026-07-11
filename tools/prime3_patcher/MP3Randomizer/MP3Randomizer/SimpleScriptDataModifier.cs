namespace MP3Randomizer;

public class SimpleScriptDataModifier
{
	public static byte[] modify_script_data(byte[] script_data, PropertyModification[] property_modifications, ulong mrea_id)
	{
		for (int i = 0; i < script_data.Length - 7; i++)
		{
			foreach (PropertyModification propertyModification in property_modifications)
			{
				byte[] property_id = propertyModification.property_id;
				if (script_data[i] == property_id[0] && script_data[i + 1] == property_id[1] && script_data[i + 2] == property_id[2] && script_data[i + 3] == property_id[3])
				{
					byte[] array = propertyModification.get_property_value(script_data, (uint)(i + 6));
					for (int k = 0; k < array.Length; k++)
					{
						script_data[i + k + 6] = array[k];
					}
				}
			}
		}
		return script_data;
	}
}
