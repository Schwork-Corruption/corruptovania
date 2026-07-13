namespace MP3Randomizer;

public class LayerClearPatch
{
	public ulong[] mrea_ids;

	public uint[] layer_indexes;

	public static LayerClearPatch import(ulong[] mrea_ids, uint[] layer_indexes)
	{
		return new LayerClearPatch
		{
			mrea_ids = mrea_ids,
			layer_indexes = layer_indexes
		};
	}
}
