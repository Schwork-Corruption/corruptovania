using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class DependencyHandler
{
	public static byte[] add_dependencies(byte[] dependency_data, List<Dependency> dependency_list)
	{
		BinaryArrayReader binaryArrayReader = new BinaryArrayReader(dependency_data);
		uint num = Conversion.b_to_u32(binaryArrayReader.read_and_append(4u));
		uint num2 = 0u;
		for (uint num3 = 0u; num3 < num; num3++)
		{
			binaryArrayReader.read_and_append(12u);
		}
		foreach (Dependency item in dependency_list)
		{
			if (Encoding.UTF8.GetString(item.resource_type) != "STRM")
			{
				num2++;
				binaryArrayReader.append_to_list(Conversion.u64_to_8b(item.file_id));
				binaryArrayReader.append_to_list(item.resource_type);
			}
		}
		Conversion.b_to_u32(binaryArrayReader.read_and_append(4u));
		binaryArrayReader.read_and_append_remainder();
		byte[] array = Conversion.u32_to_4b(num + num2);
		binaryArrayReader.output_list[0] = array[0];
		binaryArrayReader.output_list[1] = array[1];
		binaryArrayReader.output_list[2] = array[2];
		binaryArrayReader.output_list[3] = array[3];
		return binaryArrayReader.output_list.ToArray();
	}
}
