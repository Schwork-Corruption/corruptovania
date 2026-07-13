namespace MP3Randomizer;

public class BinaryConstant
{
	public static byte[] U16_ZERO = new byte[2];

	public static byte[] U32_ZERO = new byte[4];

	public static byte[] U64_ZERO = new byte[8];

	public static byte[] U16_ONE = new byte[2] { 0, 1 };

	public static byte[] U32_ONE = new byte[4] { 0, 0, 0, 1 };

	public static byte[] U64_ONE = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 1 };

	public static byte[] U16_MAX = new byte[2] { 255, 255 };

	public static byte[] U32_MAX = new byte[4] { 255, 255, 255, 255 };

	public static byte[] U64_MAX = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
}
