using System.Collections.Generic;

namespace MP3Randomizer;

public class ScriptPartData
{
	public static Dictionary<uint, ScriptPart> get_all_parts()
	{
		List<ScriptPart> list = new List<ScriptPart>();
		list.Add(ScriptPart.import(new byte[4] { 37, 90, 69, 128 }, new byte[2] { 0, 69 }, "struct", new byte[0], new uint[4] { 1229865293u, 1481003597u, 1094931542u, 1563003459u }));
		list.Add(ScriptPart.import(new byte[4] { 73, 78, 65, 77 }, new byte[2] { 0, 2 }, "property", new byte[2] { 71, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 88, 70, 82, 77 }, new byte[2] { 0, 36 }, "property", new byte[36]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 65, 67, 84, 86 }, new byte[2] { 0, 1 }, "property", new byte[1] { 1 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 93, 41, 138, 67 }, new byte[2] { 0, 4 }, "property", new byte[4] { 0, 0, 0, 3 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 68, 51, 90, 255 }, new byte[2] { 0, 4 }, "property", new byte[4] { 60, 35, 215, 10 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 58, 211, 155, 49 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 50, 23, 223, 248 }, new byte[2] { 0, 1 }, "property", new byte[1] { 1 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 237, 164, 127, 246 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 49, 236, 20, 188 }, new byte[2] { 0, 8 }, "property", new byte[8] { 254, 220, 186, 170, 171, 172, 173, 174 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 255, 93, 153, 126 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 184, 175, 207, 33 }, new byte[2] { 0, 4 }, "property", new byte[4] { 152, 197, 174, 215 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 157, 122, 87, 109 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 25, 2, 128, 153 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 44, 147, 170, 245 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 231, 207, 121, 80 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 250, 202, 73, 232 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 167, 52, 248, 165 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 181, 129, 87, 75 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 63, 161, 100, 188 }, new byte[2] { 0, 4 }, "property", new byte[4] { 251, 115, 242, 184 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 94, 207, 143, 103 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 216, 91, 253, 201 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 19, 7, 46, 108 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 130, 94, 30, 20 }, new byte[2] { 0, 4 }, "property", new byte[4] { 204, 29, 252, 245 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 224, 193, 120, 4 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 71, 75, 204, 227 }, new byte[2] { 0, 4 }, "property", new byte[4] { 249, 200, 133, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 169, 73, 101, 81 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 187, 239, 77, 13 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 204, 239, 198, 24 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 5, 1, 76, 97 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 249, 239, 85, 212 }, new byte[2] { 0, 15 }, "property", new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 255, 127, 255,
			255, 127, 127, 255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 60, 121, 225, 33 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 142, 113, 135, 36 }, new byte[2] { 0, 15 }, "property", new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 255, 127, 255,
			255, 127, 127, 255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 108, 23, 109, 214 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 145, 130, 37, 12 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 197, 64, 130, 232 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 217, 178, 57, 79 }, new byte[2] { 0, 4 }, "property", new byte[4] { 60, 35, 215, 10 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 53, 53, 130, 189 }, new byte[2] { 0, 4 }, "property", new byte[4] { 65, 0, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 25, 110, 23, 217 }, new byte[2] { 0, 4 }, "property", new byte[4] { 64, 0, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 178, 143, 55, 177 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 161, 196, 231, 248 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 121, 205, 165, 124 }, new byte[2] { 0, 4 }, "property", new byte[4] { 64, 160, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 11, 82, 64, 227 }, new byte[2] { 0, 4 }, "property", new byte[4] { 64, 0, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 113, 120, 103, 17 }, new byte[2] { 0, 4 }, "property", new byte[4] { 64, 64, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 46, 38, 112, 45 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 83, 150, 58, 104 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 78, 191, 118, 13 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 97, 147, 5, 115 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 93, 126, 121, 161 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 187, 82, 4, 200 }, new byte[2] { 0, 12 }, "property", new byte[12]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 183, 220, 208, 202 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 4, 208, 62, 65 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 199, 167, 241, 137 }, new byte[2] { 0, 4 }, "property", new byte[4] { 63, 128, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 223, 67, 83, 163 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 141, 255, 86, 116 }, new byte[2] { 0, 8 }, "property", new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 49, 250, 31, 224 }, new byte[2] { 0, 4 }, "property", new byte[4] { 63, 128, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 234, 89, 50, 148 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 86, 87, 202, 28 }, new byte[2] { 0, 1 }, "property", new byte[1] { 1 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 189, 106, 64, 109 }, new byte[2] { 0, 4 }, "property", new byte[4] { 64, 160, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 88, 43, 132, 168 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 54, 150, 59, 204 }, new byte[2] { 0, 1 }, "property", new byte[1] { 1 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 167, 138, 192, 192 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 128, 198, 108, 55 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 225, 255, 79, 4 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 173, 158, 183, 127 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 124, 38, 158, 188 }, new byte[2] { 0, 4 }, "property", new byte[4] { 63, 128, 0, 0 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 130, 73, 246, 199 }, new byte[2] { 0, 24 }, "property", new byte[24]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255
		}, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 18, 167, 216, 178 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 234, 215, 183, 187 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 206, 193, 105, 50 }, new byte[2] { 0, 66 }, "struct", new byte[0], new uint[7] { 3728621731u, 2035260395u, 3551497586u, 62778008u, 1886557028u, 2931201204u, 2377726346u }));
		list.Add(ScriptPart.import(new byte[4] { 231, 9, 221, 192 }, new byte[2] { 0, 66 }, "struct", new byte[0], new uint[7] { 3728621731u, 2035260395u, 3551497586u, 62778008u, 1886557028u, 2931201204u, 2377726346u }));
		list.Add(ScriptPart.import(new byte[4] { 73, 97, 76, 81 }, new byte[2] { 0, 66 }, "struct", new byte[0], new uint[7] { 3728621731u, 2035260395u, 3551497586u, 62778008u, 1886557028u, 2931201204u, 2377726346u }));
		list.Add(ScriptPart.import(new byte[4] { 180, 152, 180, 36 }, new byte[2] { 0, 66 }, "struct", new byte[0], new uint[7] { 3728621731u, 2035260395u, 3551497586u, 62778008u, 1886557028u, 2931201204u, 2377726346u }));
		list.Add(ScriptPart.import(new byte[4] { 222, 62, 64, 163 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 121, 79, 155, 235 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 211, 175, 141, 114 }, new byte[2] { 0, 4 }, "property", new byte[4] { 251, 115, 242, 184 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 3, 189, 234, 152 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 112, 114, 147, 100 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 174, 182, 148, 180 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 141, 185, 57, 138 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 68, 219, 138, 242 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 44, 197, 78, 119 }, new byte[2] { 0, 4 }, "property", new byte[4] { 0, 0, 0, 7 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 113, 15, 229, 215 }, new byte[2] { 0, 12 }, "struct", new byte[0], new uint[1] { 1099641890u }));
		list.Add(ScriptPart.import(new byte[4] { 234, 215, 183, 187 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 41, 244, 70, 252 }, new byte[2] { 0, 1 }, "property", new byte[1] { 1 }, new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 199, 49, 174, 97 }, new byte[2] { 0, 1 }, "property", new byte[1], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 252, 130, 127, 99 }, new byte[2] { 0, 4 }, "property", new byte[4], new uint[0]));
		list.Add(ScriptPart.import(new byte[4] { 65, 139, 52, 34 }, new byte[2] { 0, 4 }, "property", new byte[4] { 211, 212, 23, 95 }, new uint[0]));
		Dictionary<uint, ScriptPart> dictionary = new Dictionary<uint, ScriptPart>();
		foreach (ScriptPart item in list)
		{
			dictionary[Conversion.b_to_u32(item.identifier)] = item;
		}
		return dictionary;
	}
}
