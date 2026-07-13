using System;

namespace MP3Randomizer;

public class Item
{
	public byte[] item_type;

	public byte[] capacity;

	public byte[] percent;

	public byte[] amount;

	public byte[] model;

	public byte[] pickup_effect;

	public byte[] character;

	public byte[] default_animation;

	public byte[] scan;

	public byte[] memo;

	public byte[] streamed_audio;

	public bool is_progressive;

	public ItemType[] progressive_item_types;

	public ushort[] progressive_ids;

	public byte[] conversion_start_type;

	public ushort[] conversion_start_ids;

	public byte[] conversion_end_type;

	public ushort[] conversion_end_ids;

	public static Item get_item_data(ItemName mp3_item_name)
	{
		Item item = new Item();
		switch (mp3_item_name)
		{
		case ItemName.PlasmaBeam:
			item.item_type = new byte[4] { 147, 173, 109, 249 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.default_animation = new byte[4];
			item.character = new byte[8] { 32, 164, 205, 196, 102, 215, 211, 153 };
			item.scan = new byte[8] { 83, 76, 93, 112, 254, 127, 53, 110 };
			item.memo = new byte[8] { 192, 186, 112, 200, 195, 12, 251, 200 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ProgressiveBeam:
			item.item_type = new byte[4] { 255, 255, 255, 255 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.default_animation = new byte[4];
			item.character = new byte[8] { 32, 164, 205, 196, 102, 215, 211, 153 };
			item.scan = new byte[8] { 83, 76, 93, 112, 254, 127, 53, 110 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 9 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = true;
			item.progressive_item_types = new ItemType[2]
			{
				ItemType.create_item_type(new byte[4] { 147, 173, 109, 249 }),
				ItemType.create_item_type(new byte[4] { 80, 160, 170, 165 })
			};
			item.progressive_ids = new ushort[4] { 60928, 60929, 60930, 60931 };
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.NovaBeam:
			item.item_type = new byte[4] { 80, 160, 170, 165 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 189, 158, 215, 156, 58, 85, 147, 131 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 117, 165, 179, 198, 161, 65, 225, 117 };
			item.memo = new byte[8] { 248, 171, 174, 97, 204, 66, 201, 79 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ChargeUpgrade:
			item.item_type = new byte[4] { 53, 72, 133, 32 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 89, 204, 127, 51, 155, 107, 191, 104 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 37, 43, 181, 245, 94, 139, 30, 246 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 0 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.MissileExpansion:
			item.item_type = new byte[4] { 146, 45, 166, 168 };
			item.capacity = new byte[4] { 0, 0, 0, 5 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 5 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 39, 208, 166, 180, 63, 119, 33, 75 };
			item.character = new byte[8] { 48, 139, 90, 59, 148, 137, 144, 55 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 22, 215, 159, 130, 51, 98, 23, 79 };
			item.memo = new byte[8] { 75, 79, 157, 196, 37, 56, 98, 202 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.MainRequiredMissileExpansion:
			item.item_type = new byte[4] { 34, 57, 15, 38 };
			item.capacity = new byte[4] { 0, 0, 0, 5 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 5 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 39, 208, 166, 180, 63, 119, 33, 75 };
			item.character = new byte[8] { 48, 139, 90, 59, 148, 137, 144, 55 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 22, 215, 159, 130, 51, 98, 23, 79 };
			item.memo = new byte[8] { 75, 79, 157, 196, 37, 56, 98, 202 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[4] { 34, 57, 15, 38 };
			item.conversion_start_ids = new ushort[4] { 60944, 60945, 60946, 60947 };
			item.conversion_end_type = new byte[4] { 146, 45, 166, 168 };
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ConverterMissileLauncher:
			item.item_type = new byte[4] { 146, 45, 166, 168 };
			item.capacity = new byte[4] { 0, 0, 0, 5 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 5 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 28, 81, 162, 105, 161, 104, 186, 7 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 120, 204, 26, 101, 3, 247, 26, 183 };
			item.memo = new byte[8] { 52, 196, 56, 36, 52, 114, 208, 244 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[4] { 34, 57, 15, 38 };
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[4] { 146, 45, 166, 168 };
			item.conversion_end_ids = new ushort[4] { 60936, 60937, 60938, 60939 };
			break;
		case ItemName.MissileLauncher:
			item.item_type = new byte[4] { 146, 45, 166, 168 };
			item.capacity = new byte[4] { 0, 0, 0, 5 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 5 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 28, 81, 162, 105, 161, 104, 186, 7 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 120, 204, 26, 101, 3, 247, 26, 183 };
			item.memo = new byte[8] { 52, 196, 56, 36, 52, 114, 208, 244 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.IceMissile:
			item.item_type = new byte[4] { 144, 240, 206, 212 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 85, 42, 183, 134, 137, 160, 249, 136 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 233, 196, 57, 188, 84, 79, 60, 38 };
			item.memo = new byte[8] { 22, 58, 2, 241, 89, 63, 120, 170 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ProgressiveMissile:
			item.item_type = new byte[4] { 255, 255, 255, 255 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 85, 42, 183, 134, 137, 160, 249, 136 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 233, 196, 57, 188, 84, 79, 60, 38 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 8 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = true;
			item.progressive_item_types = new ItemType[2]
			{
				ItemType.create_item_type(new byte[4] { 144, 240, 206, 212 }),
				ItemType.create_item_type(new byte[4] { 183, 244, 231, 109 })
			};
			item.progressive_ids = new ushort[4] { 60932, 60933, 60934, 60935 };
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.SeekerMissile:
			item.item_type = new byte[4] { 183, 244, 231, 109 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 89, 197, 244, 163, 7, 134, 194, 146 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 152, 178, 226, 6, 91, 129, 238, 154 };
			item.memo = new byte[8] { 185, 110, 109, 105, 174, 129, 90, 27 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.GrappleLasso:
			item.item_type = new byte[4] { 113, 155, 92, 93 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 67, 132, 233, 154, 234, 173, 116, 245 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 47, 117, 83, 174, 244, 240, 225, 199 };
			item.memo = new byte[8] { 195, 149, 21, 242, 109, 86, 128, 65 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.GrappleSwing:
			item.item_type = new byte[4] { 31, 41, 80, 220 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 110, 190, 202, 103, 167, 116, 111, 254 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 34, 200, 76, 81, 229, 143, 136, 238 };
			item.memo = new byte[8] { 155, 116, 25, 52, 204, 31, 23, 58 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.GrappleVoltage:
			item.item_type = new byte[4] { 31, 246, 71, 17 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 31, 179, 136, 19, 197, 235, 163, 254 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 165, 163, 66, 255, 109, 60, 67, 211 };
			item.memo = new byte[8] { 183, 39, 252, 92, 7, 94, 157, 77 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.Bomb:
			item.item_type = new byte[4] { 185, 135, 108, 209 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 240, 201, 76, 87, 223, 108, 103, 158 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 94, 192, 167, 29, 148, 26, 115, 7 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 1 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.CombatVisor:
			item.item_type = new byte[4] { 150, 102, 78, 151 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 254, 31, 92, 250, 37, 111, 114, 198 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 7, 48, 252, 7, 154, 153, 29, 55 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 2 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ScanVisor:
			item.item_type = new byte[4] { 179, 202, 220, 71 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 120, 238, 224, 117, 78, 4, 156, 101 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 178, 166, 71, 19, 191, 96, 188, 88 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 3 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.CommandVisor:
			item.item_type = new byte[4] { 115, 214, 116, 234 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 93, 79, 134, 221, 14, 197, 44, 247 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 161, 135, 52, 31, 199, 50, 95, 244 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 4 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.XRayVisor:
			item.item_type = new byte[4] { 102, 43, 35, 90 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 243, 10, 32, 154, 170, 57, 12, 1 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 76, 165, 248, 22, 109, 43, 206, 67 };
			item.memo = new byte[8] { 151, 145, 186, 231, 44, 45, 102, 32 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.SpaceJump:
			item.item_type = new byte[4] { 149, 192, 5, 42 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.character = new byte[8] { 189, 219, 7, 113, 216, 230, 255, 16 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 90, 243, 23, 43, 71, 6, 53, 65 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 5 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ScrewAttack:
			item.item_type = new byte[4] { 217, 205, 158, 222 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 206, 175, 6, 226, 10, 151, 123, 12 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 242, 61, 137, 113, 182, 119, 153, 182 };
			item.memo = new byte[8] { 135, 46, 251, 114, 225, 40, 108, 50 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.Suit:
			item.item_type = new byte[4] { 208, 43, 10, 216 };
			item.capacity = new byte[4] { 0, 0, 0, 5 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 5 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 38, 119, 83, 184, 241, 111, 226, 151 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 50, 41, 9, 88, 142, 138, 241, 32 };
			item.memo = new byte[8] { 191, 207, 232, 173, 101, 134, 122, 136 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.EnergyTank:
			item.item_type = new byte[4] { 179, 106, 236, 221 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 213, 161, 253, 73, 23, 151, 236, 101 };
			item.character = new byte[8] { 119, 142, 26, 186, 16, 217, 185, 224 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 148, 72, 94, 208, 16, 43, 203, 52 };
			item.memo = new byte[8] { 149, 125, 109, 243, 155, 113, 195, 37 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.Fuse1:
		case ItemName.Fuse2:
		case ItemName.Fuse3:
		case ItemName.Fuse4:
		case ItemName.Fuse5:
		case ItemName.Fuse6:
		case ItemName.Fuse7:
		case ItemName.Fuse8:
		case ItemName.Fuse9:
			switch (mp3_item_name)
			{
			case ItemName.Fuse1:
				item.item_type = new byte[4] { 51, 110, 108, 146 };
				break;
			case ItemName.Fuse2:
				item.item_type = new byte[4] { 170, 103, 61, 40 };
				break;
			case ItemName.Fuse3:
				item.item_type = new byte[4] { 221, 96, 13, 190 };
				break;
			case ItemName.Fuse4:
				item.item_type = new byte[4] { 67, 4, 152, 29 };
				break;
			case ItemName.Fuse5:
				item.item_type = new byte[4] { 52, 3, 168, 139 };
				break;
			case ItemName.Fuse6:
				item.item_type = new byte[4] { 173, 10, 249, 49 };
				break;
			case ItemName.Fuse7:
				item.item_type = new byte[4] { 218, 13, 201, 167 };
				break;
			case ItemName.Fuse8:
				item.item_type = new byte[4] { 74, 178, 212, 54 };
				break;
			case ItemName.Fuse9:
				item.item_type = new byte[4] { 61, 181, 228, 160 };
				break;
			}
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 49, 239, 21, 81, 175, 13, 48, 216 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.default_animation = new byte[4] { 255, 255, 255, 255 };
			item.scan = new byte[8] { 53, 201, 82, 129, 236, 65, 210, 77 };
			item.memo = new byte[8] { 13, 101, 76, 76, 204, 129, 205, 115 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.MorphBall:
			item.item_type = new byte[4] { 72, 47, 130, 53 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 215, 217, 255, 69, 126, 51, 169, 55 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 225, 177, 201, 132, 118, 84, 7, 219 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 6 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.BoostBall:
			item.item_type = new byte[4] { 178, 27, 184, 199 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 1, 122, 219, 176, 229, 244, 137, 21 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 219, 30, 168, 74, 124, 162, 216, 252 };
			item.memo = new byte[8] { 162, 141, 243, 90, 249, 99, 24, 14 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.SpiderBall:
			item.item_type = new byte[4] { 77, 65, 87, 82 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 179, 68, 163, 152, 69, 148, 253, 62 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 108, 192, 236, 182, 248, 74, 36, 86 };
			item.memo = new byte[8] { 228, 172, 41, 184, 244, 38, 200, 92 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.HyperModeTank:
			item.item_type = new byte[4] { 85, 104, 184, 201 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 30, 117, 191, 109, 231, 83, 29, 94 };
			item.default_animation = new byte[4] { 0, 0, 0, 1 };
			item.scan = new byte[8] { 153, 195, 43, 122, 55, 35, 154, 121 };
			item.memo = new byte[8] { 171, 205, 171, 205, 171, 205, 0, 7 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.HyperBall:
			item.item_type = new byte[4] { 140, 72, 71, 171 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 109, 238, 25, 162, 199, 186, 17, 11 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 246, 133, 190, 16, 218, 5, 153, 255 };
			item.memo = new byte[8] { 145, 187, 68, 43, 34, 53, 181, 160 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.HyperMissile:
			item.item_type = new byte[4] { 81, 85, 86, 160 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 165, 83, 76, 179, 158, 232, 217, 15 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 9, 181, 16, 141, 20, 90, 87, 22 };
			item.memo = new byte[8] { 33, 195, 46, 216, 80, 135, 184, 201 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.HyperGrapple:
			item.item_type = new byte[4] { 135, 86, 8, 69 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 246, 156, 102, 88, 15, 20, 230, 70 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 78, 246, 164, 7, 245, 171, 34, 111 };
			item.memo = new byte[8] { 154, 46, 230, 150, 227, 71, 136, 183 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ShipMissile:
			item.item_type = new byte[4] { 129, 161, 83, 255 };
			item.capacity = new byte[4] { 0, 0, 0, 3 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 3 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 39, 208, 166, 180, 63, 119, 33, 75 };
			item.character = new byte[8] { 165, 13, 203, 239, 76, 122, 142, 65 };
			item.default_animation = new byte[4] { 255, 255, 255, 255 };
			item.scan = new byte[8] { 104, 182, 142, 188, 179, 239, 143, 73 };
			item.memo = new byte[8] { 252, 117, 199, 73, 75, 55, 230, 6 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ConverterShipMissile:
			item.item_type = new byte[4] { 129, 161, 83, 255 };
			item.capacity = new byte[4] { 0, 0, 0, 3 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 3 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 39, 208, 166, 180, 63, 119, 33, 75 };
			item.character = new byte[8] { 165, 13, 203, 239, 76, 122, 142, 65 };
			item.default_animation = new byte[4] { 255, 255, 255, 255 };
			item.scan = new byte[8] { 104, 182, 142, 188, 179, 239, 143, 73 };
			item.memo = new byte[8] { 252, 117, 199, 73, 75, 55, 230, 6 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[4] { 56, 190, 76, 66 };
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[4] { 129, 161, 83, 255 };
			item.conversion_end_ids = new ushort[4] { 60940, 60941, 60942, 60943 };
			break;
		case ItemName.ShipMissileExpansion:
			item.item_type = new byte[4] { 129, 161, 83, 255 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 39, 208, 166, 180, 63, 119, 33, 75 };
			item.character = new byte[8] { 119, 136, 16, 83, 26, 62, 130, 42 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 219, 242, 248, 124, 42, 71, 185, 125 };
			item.memo = new byte[8] { 148, 160, 234, 79, 68, 127, 166, 225 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.MainRequiredShipMissileExpansion:
			item.item_type = new byte[4] { 56, 190, 76, 66 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 39, 208, 166, 180, 63, 119, 33, 75 };
			item.character = new byte[8] { 119, 136, 16, 83, 26, 62, 130, 42 };
			item.default_animation = new byte[4];
			item.scan = new byte[8] { 219, 242, 248, 124, 42, 71, 185, 125 };
			item.memo = new byte[8] { 148, 160, 234, 79, 68, 127, 166, 225 };
			item.streamed_audio = new byte[8] { 168, 50, 252, 12, 116, 101, 31, 36 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[4] { 56, 190, 76, 66 };
			item.conversion_start_ids = new ushort[4] { 60948, 60949, 60950, 60951 };
			item.conversion_end_type = new byte[4] { 129, 161, 83, 255 };
			item.conversion_end_ids = new ushort[0];
			break;
		case ItemName.ShipGrapple:
			item.item_type = new byte[4] { 87, 162, 13, 26 };
			item.capacity = new byte[4] { 0, 0, 0, 1 };
			item.percent = new byte[4] { 0, 0, 0, 1 };
			item.amount = new byte[4] { 0, 0, 0, 1 };
			item.model = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
			item.pickup_effect = new byte[8] { 107, 203, 186, 121, 44, 234, 67, 50 };
			item.character = new byte[8] { 72, 71, 87, 123, 23, 29, 192, 135 };
			item.default_animation = new byte[4] { 255, 255, 255, 255 };
			item.scan = new byte[8] { 103, 230, 52, 4, 252, 251, 19, 190 };
			item.memo = new byte[8] { 242, 85, 167, 4, 206, 96, 167, 153 };
			item.streamed_audio = new byte[8] { 229, 149, 150, 228, 252, 132, 162, 155 };
			item.is_progressive = false;
			item.progressive_item_types = new ItemType[0];
			item.progressive_ids = new ushort[0];
			item.conversion_start_type = new byte[0];
			item.conversion_start_ids = new ushort[0];
			item.conversion_end_type = new byte[0];
			item.conversion_end_ids = new ushort[0];
			break;
		default:
			throw new ArgumentException("Unsupported item: " + mp3_item_name);
		}
		return item;
	}
}
