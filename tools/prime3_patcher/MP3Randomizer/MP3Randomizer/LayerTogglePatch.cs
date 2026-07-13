namespace MP3Randomizer;

public class LayerTogglePatch
{
	public ulong mlvl_id;

	public uint area_index;

	public uint[] bits_to_activate;

	public uint[] bits_to_deactivate;

	public static LayerTogglePatch import(ulong mlvl_id, uint area_index, uint[] bits_to_activate, uint[] bits_to_deactivate)
	{
		return new LayerTogglePatch
		{
			mlvl_id = mlvl_id,
			area_index = area_index,
			bits_to_activate = bits_to_activate,
			bits_to_deactivate = bits_to_deactivate
		};
	}
}
