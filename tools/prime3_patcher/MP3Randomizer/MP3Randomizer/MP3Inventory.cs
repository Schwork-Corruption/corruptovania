using System;

namespace MP3Randomizer;

public class MP3Inventory
{
	public uint EnergyAmount;

	public uint EnergyCapacity;

	public uint EnergyTankAmount;

	public uint EnergyTankCapacity;

	public uint FusesAmount;

	public uint FusesCapacity;

	public uint PlayerInventoryItemAmount;

	public uint PlayerInventoryItemCapacity;

	public bool PowerBeam;

	public bool PlasmaBeam;

	public bool NovaBeam;

	public bool ChargeUpgrade;

	public uint MissileAmount;

	public uint MissileCapacity;

	public bool IceMissile;

	public bool SeekerMissile;

	public bool GrappleBeamPull;

	public bool GrappleBeamSwing;

	public bool GrappleBeamVoltage;

	public bool Bomb;

	public bool ScanVisor;

	public bool CommandVisor;

	public bool XRayVisor;

	public bool MorphBall;

	public bool BoostBall;

	public bool SpiderBall;

	public bool DoubleJump;

	public uint SuitType;

	public uint ScrewAttack;

	public bool HyperModeTank;

	public bool HyperModeBeam;

	public bool HyperModeGrapple;

	public bool HyperModeMissile;

	public bool HyperModeBall;

	public bool HyperModePermanent;

	public bool HyperModePhaaze;

	public bool HyperModeOriginal;

	public bool HyperModeCharge;

	public uint ShipMissileAmount;

	public uint ShipMissileCapacity;

	public bool ShipGrapple;

	public static MP3Inventory get_original_inventory_with_command()
	{
		return new MP3Inventory
		{
			EnergyAmount = 1u,
			EnergyCapacity = 1u,
			EnergyTankAmount = 0u,
			EnergyTankCapacity = 0u,
			FusesAmount = 0u,
			FusesCapacity = 0u,
			PlayerInventoryItemAmount = 0u,
			PlayerInventoryItemCapacity = 0u,
			PowerBeam = true,
			PlasmaBeam = false,
			NovaBeam = false,
			ChargeUpgrade = true,
			MissileAmount = 0u,
			MissileCapacity = 0u,
			IceMissile = false,
			SeekerMissile = false,
			GrappleBeamPull = false,
			GrappleBeamSwing = false,
			GrappleBeamVoltage = false,
			Bomb = true,
			ScanVisor = true,
			CommandVisor = true,
			XRayVisor = false,
			MorphBall = true,
			BoostBall = false,
			SpiderBall = false,
			DoubleJump = true,
			SuitType = 0u,
			ScrewAttack = 0u,
			HyperModeTank = false,
			HyperModeBeam = false,
			HyperModeGrapple = false,
			HyperModeMissile = false,
			HyperModeBall = false,
			HyperModePermanent = false,
			HyperModePhaaze = false,
			HyperModeOriginal = false,
			HyperModeCharge = false,
			ShipMissileAmount = 0u,
			ShipMissileCapacity = 0u,
			ShipGrapple = false
		};
	}

	public static MP3Inventory get_post_norion_inventory_without_lasso()
	{
		return new MP3Inventory
		{
			EnergyAmount = 1u,
			EnergyCapacity = 1u,
			EnergyTankAmount = 1u,
			EnergyTankCapacity = 1u,
			FusesAmount = 0u,
			FusesCapacity = 0u,
			PlayerInventoryItemAmount = 0u,
			PlayerInventoryItemCapacity = 0u,
			PowerBeam = true,
			PlasmaBeam = false,
			NovaBeam = false,
			ChargeUpgrade = true,
			MissileAmount = 5u,
			MissileCapacity = 5u,
			IceMissile = false,
			SeekerMissile = false,
			GrappleBeamPull = false,
			GrappleBeamSwing = false,
			GrappleBeamVoltage = false,
			Bomb = true,
			ScanVisor = true,
			CommandVisor = true,
			XRayVisor = false,
			MorphBall = true,
			BoostBall = false,
			SpiderBall = false,
			DoubleJump = true,
			SuitType = 1u,
			ScrewAttack = 0u,
			HyperModeTank = true,
			HyperModeBeam = true,
			HyperModeGrapple = false,
			HyperModeMissile = false,
			HyperModeBall = false,
			HyperModePermanent = false,
			HyperModePhaaze = false,
			HyperModeOriginal = true,
			HyperModeCharge = true,
			ShipMissileAmount = 0u,
			ShipMissileCapacity = 0u,
			ShipGrapple = false
		};
	}

	public static MP3Inventory get_custom_inventory(string bytestring)
	{
		return new MP3Inventory
		{
			EnergyAmount = Convert.ToUInt32("0x" + bytestring[0], 16),
			EnergyCapacity = Convert.ToUInt32("0x" + bytestring[1], 16),
			EnergyTankAmount = Convert.ToUInt32("0x" + bytestring[2], 16),
			EnergyTankCapacity = Convert.ToUInt32("0x" + bytestring[3], 16),
			FusesAmount = Convert.ToUInt32("0x" + bytestring[4], 16),
			FusesCapacity = Convert.ToUInt32("0x" + bytestring[5], 16),
			PlayerInventoryItemAmount = Convert.ToUInt32("0x" + bytestring[6], 16),
			PlayerInventoryItemCapacity = Convert.ToUInt32("0x" + bytestring[7], 16),
			PowerBeam = (Convert.ToUInt32("0x" + bytestring[8], 16) == 1),
			PlasmaBeam = (Convert.ToUInt32("0x" + bytestring[9], 16) == 1),
			NovaBeam = (Convert.ToUInt32("0x" + bytestring[10], 16) == 1),
			ChargeUpgrade = (Convert.ToUInt32("0x" + bytestring[11], 16) == 1),
			MissileAmount = Convert.ToUInt32("0x" + bytestring.Substring(12, 2), 16),
			MissileCapacity = Convert.ToUInt32("0x" + bytestring.Substring(14, 2), 16),
			IceMissile = (Convert.ToUInt32("0x" + bytestring[16], 16) == 1),
			SeekerMissile = (Convert.ToUInt32("0x" + bytestring[17], 16) == 1),
			GrappleBeamPull = (Convert.ToUInt32("0x" + bytestring[18], 16) == 1),
			GrappleBeamSwing = (Convert.ToUInt32("0x" + bytestring[19], 16) == 1),
			GrappleBeamVoltage = (Convert.ToUInt32("0x" + bytestring[20], 16) == 1),
			Bomb = (Convert.ToUInt32("0x" + bytestring[21], 16) == 1),
			ScanVisor = (Convert.ToUInt32("0x" + bytestring[22], 16) == 1),
			CommandVisor = (Convert.ToUInt32("0x" + bytestring[23], 16) == 1),
			XRayVisor = (Convert.ToUInt32("0x" + bytestring[24], 16) == 1),
			MorphBall = (Convert.ToUInt32("0x" + bytestring[25], 16) == 1),
			BoostBall = (Convert.ToUInt32("0x" + bytestring[26], 16) == 1),
			SpiderBall = (Convert.ToUInt32("0x" + bytestring[27], 16) == 1),
			DoubleJump = (Convert.ToUInt32("0x" + bytestring[28], 16) == 1),
			SuitType = Convert.ToUInt32("0x" + bytestring[29], 16),
			ScrewAttack = Convert.ToUInt32("0x" + bytestring[30], 16),
			HyperModeTank = (Convert.ToUInt32("0x" + bytestring[31], 16) == 1),
			HyperModeBeam = (Convert.ToUInt32("0x" + bytestring[32], 16) == 1),
			HyperModeGrapple = (Convert.ToUInt32("0x" + bytestring[33], 16) == 1),
			HyperModeMissile = (Convert.ToUInt32("0x" + bytestring[34], 16) == 1),
			HyperModeBall = (Convert.ToUInt32("0x" + bytestring[35], 16) == 1),
			HyperModePermanent = (Convert.ToUInt32("0x" + bytestring[36], 16) == 1),
			HyperModePhaaze = (Convert.ToUInt32("0x" + bytestring[37], 16) == 1),
			HyperModeOriginal = (Convert.ToUInt32("0x" + bytestring[38], 16) == 1),
			HyperModeCharge = (Convert.ToUInt32("0x" + bytestring[39], 16) == 1),
			ShipMissileAmount = Convert.ToUInt32("0x" + bytestring[40], 16),
			ShipMissileCapacity = Convert.ToUInt32("0x" + bytestring[41], 16),
			ShipGrapple = (Convert.ToUInt32("0x" + bytestring[42], 16) == 1)
		};
	}

	public static MP3Inventory create_inventory(StartingItemsType starting_items_type, string bytestring)
	{
		return starting_items_type switch
		{
			StartingItemsType.OriginalWithCommand => get_original_inventory_with_command(), 
			StartingItemsType.PostNorionNoLasso => get_post_norion_inventory_without_lasso(), 
			StartingItemsType.Custom => get_custom_inventory(bytestring), 
			_ => throw new ArgumentException("Cannot create inventory for specified starting items"), 
		};
	}
}
