using System;

namespace MP3Randomizer;

public class Color
{
	public const int NUMBER_OF_COLOR_VALUES = 255;

	public static byte[] get_random_rgba(Random rnd)
	{
		byte[] array = new byte[16];
		for (int i = 0; i < 16; i += 4)
		{
			Buffer.BlockCopy(get_random_color(rnd), 0, array, i, 4);
		}
		return array;
	}

	public static byte[] get_random_color(Random rnd)
	{
		return Conversion.float_to_4b((float)rnd.Next(0, 256) / 255f);
	}
}
