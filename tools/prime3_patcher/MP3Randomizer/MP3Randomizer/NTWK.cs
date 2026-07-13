using System;
using System.IO;

namespace MP3Randomizer;

public class NTWK
{
	public static void modify_ntwk(string orig_tweak_location, string dest_tweak_location)
	{
		Console.WriteLine("Modifying " + orig_tweak_location);
		byte[] b_data = SimpleScriptDataModifier.modify_script_data(File.ReadAllBytes(orig_tweak_location), new PropertyModification[1] { PropertyModification.import(new byte[4] { 25, 104, 107, 246 }, new BPropertyValue(new byte[4] { 66, 32, 0, 0 })) }, 0uL);
		Console.WriteLine("Writing data to " + dest_tweak_location);
		IO.write_b(b_data, dest_tweak_location);
		Console.WriteLine("Finished writing to " + dest_tweak_location + "!");
	}
}
