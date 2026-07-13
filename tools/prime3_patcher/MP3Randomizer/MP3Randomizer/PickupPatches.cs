using System.Collections.Generic;

namespace MP3Randomizer;

public class PickupPatches
{
	public static void add_pickup_patches(Patches patches, PickupLocation[] pickup_locations, ItemName[] item_list, bool require_launcher, bool require_ship_missile, Dictionary<ulong, Dependency[]> file_dependencies)
	{
		PickupLocation pickupLocation = new PickupLocation();
		Dictionary<ulong, List<byte[]>> dictionary = new Dictionary<ulong, List<byte[]>>();
		Dictionary<ulong, List<byte[]>> dictionary2 = new Dictionary<ulong, List<byte[]>>();
		for (int i = 1; i < 100; i++)
		{
			for (int j = 0; j < pickup_locations.Length; j++)
			{
				if (pickup_locations[j].item_index != i)
				{
					continue;
				}
				pickupLocation = pickup_locations[j];
				if (!dictionary2.ContainsKey(pickupLocation.mrea_id))
				{
					dictionary2[pickupLocation.mrea_id] = new List<byte[]>();
				}
				if (!dictionary.ContainsKey(pickupLocation.mrea_id))
				{
					dictionary[pickupLocation.mrea_id] = new List<byte[]>();
				}
				Item item = Item.get_item_data(item_list[j]);
				List<byte> list = new List<byte>();
				byte[] character = item.character;
				foreach (byte item2 in character)
				{
					list.Add(item2);
				}
				character = item.default_animation;
				foreach (byte item3 in character)
				{
					list.Add(item3);
				}
				byte[] property_value = list.ToArray();
				if (!patches.dependency_patches.ContainsKey(pickupLocation.mrea_id))
				{
					patches.dependency_patches[pickupLocation.mrea_id] = new List<Dependency>();
				}
				MP3Dependencies.add_unique_dependencies(patches.dependency_patches[pickupLocation.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.streamed_audio), "STRM"));
				MP3Dependencies.add_unique_dependencies(patches.dependency_patches[pickupLocation.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.memo), "STRG"));
				if (pickupLocation.type == "Pickup")
				{
					if (Conversion.b_to_u64(item.model) != ulong.MaxValue)
					{
						MP3Dependencies.add_unique_dependencies(patches.dependency_patches[pickupLocation.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.model), "CMDL"));
					}
					if (Conversion.b_to_u64(item.pickup_effect) != ulong.MaxValue)
					{
						MP3Dependencies.add_unique_dependencies(patches.dependency_patches[pickupLocation.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.pickup_effect), "PART"));
					}
					if (Conversion.b_to_u64(item.character) != ulong.MaxValue)
					{
						MP3Dependencies.add_unique_dependencies(patches.dependency_patches[pickupLocation.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.character), "CHAR"));
					}
					if (Conversion.b_to_u64(item.scan) != ulong.MaxValue)
					{
						MP3Dependencies.add_unique_dependencies(patches.dependency_patches[pickupLocation.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.scan), "SCAN"));
					}
					patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "PCKP" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.instance_id) }, new PropertyModification[7]
					{
						PropertyModification.import(new byte[4] { 160, 46, 240, 196 }, new BPropertyValue(item.item_type)),
						PropertyModification.import(new byte[4] { 40, 199, 27, 84 }, new BPropertyValue(item.capacity)),
						PropertyModification.import(new byte[4] { 148, 175, 20, 69 }, new BPropertyValue(item.amount)),
						PropertyModification.import(new byte[4] { 194, 127, 250, 143 }, new BPropertyValue(item.model)),
						PropertyModification.import(new byte[4] { 162, 68, 201, 216 }, new BPropertyValue(property_value)),
						PropertyModification.import(new byte[4] { 185, 78, 155, 231 }, new BPropertyValue(item.scan)),
						PropertyModification.import(new byte[4] { 169, 254, 135, 42 }, new BPropertyValue(item.pickup_effect))
					}));
					patches.dependency_patches[pickupLocation.mrea_id] = MP3Dependencies.order_dependencies(file_dependencies, patches.dependency_patches[pickupLocation.mrea_id]);
				}
				else
				{
					patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "SPFN" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.instance_id) }, new PropertyModification[3]
					{
						PropertyModification.import(new byte[4] { 184, 175, 207, 33 }, new BPropertyValue(new byte[4] { 150, 171, 97, 48 })),
						PropertyModification.import(new byte[4] { 181, 129, 87, 75 }, new BPropertyValue(new byte[4] { 0, 0, 0, 1 })),
						PropertyModification.import(new byte[4] { 63, 161, 100, 188 }, new BPropertyValue(new byte[4] { 80, 73, 155, 67 }))
					}));
					patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "PCKP" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.percentage_pickup_id) }, new PropertyModification[3]
					{
						PropertyModification.import(new byte[4] { 160, 46, 240, 196 }, new BPropertyValue(item.item_type)),
						PropertyModification.import(new byte[4] { 40, 199, 27, 84 }, new BPropertyValue(item.capacity)),
						PropertyModification.import(new byte[4] { 148, 175, 20, 69 }, new BPropertyValue(item.amount))
					}));
					patches.dependency_patches[pickupLocation.mrea_id] = MP3Dependencies.order_dependencies(file_dependencies, patches.dependency_patches[pickupLocation.mrea_id]);
				}
				patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "STAU" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.streamed_audio_id) }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 157, 26, 103, 168 }, new BPropertyValue(item.streamed_audio)) }));
				patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "MEMO" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.memo_id) }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 145, 130, 37, 12 }, new BPropertyValue(item.memo)) }));
				if (pickupLocation.should_modify_hud_type)
				{
					patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "MEMO" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.memo_id) }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 74, 179, 185, 91 }, new BPropertyValue(new byte[4])) }));
					if (pickupLocation.type == "SpecialFunction")
					{
						patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[1] { "MEMO" }, new uint[1] { pickupLocation.scly_section }, new uint[1] { Conversion.b_to_u16(pickupLocation.memo_id) }, new PropertyModification[2]
						{
							PropertyModification.import(new byte[4] { 43, 78, 41, 12 }, new BPropertyValue(new byte[4] { 53, 224, 122, 49 })),
							PropertyModification.import(new byte[4] { 26, 38, 193, 204 }, new BPropertyValue(new byte[4] { 64, 64, 0, 0 }))
						}));
					}
				}
				bool flag = false;
				if (item.conversion_start_ids.Length != 0)
				{
					flag = false;
					foreach (byte[] item4 in dictionary[pickupLocation.mrea_id])
					{
						if (item.item_type[0] == item4[0] && item.item_type[1] == item4[1] && item.item_type[2] == item4[2] && item.item_type[3] == item4[3])
						{
							flag = true;
							break;
						}
					}
					if (pickupLocation.percentage_pickup_id.Length != 0)
					{
						if (!pickupLocation.should_modify_hud_type)
						{
							patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.memo_id) }, new Connection[1] { Connection.make_connection("CLOS", "ZERO", Conversion.u16_to_2b(item.conversion_start_ids[0])) }));
						}
						else
						{
							patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.end_relay_id) }, new Connection[1] { Connection.make_connection("RLAY", "ZERO", Conversion.u16_to_2b(item.conversion_start_ids[0])) }));
						}
					}
					else
					{
						patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.instance_id) }, new Connection[1] { Connection.make_connection("ACQU", "ZERO", Conversion.u16_to_2b(item.conversion_start_ids[0])) }));
					}
					if (!flag)
					{
						dictionary[pickupLocation.mrea_id].Add(item.item_type);
						Connection[] the_connections = new Connection[1] { Connection.make_connection("OPEN", "ZERO", Conversion.u16_to_2b(item.conversion_start_ids[1])) };
						ScriptObject scriptObject = ConditionalRelay.create_progressive_conditional_relay(Conversion.u16_to_2b(item.conversion_start_ids[0]), new byte[36]
						{
							0, 0, 0, 0, 61, 252, 211, 91, 0, 0,
							0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, the_connections, item.conversion_end_type);
						Connection[] the_connections2 = new Connection[3]
						{
							Connection.make_connection("OPEN", "ACTN", Conversion.u16_to_2b(item.conversion_start_ids[2])),
							Connection.make_connection("OPEN", "ACTN", Conversion.u16_to_2b(item.conversion_start_ids[3])),
							Connection.make_connection("OPEN", "ZERO", Conversion.u16_to_2b(item.conversion_start_ids[1]))
						};
						ScriptObject scriptObject2 = ConditionalRelay.create_main_required_conditional_relay(Conversion.u16_to_2b(item.conversion_start_ids[1]), new byte[36]
						{
							0, 0, 0, 0, 61, 252, 211, 91, 0, 0,
							0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, the_connections2, item.conversion_start_type);
						ScriptObject scriptObject3 = SpecialFunction.create_main_inventory_giver(Conversion.u16_to_2b(item.conversion_start_ids[2]), new byte[36]
						{
							0, 0, 0, 0, 0, 0, 0, 0, 61, 252,
							211, 91, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, new Connection[0], item.conversion_end_type);
						ScriptObject scriptObject4 = SpecialFunction.create_main_inventory_taker(Conversion.u16_to_2b(item.conversion_start_ids[3]), new byte[36]
						{
							0, 0, 0, 0, 0, 0, 0, 0, 63, 11,
							15, 208, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, new Connection[0], item.conversion_start_type);
						patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new uint[1], new ScriptObject[4] { scriptObject, scriptObject2, scriptObject3, scriptObject4 }));
					}
				}
				if (item.conversion_end_ids.Length != 0)
				{
					flag = false;
					foreach (byte[] item5 in dictionary2[pickupLocation.mrea_id])
					{
						if (item.item_type[0] == item5[0] && item.item_type[1] == item5[1] && item.item_type[2] == item5[2] && item.item_type[3] == item5[3])
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						dictionary2[pickupLocation.mrea_id].Add(item.item_type);
						Connection[] the_connections3 = new Connection[3]
						{
							Connection.make_connection("OPEN", "ACTN", Conversion.u16_to_2b(item.conversion_end_ids[1])),
							Connection.make_connection("OPEN", "ACTN", Conversion.u16_to_2b(item.conversion_end_ids[2])),
							Connection.make_connection("OPEN", "ZERO", Conversion.u16_to_2b(item.conversion_end_ids[0]))
						};
						ScriptObject scriptObject5 = ConditionalRelay.create_main_required_conditional_relay(Conversion.u16_to_2b(item.conversion_end_ids[0]), new byte[36]
						{
							0, 0, 0, 0, 61, 252, 211, 91, 0, 0,
							0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, the_connections3, item.conversion_start_type);
						ScriptObject scriptObject6 = SpecialFunction.create_main_inventory_giver(Conversion.u16_to_2b(item.conversion_end_ids[1]), new byte[36]
						{
							0, 0, 0, 0, 0, 0, 0, 0, 61, 252,
							211, 91, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, new Connection[0], item.conversion_end_type);
						ScriptObject scriptObject7 = SpecialFunction.create_main_inventory_taker(Conversion.u16_to_2b(item.conversion_end_ids[2]), new byte[36]
						{
							0, 0, 0, 0, 0, 0, 0, 0, 63, 11,
							15, 208, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
							0, 0, 63, 128, 0, 0
						}, new Connection[0], item.conversion_start_type);
						patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new uint[1], new ScriptObject[3] { scriptObject5, scriptObject6, scriptObject7 }));
					}
					if (pickupLocation.percentage_pickup_id.Length != 0)
					{
						if (!pickupLocation.should_modify_hud_type)
						{
							patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.memo_id) }, new Connection[1] { Connection.make_connection("CLOS", "ZERO", Conversion.u16_to_2b(item.conversion_end_ids[0])) }));
						}
						else
						{
							patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.end_relay_id) }, new Connection[1] { Connection.make_connection("RLAY", "ZERO", Conversion.u16_to_2b(item.conversion_end_ids[0])) }));
						}
					}
					else
					{
						patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.instance_id) }, new Connection[1] { Connection.make_connection("ACQU", "ZERO", Conversion.u16_to_2b(item.conversion_end_ids[0])) }));
					}
				}
				if (!item.is_progressive)
				{
					continue;
				}
				if (pickupLocation.percentage_pickup_id.Length != 0)
				{
					if (!pickupLocation.should_modify_hud_type)
					{
						patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.memo_id) }, new Connection[1] { Connection.make_connection("CLOS", "ZERO", Conversion.u16_to_2b(item.progressive_ids[0])) }));
					}
					else
					{
						patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.end_relay_id) }, new Connection[1] { Connection.make_connection("RLAY", "ZERO", Conversion.u16_to_2b(item.progressive_ids[0])) }));
					}
				}
				else
				{
					patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new string[0], new uint[0], new uint[1] { Conversion.b_to_u16(pickupLocation.instance_id) }, new Connection[1] { Connection.make_connection("ACQU", "ZERO", Conversion.u16_to_2b(item.progressive_ids[0])) }));
				}
				Connection[] the_connections4 = new Connection[2]
				{
					Connection.make_connection("CLOS", "ACTN", Conversion.u16_to_2b(item.progressive_ids[1])),
					Connection.make_connection("OPEN", "ACTN", Conversion.u16_to_2b(item.progressive_ids[2]))
				};
				ScriptObject scriptObject8 = ConditionalRelay.create_progressive_conditional_relay(Conversion.u16_to_2b(item.progressive_ids[0]), new byte[36]
				{
					0, 0, 0, 0, 61, 252, 211, 91, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
					0, 0, 63, 128, 0, 0
				}, the_connections4, item.progressive_item_types[0].item_type);
				ScriptObject scriptObject9 = SpecialFunction.create_inventory_giver(Conversion.u16_to_2b(item.progressive_ids[1]), new byte[36]
				{
					0, 0, 0, 0, 0, 0, 0, 0, 61, 252,
					211, 91, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
					0, 0, 63, 128, 0, 0
				}, new Connection[0], item.progressive_item_types[0].item_type);
				ScriptObject scriptObject10 = SpecialFunction.create_inventory_giver(Conversion.u16_to_2b(item.progressive_ids[2]), new byte[36]
				{
					0, 0, 0, 0, 0, 0, 0, 0, 63, 11,
					15, 208, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
					0, 0, 63, 128, 0, 0
				}, new Connection[0], item.progressive_item_types[1].item_type);
				patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { pickupLocation.mrea_id }, new uint[1], new ScriptObject[3] { scriptObject8, scriptObject9, scriptObject10 }));
			}
		}
	}

	public static void add_special_pickup_patches(Patches patches)
	{
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9908630587780032110uL }, new string[0], new uint[1], new uint[2] { 321u, 244u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 7486162873388959747uL }, new string[0], new uint[1], new uint[5] { 50u, 132u, 15u, 43u, 41u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 7486162873388959747uL }, new string[0], new uint[1], new uint[1] { 49u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 55) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1594033074927626820uL }, new string[0], new uint[1], new uint[2] { 1052u, 1078u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1594033074927626820uL }, new string[0], new uint[1] { 16u }, new uint[5] { 1655u, 1063u, 1137u, 1654u, 1324u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1594033074927626820uL }, new string[0], new uint[1], new uint[1] { 1439u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 1594033074927626820uL }, new string[0], new uint[1] { 16u }, new uint[1] { 1139u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 1138) }));
		patches.connection_deletion_patches.Add(ScriptConnectionDeletionPatch.import(new ulong[1] { 1594033074927626820uL }, new string[1] { "SRLY" }, new uint[0], new uint[0], new string[0], new string[1] { "DECR" }, new uint[1] { 381u }));
		patches.connection_modification_patches.Add(ScriptConnectionModificationPatch.import(new ulong[1] { 1594033074927626820uL }, new string[1] { "SQTR" }, new uint[0], new uint[1] { 1458u }, new string[0], new string[1] { "DECR" }, new uint[1] { 381u }, "SQNC", "DECR", new uint[1] { 65535u }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 1594033074927626820uL }, new string[1] { "PCKP" }, new uint[1] { 16u }, new uint[1] { 1140u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 65, 67, 84, 86 }, new BPropertyValue(new byte[1] { 1 })) }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 1594033074927626820uL }, new string[1] { "TIMR" }, new uint[1], new uint[1] { 1617u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 68, 51, 90, 255 }, new BPropertyValue(new byte[4] { 65, 0, 0, 0 })) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 10152623521318090708uL }, new string[0], new uint[1], new uint[2] { 343u, 349u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2833670306022051974uL }, new string[0], new uint[1], new uint[2] { 789u, 787u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 14723609494777816936uL }, new string[0], new uint[1], new uint[2] { 343u, 340u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6692819360230093549uL }, new string[0], new uint[1], new uint[2] { 87u, 91u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 12849086301409571765uL }, new string[0], new uint[1], new uint[1] { 332u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3044064450317642212uL }, new string[0], new uint[1], new uint[2] { 12u, 13u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15622764306970326849uL }, new string[0], new uint[1], new uint[2] { 51u, 55u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13634659891990625058uL }, new string[0], new uint[1], new uint[2] { 21u, 13u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 7265233133801437908uL }, new string[0], new uint[1], new uint[2] { 19u, 3u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4052690289582601366uL }, new string[0], new uint[1], new uint[2] { 357u, 350u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4052690289582601366uL }, new string[0], new uint[1] { 5u }, new uint[2] { 50u, 51u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17479488334200413695uL }, new string[0], new uint[1], new uint[2] { 18u, 16u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9934831212540578712uL }, new string[0], new uint[1], new uint[2] { 123u, 16u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4215957264467390882uL }, new string[0], new uint[1], new uint[2] { 495u, 227u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 691790544662692104uL }, new string[0], new uint[1], new uint[2] { 683u, 673u }));
		patches.connection_deletion_patches.Add(ScriptConnectionDeletionPatch.import(new ulong[1] { 691790544662692104uL }, new string[0], new uint[0], new uint[0], new string[0], new string[0], new uint[2] { 683u, 673u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15732414849243282895uL }, new string[0], new uint[1], new uint[2] { 95u, 97u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15732414849243282895uL }, new string[0], new uint[1], new uint[2] { 526u, 521u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13296637487518400273uL }, new string[0], new uint[1] { 8u }, new uint[2] { 707u, 693u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13296637487518400273uL }, new string[0], new uint[1] { 14u }, new uint[2] { 711u, 621u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15814834557214288722uL }, new string[0], new uint[1], new uint[2] { 87u, 38u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8468936149308094087uL }, new string[0], new uint[1], new uint[2] { 69u, 71u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 928678633548581232uL }, new string[0], new uint[0], new uint[7] { 35u, 26u, 7u, 65u, 49u, 64u, 2u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 928678633548581232uL }, new string[0], new uint[1], new uint[1] { 23u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 30) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8374398449894515797uL }, new string[0], new uint[1], new uint[2] { 328u, 324u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13902157786380317936uL }, new string[0], new uint[1], new uint[2] { 203u, 207u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3467893814575167461uL }, new string[0], new uint[1], new uint[2] { 404u, 407u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 7492844587871276588uL }, new string[0], new uint[1], new uint[2] { 20u, 17u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 7492844587871276588uL }, new string[0], new uint[1], new uint[2] { 373u, 267u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6613311822671481119uL }, new string[0], new uint[1], new uint[2] { 1231u, 1233u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 14006603351279167667uL }, new string[0], new uint[1], new uint[2] { 493u, 492u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 14006603351279167667uL }, new string[0], new uint[1], new uint[1] { 851u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3252687480004049274uL }, new string[0], new uint[1], new uint[2] { 28u, 21u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15861154386655212106uL }, new string[0], new uint[1], new uint[2] { 85u, 86u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18426339925276965129uL }, new string[0], new uint[1], new uint[2] { 149u, 9u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17937850293030639051uL }, new string[0], new uint[1], new uint[2] { 194u, 199u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17945996104959776291uL }, new string[0], new uint[1], new uint[2] { 157u, 56u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 655768186680006563uL }, new string[0], new uint[1], new uint[2] { 27u, 13u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 12685212997342829632uL }, new string[0], new uint[1], new uint[2] { 26u, 25u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 12448241480574438186uL }, new string[0], new uint[1], new uint[1] { 824u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 12448241480574438186uL }, new string[0], new uint[1] { 4u }, new uint[2] { 358u, 316u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8112010450000786492uL }, new string[0], new uint[1], new uint[2] { 161u, 8u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2580753232084104741uL }, new string[0], new uint[1], new uint[2] { 237u, 239u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9706081627986864375uL }, new string[0], new uint[1], new uint[2] { 77u, 76u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2046879235130061967uL }, new string[0], new uint[1], new uint[2] { 23u, 21u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6915612318130423578uL }, new string[0], new uint[1], new uint[5] { 367u, 133u, 128u, 366u, 313u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 6915612318130423578uL }, new string[0], new uint[1], new uint[1] { 314u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 127) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6915612318130423578uL }, new string[0], new uint[1], new uint[2] { 343u, 341u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 10429003070780375168uL }, new string[0], new uint[1], new uint[2] { 240u, 151u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4133901881028310574uL }, new string[0], new uint[1], new uint[2] { 937u, 932u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4133901881028310574uL }, new string[0], new uint[1] { 12u }, new uint[5] { 873u, 2507u, 1783u, 128u, 871u }));
		patches.connection_modification_patches.Add(ScriptConnectionModificationPatch.import(new ulong[1] { 4133901881028310574uL }, new string[1] { "SRLY" }, new uint[1] { 12u }, new uint[1] { 866u }, new string[0], new string[1] { "ACTN" }, new uint[1] { 1783u }, "RLAY", "ACTN", new uint[1] { 867u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 14742980547553882067uL }, new string[0], new uint[1], new uint[2] { 127u, 61u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4910606911885883821uL }, new string[0], new uint[1], new uint[2] { 53u, 51u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 10164050604229640228uL }, new string[0], new uint[1], new uint[2] { 225u, 224u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 10733512082794532665uL }, new string[0], new uint[1], new uint[2] { 578u, 577u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17641492364836789457uL }, new string[0], new uint[1], new uint[2] { 416u, 414u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2667502259855056433uL }, new string[0], new uint[1], new uint[2] { 325u, 331u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8195940946934839837uL }, new string[0], new uint[1], new uint[2] { 235u, 237u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 12622074872595627812uL }, new string[0], new uint[1], new uint[2] { 63u, 70u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 12622074872595627812uL }, new string[0], new uint[1], new uint[2] { 1096u, 194u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9955656508473190866uL }, new string[0], new uint[1], new uint[1] { 626u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9955656508473190866uL }, new string[0], new uint[0], new uint[3] { 133u, 731u, 705u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 9955656508473190866uL }, new string[0], new uint[0], new uint[1] { 661u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 675) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 265878788849725085uL }, new string[0], new uint[0], new uint[6] { 383u, 136u, 974u, 957u, 101u, 982u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 265878788849725085uL }, new string[0], new uint[0], new uint[1] { 968u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 958) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 265878788849725085uL }, new string[0], new uint[1], new uint[2] { 139u, 277u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13389753286679728417uL }, new string[0], new uint[1], new uint[2] { 964u, 971u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1701256524990864906uL }, new string[0], new uint[1], new uint[2] { 1318u, 1317u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9772683067190669679uL }, new string[0], new uint[1], new uint[2] { 127u, 131u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17636479515754825573uL }, new string[0], new uint[0], new uint[5] { 213u, 571u, 1071u, 443u, 211u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 17636479515754825573uL }, new string[0], new uint[0], new uint[1] { 216u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 210) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17636479515754825573uL }, new string[0], new uint[1], new uint[2] { 932u, 1041u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8316677848927658449uL }, new string[0], new uint[1], new uint[2] { 153u, 150u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6708692299270885612uL }, new string[0], new uint[1], new uint[3] { 91u, 95u, 360u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18200553231954089224uL }, new string[0], new uint[0], new uint[2] { 237u, 239u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 8254796686876375149uL }, new string[0], new uint[1], new uint[2] { 12u, 15u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 7063455547734255887uL }, new string[0], new uint[1], new uint[2] { 1134u, 1132u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1760181228684086770uL }, new string[0], new uint[1], new uint[2] { 499u, 501u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3594029436312475339uL }, new string[0], new uint[0], new uint[4] { 403u, 826u, 401u, 369u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 3594029436312475339uL }, new string[0], new uint[0], new uint[1] { 392u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "ACTN", 402),
			Connection.make_connection("RLAY", "ZERO", 314)
		}));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 16389095850931092901uL }, new string[0], new uint[1], new uint[1] { 896u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 16389095850931092901uL }, new string[0], new uint[1] { 9u }, new uint[2] { 140u, 139u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 11685491285383767107uL }, new string[0], new uint[1], new uint[2] { 79u, 72u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 11846340785047609812uL }, new string[0], new uint[1], new uint[2] { 12u, 6u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17400901133416718911uL }, new string[0], new uint[1], new uint[2] { 486u, 226u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15178552083233342671uL }, new string[0], new uint[1], new uint[2] { 83u, 73u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 15178552083233342671uL }, new string[0], new uint[1], new uint[2] { 195u, 219u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 5682718801820042955uL }, new string[0], new uint[1], new uint[2] { 53u, 64u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1808913861159744919uL }, new string[0], new uint[0], new uint[6] { 688u, 687u, 1168u, 300u, 874u, 301u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 1808913861159744919uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 686u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 690) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18221971457754325372uL }, new string[0], new uint[1], new uint[2] { 607u, 606u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 18221971457754325372uL }, new string[0], new uint[1], new uint[1] { 906u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 13589229454537797972uL }, new string[0], new uint[1] { 17u }, new uint[2] { 1343u, 1338u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 5194668821114474017uL }, new string[0], new uint[1], new uint[2] { 160u, 154u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2807909054514352708uL }, new string[0], new uint[1], new uint[2] { 73u, 75u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1516173575710242674uL }, new string[0], new uint[1], new uint[1] { 418u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 1516173575710242674uL }, new string[0], new uint[1], new uint[2] { 341u, 342u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 3558406334082684652uL }, new string[0], new uint[1], new uint[5] { 341u, 342u, 1254u, 958u, 1243u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 3558406334082684652uL }, new string[1] { "SRLY" }, new uint[1], new uint[1] { 668u }, new Connection[1] { Connection.make_connection("RLAY", "ACTN", 666) }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 3558406334082684652uL }, new string[1] { "SRLY" }, new uint[1], new uint[1] { 1617u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 68, 51, 90, 255 }, new BPropertyValue(new byte[4] { 65, 0, 0, 0 })) }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 6948986767748104139uL }, new string[0], new uint[1], new uint[2] { 85u, 79u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 17766988414710659705uL }, new string[0], new uint[0], new uint[7] { 109u, 125u, 126u, 603u, 150u, 474u, 605u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 17766988414710659705uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 132u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "ACTN", 133),
			Connection.make_connection("RLAY", "ACTN", 185)
		}));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 9708827741160794862uL }, new string[0], new uint[0], new uint[6] { 10u, 336u, 467u, 326u, 334u, 466u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 9708827741160794862uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 340u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "ACTN", 353),
			Connection.make_connection("RLAY", "ACTN", 341)
		}));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 4585599704880367469uL }, new string[0], new uint[0], new uint[5] { 366u, 161u, 165u, 81u, 753u }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 4585599704880367469uL }, new string[1] { "SRLY" }, new uint[0], new uint[1] { 168u }, new Connection[2]
		{
			Connection.make_connection("RLAY", "ACTN", 164),
			Connection.make_connection("RLAY", "ACTN", 124)
		}));
	}

	public static void add_fake_pickup_patches(Patches patches, FakePickup[] fake_pickup_locations, ItemName[] item_list, Dictionary<ulong, Dependency[]> file_dependencies)
	{
		foreach (FakePickup fakePickup in fake_pickup_locations)
		{
			Item item = Item.get_item_data(item_list[fakePickup.item_index]);
			List<byte> list = new List<byte>();
			byte[] character = item.character;
			foreach (byte item2 in character)
			{
				list.Add(item2);
			}
			character = item.default_animation;
			foreach (byte item3 in character)
			{
				list.Add(item3);
			}
			byte[] property_value = list.ToArray();
			if (!patches.dependency_patches.ContainsKey(fakePickup.mrea_id))
			{
				patches.dependency_patches[fakePickup.mrea_id] = new List<Dependency>();
			}
			if (Conversion.b_to_u64(item.model) != ulong.MaxValue)
			{
				MP3Dependencies.add_unique_dependencies(patches.dependency_patches[fakePickup.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.model), "CMDL"));
			}
			if (Conversion.b_to_u64(item.character) != ulong.MaxValue)
			{
				MP3Dependencies.add_unique_dependencies(patches.dependency_patches[fakePickup.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.character), "CHAR"));
			}
			if (Conversion.b_to_u64(item.scan) != ulong.MaxValue)
			{
				MP3Dependencies.add_unique_dependencies(patches.dependency_patches[fakePickup.mrea_id], MP3Dependencies.get_dependencies_of(file_dependencies, Conversion.b_to_u64(item.scan), "SCAN"));
			}
			patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { fakePickup.mrea_id }, new string[0], new uint[1] { fakePickup.scly_section }, new uint[1] { Conversion.b_to_u16(fakePickup.instance_id) }, new PropertyModification[4]
			{
				PropertyModification.import(new byte[4] { 194, 127, 250, 143 }, new BPropertyValue(item.model)),
				PropertyModification.import(new byte[4] { 162, 68, 201, 216 }, new BPropertyValue(property_value)),
				PropertyModification.import(new byte[4] { 163, 214, 63, 68 }, new BPropertyValue(property_value)),
				PropertyModification.import(new byte[4] { 185, 78, 155, 231 }, new BPropertyValue(item.scan))
			}));
		}
	}
}
