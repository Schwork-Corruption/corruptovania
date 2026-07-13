using System.Collections.Generic;

namespace MP3Randomizer;

public class StartPatches
{
	public static void add_reveal_map_patch(Patches patches, ulong starting_mrea_id)
	{
		Connection[] the_connections = new Connection[32]
		{
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 176 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 176 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 177 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 178 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 179 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 180 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 180 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 181 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 181 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 182 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 183 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 184 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 184 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 185 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 185 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 186 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 187 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 188 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 188 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 189 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 189 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 190 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 190 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 191 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 191 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 192 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 193 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 193 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 194 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 195 }),
			Connection.make_connection("ZERO", "IM04", new byte[2] { 237, 196 }),
			Connection.make_connection("ZERO", "IM02", new byte[2] { 237, 197 })
		};
		ScriptObject scriptObject = Timer.create_fast_timer(new byte[2] { 237, 160 }, new byte[36]
		{
			67, 150, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, the_connections);
		ScriptObject scriptObject2 = AVMC.create_avmc(new byte[2] { 237, 176 }, new byte[36]
		{
			67, 150, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 111, 184, 239, 42, 149, 35, 195, 67 }, 2u);
		ScriptObject scriptObject3 = AVMC.create_avmc(new byte[2] { 237, 177 }, new byte[36]
		{
			67, 151, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 111, 184, 239, 42, 149, 35, 195, 67 }, 13u);
		ScriptObject scriptObject4 = AVMC.create_avmc(new byte[2] { 237, 178 }, new byte[36]
		{
			67, 151, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 111, 184, 239, 42, 149, 35, 195, 67 }, 16u);
		ScriptObject scriptObject5 = AVMC.create_avmc(new byte[2] { 237, 179 }, new byte[36]
		{
			67, 152, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 111, 184, 239, 42, 149, 35, 195, 67 }, 19u);
		ScriptObject scriptObject6 = AVMC.create_avmc(new byte[2] { 237, 180 }, new byte[36]
		{
			67, 152, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 159, 5, 155, 83, 86, 26, 150, 149 }, 2u);
		ScriptObject scriptObject7 = AVMC.create_avmc(new byte[2] { 237, 181 }, new byte[36]
		{
			67, 153, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 155, 169, 41, 45, 88, 141, 110, 184 }, 2u);
		ScriptObject scriptObject8 = AVMC.create_avmc(new byte[2] { 237, 182 }, new byte[36]
		{
			67, 153, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 159, 5, 155, 83, 86, 26, 150, 149 }, 37u);
		ScriptObject scriptObject9 = AVMC.create_avmc(new byte[2] { 237, 183 }, new byte[36]
		{
			67, 154, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 159, 5, 155, 83, 86, 26, 150, 149 }, 33u);
		ScriptObject scriptObject10 = AVMC.create_avmc(new byte[2] { 237, 184 }, new byte[36]
		{
			67, 154, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 205, 121, 196, 62, 182, 200, 1, 253 }, 2u);
		ScriptObject scriptObject11 = AVMC.create_avmc(new byte[2] { 237, 185 }, new byte[36]
		{
			67, 155, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 195, 127, 74, 216, 83, 40, 76, 120 }, 2u);
		ScriptObject scriptObject12 = AVMC.create_avmc(new byte[2] { 237, 186 }, new byte[36]
		{
			67, 155, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 195, 127, 74, 216, 83, 40, 76, 120 }, 18u);
		ScriptObject scriptObject13 = AVMC.create_avmc(new byte[2] { 237, 187 }, new byte[36]
		{
			67, 156, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 224, 240, 98, 38, 66, 228, 44, 171 }, 28u);
		ScriptObject scriptObject14 = AVMC.create_avmc(new byte[2] { 237, 188 }, new byte[36]
		{
			67, 156, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 148, 188, 167, 42, 177, 207, 236, 5 }, 2u);
		ScriptObject scriptObject15 = AVMC.create_avmc(new byte[2] { 237, 189 }, new byte[36]
		{
			67, 157, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 193, 51, 249, 25, 193, 8, 189, 249 }, 2u);
		ScriptObject scriptObject16 = AVMC.create_avmc(new byte[2] { 237, 190 }, new byte[36]
		{
			67, 157, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 16, 111, 127, 79, 239, 182, 81, 217 }, 2u);
		ScriptObject scriptObject17 = AVMC.create_avmc(new byte[2] { 237, 191 }, new byte[36]
		{
			67, 158, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 56, 9, 133, 36, 239, 120, 182, 210 }, 2u);
		ScriptObject scriptObject18 = AVMC.create_avmc(new byte[2] { 237, 192 }, new byte[36]
		{
			67, 158, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 221, 28, 78, 24, 231, 41, 27, 239 }, 8u);
		ScriptObject scriptObject19 = AVMC.create_avmc(new byte[2] { 237, 193 }, new byte[36]
		{
			67, 159, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 222, 151, 212, 129, 136, 202, 140, 153 }, 2u);
		ScriptObject scriptObject20 = AVMC.create_avmc(new byte[2] { 237, 194 }, new byte[36]
		{
			67, 220, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 55, 169, 232, 111, 10, 12, 175, 111 }, 2u);
		ScriptObject scriptObject21 = AVMC.create_avmc(new byte[2] { 237, 195 }, new byte[36]
		{
			67, 221, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 224, 240, 98, 38, 66, 228, 44, 171 }, 2u);
		ScriptObject scriptObject22 = AVMC.create_avmc(new byte[2] { 237, 196 }, new byte[36]
		{
			67, 221, 128, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 221, 28, 78, 24, 231, 41, 27, 239 }, 2u);
		ScriptObject scriptObject23 = AVMC.create_avmc(new byte[2] { 237, 197 }, new byte[36]
		{
			67, 222, 0, 0, 194, 200, 0, 0, 193, 240,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 63, 128, 0, 0, 63, 128,
			0, 0, 63, 128, 0, 0
		}, new Connection[0], new byte[8] { 56, 9, 133, 36, 239, 120, 182, 210 }, 18u);
		if (new List<ulong>
		{
			16176791526348999604uL, 5004510451841853689uL, 3586057064387876334uL, 15740040421447045864uL, 14403796150828511218uL, 14348692121215628991uL, 9427699631074225391uL, 4548320739784543479uL, 1240494628458491366uL, 13907983853126891218uL,
			17930423943250813827uL, 11421266353153196460uL, 7060956319399124858uL, 14223261248779109721uL, 9455349673417098581uL, 373237702897908369uL, 1845155541927532448uL, 14604797390173513666uL, 4701238246970930238uL, 975168564662458837uL,
			659263668515774583uL, 9908630587780032110uL, 10500207601768265995uL, 7486162873388959747uL, 15628730931753443250uL, 16233775155696881050uL, 8779228940472058493uL, 5834535855679580949uL
		}.Contains(starting_mrea_id))
		{
			patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 5834535855679580949uL }, new uint[1] { 10u }, new ScriptObject[23]
			{
				scriptObject, scriptObject2, scriptObject3, scriptObject4, scriptObject5, scriptObject6, scriptObject7, scriptObject8, scriptObject9, scriptObject10,
				scriptObject11, scriptObject12, scriptObject13, scriptObject14, scriptObject15, scriptObject16, scriptObject17, scriptObject18, scriptObject19, scriptObject20,
				scriptObject21, scriptObject22, scriptObject23
			}));
			patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { 14583031681898448395uL }, new uint[1], new ScriptObject[23]
			{
				scriptObject, scriptObject2, scriptObject3, scriptObject4, scriptObject5, scriptObject6, scriptObject7, scriptObject8, scriptObject9, scriptObject10,
				scriptObject11, scriptObject12, scriptObject13, scriptObject14, scriptObject15, scriptObject16, scriptObject17, scriptObject18, scriptObject19, scriptObject20,
				scriptObject21, scriptObject22, scriptObject23
			}));
		}
		else
		{
			patches.object_addition_patches.Add(ScriptObjectAdditionPatch.import(new ulong[1] { starting_mrea_id }, new uint[1], new ScriptObject[23]
			{
				scriptObject, scriptObject2, scriptObject3, scriptObject4, scriptObject5, scriptObject6, scriptObject7, scriptObject8, scriptObject9, scriptObject10,
				scriptObject11, scriptObject12, scriptObject13, scriptObject14, scriptObject15, scriptObject16, scriptObject17, scriptObject18, scriptObject19, scriptObject20,
				scriptObject21, scriptObject22, scriptObject23
			}));
		}
	}

	public static void add_starting_items_patch(Patches patches, MP3Inventory inventory, ulong starting_mrea_id)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { starting_mrea_id }, new string[1] { "SPWN" }, new uint[0], new uint[0], new PropertyModification[30]
		{
			PropertyModification.import(new byte[4] { 148, 175, 20, 69 }, new RepeatPropertyValue(new List<byte[]>
			{
				Conversion.u32_to_4b(inventory.EnergyAmount),
				Conversion.u32_to_4b(inventory.EnergyTankAmount),
				Conversion.u32_to_4b(inventory.FusesAmount),
				Conversion.u32_to_4b(inventory.PlayerInventoryItemAmount),
				Conversion.u32_to_4b(inventory.MissileAmount),
				Conversion.u32_to_4b(inventory.ShipMissileAmount)
			})),
			PropertyModification.import(new byte[4] { 109, 197, 159, 19 }, new RepeatPropertyValue(new List<byte[]>
			{
				Conversion.u32_to_4b(inventory.EnergyCapacity),
				Conversion.u32_to_4b(inventory.EnergyTankCapacity),
				Conversion.u32_to_4b(inventory.FusesCapacity),
				Conversion.u32_to_4b(inventory.PlayerInventoryItemCapacity),
				Conversion.u32_to_4b(inventory.MissileCapacity),
				Conversion.u32_to_4b(inventory.ShipMissileCapacity)
			})),
			PropertyModification.import(new byte[4] { 249, 188, 62, 61 }, new BPropertyValue(Conversion.bool_to_b(inventory.PowerBeam))),
			PropertyModification.import(new byte[4] { 66, 201, 0, 237 }, new BPropertyValue(Conversion.bool_to_b(inventory.PlasmaBeam))),
			PropertyModification.import(new byte[4] { 74, 226, 127, 231 }, new BPropertyValue(Conversion.bool_to_b(inventory.NovaBeam))),
			PropertyModification.import(new byte[4] { 243, 79, 153, 215 }, new BPropertyValue(Conversion.bool_to_b(inventory.ChargeUpgrade))),
			PropertyModification.import(new byte[4] { 93, 179, 230, 148 }, new BPropertyValue(Conversion.bool_to_b(inventory.IceMissile))),
			PropertyModification.import(new byte[4] { 154, 164, 5, 193 }, new BPropertyValue(Conversion.bool_to_b(inventory.SeekerMissile))),
			PropertyModification.import(new byte[4] { 164, 101, 134, 136 }, new BPropertyValue(Conversion.bool_to_b(inventory.GrappleBeamPull))),
			PropertyModification.import(new byte[4] { 210, 60, 242, 157 }, new BPropertyValue(Conversion.bool_to_b(inventory.GrappleBeamSwing))),
			PropertyModification.import(new byte[4] { 90, 126, 48, 30 }, new BPropertyValue(Conversion.bool_to_b(inventory.GrappleBeamVoltage))),
			PropertyModification.import(new byte[4] { 175, 198, 8, 45 }, new BPropertyValue(Conversion.bool_to_b(inventory.Bomb))),
			PropertyModification.import(new byte[4] { 88, 106, 143, 117 }, new BPropertyValue(Conversion.bool_to_b(inventory.ScanVisor))),
			PropertyModification.import(new byte[4] { 4, 252, 162, 169 }, new BPropertyValue(Conversion.bool_to_b(inventory.CommandVisor))),
			PropertyModification.import(new byte[4] { 245, 93, 208, 44 }, new BPropertyValue(Conversion.bool_to_b(inventory.XRayVisor))),
			PropertyModification.import(new byte[4] { 246, 24, 200, 229 }, new BPropertyValue(Conversion.bool_to_b(inventory.MorphBall))),
			PropertyModification.import(new byte[4] { 21, 201, 158, 122 }, new BPropertyValue(Conversion.bool_to_b(inventory.BoostBall))),
			PropertyModification.import(new byte[4] { 98, 255, 189, 156 }, new BPropertyValue(Conversion.bool_to_b(inventory.SpiderBall))),
			PropertyModification.import(new byte[4] { 9, 220, 60, 221 }, new BPropertyValue(Conversion.bool_to_b(inventory.DoubleJump))),
			PropertyModification.import(new byte[4] { 192, 189, 138, 94 }, new BPropertyValue(Conversion.u32_to_4b(inventory.SuitType))),
			PropertyModification.import(new byte[4] { 90, 6, 110, 44 }, new BPropertyValue(Conversion.u32_to_4b(inventory.ScrewAttack))),
			PropertyModification.import(new byte[4] { 172, 189, 164, 92 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeTank))),
			PropertyModification.import(new byte[4] { 156, 48, 255, 150 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeBeam))),
			PropertyModification.import(new byte[4] { 38, 168, 93, 244 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeGrapple))),
			PropertyModification.import(new byte[4] { 229, 182, 203, 102 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeMissile))),
			PropertyModification.import(new byte[4] { 233, 129, 225, 235 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeBall))),
			PropertyModification.import(new byte[4] { 254, 155, 40, 3 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModePermanent))),
			PropertyModification.import(new byte[4] { 236, 213, 38, 31 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModePhaaze))),
			PropertyModification.import(new byte[4] { 42, 5, 230, 217 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeOriginal))),
			PropertyModification.import(new byte[4] { 201, 50, 139, 226 }, new BPropertyValue(Conversion.bool_to_b(inventory.HyperModeCharge)))
		}));
	}

	public static void add_starting_location_patch(Patches patches, StartingArea starting_area)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 15355308818766275996uL }, new string[1] { "TEL1" }, new uint[0], new uint[0], new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 49, 236, 20, 188 }, new BPropertyValue(starting_area.get_world_id_b())),
			PropertyModification.import(new byte[4] { 224, 193, 120, 4 }, new BPropertyValue(starting_area.get_area_id_b()))
		}));
	}
}
