namespace MP3Randomizer;

public class ScriptLayerHandler
{
	public static byte[] modify_script_layers(byte[] scly_data, Patches patches, uint area_index, ulong mrea_id)
	{
		if (scly_data[2] == 71)
		{
			return scly_data;
		}
		ScriptLayer scriptLayer = ScriptLayer.import(scly_data, area_index);
		patches.apply_patches_to_layer(scriptLayer, area_index, scriptLayer.layer_index, mrea_id);
		scly_data = scriptLayer.export();
		return scly_data;
	}
}
