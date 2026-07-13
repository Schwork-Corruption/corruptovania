using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MP3Randomizer;

public class MP3Permalink
{
	public const string rot_wheel = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?";

	public static ItemName[] decode_permalink(string encoded_permalink)
	{
		int num = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".IndexOf(encoded_permalink[0]);
		int num2 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".IndexOf(encoded_permalink[1]);
		int num3 = num;
		List<ItemName> list = new List<ItemName>();
		string s = encoded_permalink.Substring(0, encoded_permalink.Length - 5);
		string text = encoded_permalink.Substring(encoded_permalink.Length - 5, 5);
		if (BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "").Substring(0, 5)
			.ToUpper() != text.ToUpper())
		{
			throw new ArgumentException("Invalid permalink: " + encoded_permalink);
		}
		for (int i = 2; i < encoded_permalink.Length - 5; i++)
		{
			for (num3 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".IndexOf(encoded_permalink[i]) - num; num3 < 0; num3 += "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".Length)
			{
			}
			while (num3 >= "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".Length)
			{
				num3 -= "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".Length;
			}
			char c = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?"[num3];
			switch (c)
			{
			case '1':
				list.Add(ItemName.PlasmaBeam);
				break;
			case '2':
				list.Add(ItemName.NovaBeam);
				break;
			case '3':
				list.Add(ItemName.ChargeUpgrade);
				break;
			case '4':
				list.Add(ItemName.MissileExpansion);
				break;
			case '5':
				list.Add(ItemName.IceMissile);
				break;
			case '6':
				list.Add(ItemName.SeekerMissile);
				break;
			case '7':
				list.Add(ItemName.GrappleLasso);
				break;
			case '8':
				list.Add(ItemName.GrappleSwing);
				break;
			case '9':
				list.Add(ItemName.GrappleVoltage);
				break;
			case 'a':
				list.Add(ItemName.Bomb);
				break;
			case 'b':
				list.Add(ItemName.CombatVisor);
				break;
			case 'c':
				list.Add(ItemName.ScanVisor);
				break;
			case 'd':
				list.Add(ItemName.CommandVisor);
				break;
			case 'e':
				list.Add(ItemName.XRayVisor);
				break;
			case 'f':
				list.Add(ItemName.SpaceJump);
				break;
			case 'g':
				list.Add(ItemName.ScrewAttack);
				break;
			case 'h':
				list.Add(ItemName.Suit);
				break;
			case 'k':
				list.Add(ItemName.EnergyTank);
				break;
			case 'n':
				list.Add(ItemName.Fuse1);
				break;
			case 'o':
				list.Add(ItemName.Fuse2);
				break;
			case 'p':
				list.Add(ItemName.Fuse3);
				break;
			case 'q':
				list.Add(ItemName.Fuse4);
				break;
			case 'r':
				list.Add(ItemName.Fuse5);
				break;
			case 's':
				list.Add(ItemName.Fuse6);
				break;
			case 't':
				list.Add(ItemName.Fuse7);
				break;
			case 'u':
				list.Add(ItemName.Fuse8);
				break;
			case 'v':
				list.Add(ItemName.Fuse9);
				break;
			case 'w':
				list.Add(ItemName.MorphBall);
				break;
			case 'x':
				list.Add(ItemName.BoostBall);
				break;
			case 'y':
				list.Add(ItemName.SpiderBall);
				break;
			case 'z':
				list.Add(ItemName.HyperModeTank);
				break;
			case 'B':
				list.Add(ItemName.HyperMissile);
				break;
			case 'C':
				list.Add(ItemName.HyperBall);
				break;
			case 'D':
				list.Add(ItemName.HyperGrapple);
				break;
			case 'H':
				list.Add(ItemName.ShipGrapple);
				break;
			case 'I':
				list.Add(ItemName.ShipMissileExpansion);
				break;
			case 'X':
				list.AddRange(new ItemName[2]);
				break;
			case 'Y':
				list.AddRange(new ItemName[3]);
				break;
			case 'Z':
				list.AddRange(new ItemName[4]);
				break;
			case '(':
				list.AddRange(new ItemName[5]);
				break;
			case ')':
				list.AddRange(new ItemName[6]);
				break;
			case '{':
				list.AddRange(new ItemName[1] { ItemName.ProgressiveMissile });
				break;
			case '}':
				list.AddRange(new ItemName[1] { ItemName.ProgressiveBeam });
				break;
			case '[':
				list.AddRange(new ItemName[2]
				{
					ItemName.EnergyTank,
					ItemName.EnergyTank
				});
				break;
			case ']':
				list.AddRange(new ItemName[3]
				{
					ItemName.EnergyTank,
					ItemName.EnergyTank,
					ItemName.EnergyTank
				});
				break;
			case '<':
				list.AddRange(new ItemName[2]
				{
					ItemName.ShipMissileExpansion,
					ItemName.ShipMissileExpansion
				});
				break;
			case '>':
				list.AddRange(new ItemName[2]
				{
					ItemName.MissileExpansion,
					ItemName.EnergyTank
				});
				break;
			case '=':
				list.AddRange(new ItemName[2]
				{
					ItemName.EnergyTank,
					ItemName.MissileExpansion
				});
				break;
			case ',':
				list.AddRange(new ItemName[3]
				{
					ItemName.MissileExpansion,
					ItemName.EnergyTank,
					ItemName.MissileExpansion
				});
				break;
			case '.':
				list.AddRange(new ItemName[2]
				{
					ItemName.MissileExpansion,
					ItemName.ShipMissileExpansion
				});
				break;
			case '!':
				list.AddRange(new ItemName[2]
				{
					ItemName.ShipMissileExpansion,
					ItemName.MissileExpansion
				});
				break;
			case '#':
				list.AddRange(new ItemName[1] { ItemName.MissileLauncher });
				break;
			case '^':
				list.AddRange(new ItemName[1] { ItemName.ShipMissile });
				break;
			case '-':
				list.AddRange(new ItemName[2]
				{
					ItemName.ShipMissileExpansion,
					ItemName.EnergyTank
				});
				break;
			case '+':
				list.AddRange(new ItemName[2]
				{
					ItemName.EnergyTank,
					ItemName.ShipMissileExpansion
				});
				break;
			case '?':
				list.AddRange(new ItemName[3]
				{
					ItemName.MissileExpansion,
					ItemName.ShipMissileExpansion,
					ItemName.MissileExpansion
				});
				break;
			default:
				throw new ArgumentException("Unsupported character: " + c);
			}
			num = (num + num2) % "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ(){}[]<>=,.!#^-+?".Length;
		}
		return list.ToArray();
	}
}
