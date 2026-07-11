namespace MP3Randomizer;

public abstract class MLVL
{
	public readonly byte[] MAGIC = new byte[4] { 222, 175, 186, 190 };

	public readonly byte[] UNKNOWN_SCLY = new byte[1];

	public AreaLayerFlags[] layer_flags;

	public uint[] layer_name_offsets;

	public string[] layer_names;

	public abstract void import(byte[] mlvl_data);

	public abstract byte[] export();

	public void change_bit_flags(LayerTogglePatch[] layer_toggle_patches)
	{
		foreach (LayerTogglePatch layerTogglePatch in layer_toggle_patches)
		{
			uint[] bits_to_activate = layerTogglePatch.bits_to_activate;
			foreach (uint num in bits_to_activate)
			{
				layer_flags[layerTogglePatch.area_index].layer_flags[num] = true;
			}
			bits_to_activate = layerTogglePatch.bits_to_deactivate;
			foreach (uint num2 in bits_to_activate)
			{
				layer_flags[layerTogglePatch.area_index].layer_flags[num2] = false;
			}
		}
	}
}
