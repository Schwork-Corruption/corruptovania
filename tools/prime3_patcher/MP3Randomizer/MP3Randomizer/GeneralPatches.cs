namespace MP3Randomizer;

public class GeneralPatches
{
	public static void add_bombing_run_patches(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(8050447300094575427uL, 16u, new uint[1] { 12u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 5u, new uint[1] { 8u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 10u, new uint[1] { 14u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 5u, new uint[1] { 8u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 11u, new uint[1] { 11u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 14u, new uint[1] { 10u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 20u, new uint[1] { 15u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 26u, new uint[1] { 16u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 34u, new uint[1] { 6u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11216541621678862008uL, 10u, new uint[1] { 18u }, new uint[0]));
	}

	public static void add_ship_strike_patches(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11216541621678862008uL, 14u, new uint[1] { 2u }, new uint[0]));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 20u, new uint[1] { 4u }, new uint[0]));
	}

	public static void add_room_reveal_cutscene_patches(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(13921744762140409337uL, 2u, new uint[0], new uint[1] { 8u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 10u, new uint[0], new uint[1] { 12u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(14087060452406742136uL, 3u, new uint[0], new uint[1] { 4u }));
		patches.object_deletion_patches.Add(ScriptObjectDeletionPatch.import(new ulong[1] { 2667502259855056433uL }, new string[0], new uint[1], new uint[3] { 920u, 274u, 275u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(16208562975376944299uL, 4u, new uint[0], new uint[1] { 10u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(4037904934597342930uL, 5u, new uint[0], new uint[1] { 7u }));
	}

	public static void add_ship_grapple_patches(Patches patches)
	{
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 12u, new uint[1] { 2u }, new uint[1] { 8u }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 7492844587871276588uL }, new string[1] { "SHCI" }, new uint[1] { 2u }, new uint[1] { 124u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 65, 67, 84, 86 }, new BPropertyValue(new byte[1])) }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 7492844587871276588uL }, new string[1] { "CRLY" }, new uint[1], new uint[1] { 506u }, new Connection[1] { Connection.make_connection("OPEN", "ACTV", new byte[2] { 0, 124 }) }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 7492844587871276588uL }, new string[1] { "PCKP" }, new uint[1], new uint[1] { 23u }, new Connection[1] { Connection.make_connection("ACQU", "ZERO", new byte[2] { 1, 250 }) }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 7492844587871276588uL }, new string[1] { "PCKP" }, new uint[1], new uint[1] { 39u }, new Connection[1] { Connection.make_connection("ACQU", "ZERO", new byte[2] { 1, 250 }) }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(11458735609143269013uL, 26u, new uint[1] { 8u }, new uint[1] { 20u }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 5310258251750100868uL }, new string[1] { "SHCI" }, new uint[1] { 8u }, new uint[1] { 631u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 65, 67, 84, 86 }, new BPropertyValue(new byte[1])) }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 5310258251750100868uL }, new string[1] { "CRLY" }, new uint[1], new uint[1] { 1261u }, new Connection[1] { Connection.make_connection("OPEN", "ACTV", new byte[2] { 2, 119 }) }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 13389753286679728417uL }, new string[1] { "SHCI" }, new uint[1] { 2u }, new uint[1] { 750u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 65, 67, 84, 86 }, new BPropertyValue(new byte[1])) }));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 13389753286679728417uL }, new string[1] { "SHCI" }, new uint[1] { 4u }, new uint[1] { 784u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 65, 67, 84, 86 }, new BPropertyValue(new byte[1])) }));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 13389753286679728417uL }, new string[1] { "CRLY" }, new uint[1] { 3u }, new uint[1] { 1767u }, new Connection[2]
		{
			Connection.make_connection("OPEN", "ACTV", new byte[2] { 2, 238 }),
			Connection.make_connection("OPEN", "ACTV", new byte[2] { 3, 16 })
		}));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 13389753286679728417uL }, new string[1] { "PCKP" }, new uint[1], new uint[1] { 978u }, new Connection[1] { Connection.make_connection("ACQU", "ZERO", new byte[2] { 6, 231 }) }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(16208562975376944299uL, 19u, new uint[2] { 3u, 7u }, new uint[1] { 6u }));
		patches.layer_toggle_patches.Add(LayerTogglePatch.import(16208562975376944299uL, 25u, new uint[1] { 3u }, new uint[0]));
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 2455573103578253675uL }, new string[1] { "CRLY" }, new uint[1], new uint[1] { 1047u }, new Connection[3]
		{
			Connection.make_connection("OPEN", "ACTV", new byte[2] { 1, 47 }),
			Connection.make_connection("CLOS", "DCTV", new byte[2] { 1, 47 }),
			Connection.make_connection("OPEN", "DCTV", new byte[2] { 5, 60 })
		}));
		Connection[] the_connections = new Connection[1] { Connection.make_connection("CLOS", "DCTV", new byte[2] { 1, 223 }) };
		ScriptObject scriptObject = ConditionalRelay.create_progressive_conditional_relay(new byte[2] { 15, 18 }, new byte[36]
		{
			0, 0, 0, 0, 61, 252, 211, 91, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, the_connections, new byte[4] { 87, 42, 13, 26 });
		patches.connection_addition_patches.Add(ScriptConnectionAdditionPatch.import(new ulong[1] { 8211108078275787776uL }, new string[1] { "SRLY" }, new uint[0], new uint[3] { 978u, 982u, 987u }, new Connection[1] { Connection.make_connection("RLAY", "ZERO", new byte[2] { 15, 18 }) }));
		patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 8211108078275787776uL }, new uint[1], new ScriptObject[1] { scriptObject }));
	}

	public static void add_space_removal_patches(Patches patches)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 5834535855679580949uL }, new string[1] { "TEL1" }, new uint[1] { 18u }, new uint[1] { 1827u }, new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 49, 236, 20, 188 }, new BPropertyValue(new byte[8] { 111, 184, 239, 42, 149, 35, 195, 67 })),
			PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(new byte[8] { 22, 31, 36, 162, 215, 72, 234, 68 }))
		}));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 7103053089518937857uL }, new string[1] { "TEL1" }, new uint[1], new uint[1] { 16u }, new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 49, 236, 20, 188 }, new BPropertyValue(new byte[8] { 159, 5, 155, 83, 86, 26, 150, 149 })),
			PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(new byte[8] { 32, 153, 85, 2, 224, 155, 63, 241 }))
		}));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 16922267283524287233uL }, new string[1] { "TEL1" }, new uint[1], new uint[1] { 11u }, new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 49, 236, 20, 188 }, new BPropertyValue(new byte[8] { 195, 127, 74, 216, 83, 40, 76, 120 })),
			PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(new byte[8] { 57, 94, 145, 219, 195, 2, 246, 46 }))
		}));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 14660132150748303050uL }, new string[1] { "TEL1" }, new uint[1], new uint[1] { 66u }, new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 49, 236, 20, 188 }, new BPropertyValue(new byte[8] { 56, 9, 133, 36, 239, 120, 182, 210 })),
			PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(new byte[8] { 61, 46, 112, 209, 216, 169, 112, 181 }))
		}));
	}

	public static void add_fast_flying_patches(Patches patches)
	{
		var array = new[]
		{
			new
			{
				mrea_id = 1594033074927626820uL,
				layer = new uint[1] { 21u },
				ids = new uint[5] { 717u, 1491u, 1486u, 1239u, 1412u }
			},
			new
			{
				mrea_id = 6692819360230093549uL,
				layer = new uint[1] { 22u },
				ids = new uint[5] { 1729u, 1949u, 1953u, 939u, 941u }
			},
			new
			{
				mrea_id = 12327360187860907075uL,
				layer = new uint[1] { 13u },
				ids = new uint[5] { 467u, 496u, 483u, 752u, 753u }
			},
			new
			{
				mrea_id = 15622764306970326849uL,
				layer = new uint[1] { 7u },
				ids = new uint[5] { 1072u, 590u, 584u, 379u, 380u }
			},
			new
			{
				mrea_id = 2349002151496990705uL,
				layer = new uint[1] { 16u },
				ids = new uint[7] { 301u, 853u, 183u, 850u, 201u, 28u, 27u }
			},
			new
			{
				mrea_id = 12448241480574438186uL,
				layer = new uint[1] { 22u },
				ids = new uint[7] { 1910u, 1090u, 1796u, 1801u, 1851u, 986u, 987u }
			},
			new
			{
				mrea_id = 16131448128382991283uL,
				layer = new uint[1] { 9u },
				ids = new uint[6] { 268u, 473u, 197u, 468u, 167u, 168u }
			},
			new
			{
				mrea_id = 11708287702197177006uL,
				layer = new uint[1] { 11u },
				ids = new uint[5] { 178u, 496u, 120u, 564u, 333u }
			},
			new
			{
				mrea_id = 12972775391902806082uL,
				layer = new uint[1] { 7u },
				ids = new uint[6] { 1040u, 162u, 995u, 1005u, 282u, 280u }
			},
			new
			{
				mrea_id = 4133901881028310574uL,
				layer = new uint[1] { 19u },
				ids = new uint[5] { 133u, 1523u, 1519u, 1563u, 1565u }
			},
			new
			{
				mrea_id = 3381520513235092752uL,
				layer = new uint[1] { 9u },
				ids = new uint[7] { 1142u, 515u, 594u, 516u, 220u, 326u, 328u }
			},
			new
			{
				mrea_id = 18200553231954089224uL,
				layer = new uint[1] { 9u },
				ids = new uint[6] { 383u, 575u, 570u, 1173u, 138u, 137u }
			},
			new
			{
				mrea_id = 15514523555396225844uL,
				layer = new uint[1] { 7u },
				ids = new uint[5] { 1107u, 95u, 1066u, 273u, 284u }
			},
			new
			{
				mrea_id = 13146584938063573409uL,
				layer = new uint[1] { 15u },
				ids = new uint[4] { 363u, 454u, 463u, 311u }
			},
			new
			{
				mrea_id = 4408585131827753141uL,
				layer = new uint[1] { 14u },
				ids = new uint[5] { 1059u, 534u, 149u, 523u, 296u }
			},
			new
			{
				mrea_id = 9997664456677642630uL,
				layer = new uint[1] { 15u },
				ids = new uint[5] { 26u, 741u, 577u, 740u, 1109u }
			},
			new
			{
				mrea_id = 65874966404189819uL,
				layer = new uint[1] { 10u },
				ids = new uint[5] { 1391u, 361u, 360u, 1285u, 257u }
			},
			new
			{
				mrea_id = 9593588872354674734uL,
				layer = new uint[1] { 7u },
				ids = new uint[5] { 824u, 130u, 785u, 296u, 295u }
			}
		};
		foreach (var anon in array)
		{
			patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { anon.mrea_id }, new string[1] { "TEL1" }, anon.layer, anon.ids, new PropertyModification[11]
			{
				PropertyModification.import(new byte[4] { 71, 75, 204, 227 }, new BPropertyValue(new byte[4] { 195, 14, 90, 70 })),
				PropertyModification.import(new byte[4] { 189, 106, 64, 109 }, new BPropertyValue(new byte[4] { 63, 128, 0, 0 })),
				PropertyModification.import(new byte[4] { 83, 150, 58, 104 }, new BPropertyValue(new byte[12]
				{
					255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
					255, 255
				})),
				PropertyModification.import(new byte[4] { 78, 191, 118, 13 }, new BPropertyValue(new byte[12]
				{
					255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
					255, 255
				})),
				PropertyModification.import(new byte[4] { 93, 126, 121, 161 }, new BPropertyValue(new byte[12]
				{
					255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
					255, 255
				})),
				PropertyModification.import(new byte[4] { 187, 82, 4, 200 }, new BPropertyValue(new byte[12]
				{
					255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
					255, 255
				})),
				PropertyModification.import(new byte[4] { 183, 220, 208, 202 }, new BPropertyValue(new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 })),
				PropertyModification.import(new byte[4] { 4, 208, 62, 65 }, new BPropertyValue(new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 })),
				PropertyModification.import(new byte[4] { 141, 255, 86, 116 }, new BPropertyValue(new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 })),
				PropertyModification.import(new byte[4] { 187, 239, 77, 13 }, new BPropertyValue(new byte[12]
				{
					255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
					255, 255
				})),
				PropertyModification.import(new byte[4] { 204, 239, 198, 24 }, new BPropertyValue(new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 }))
			}));
		}
	}

	public static void add_phaaze_skip_patches(Patches patches)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 10309111007900712142uL }, new string[1] { "TEL1" }, new uint[1], new uint[1] { 331u }, new PropertyModification[1] { PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(new byte[8] { 128, 193, 181, 196, 86, 150, 42, 108 })) }));
	}
}
