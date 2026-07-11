using System.Collections.Generic;

namespace MP3Randomizer;

public class FakePickupLocations
{
	public static FakePickup[] get_fake_pickup_locations()
	{
		List<FakePickup> list = new List<FakePickup>();
		list.Add(FakePickup.create_fake_pickup(6078741217337776665uL, 8u, new byte[2] { 2, 14 }, 15u));
		list.Add(FakePickup.create_fake_pickup(6078741217337776665uL, 8u, new byte[2] { 2, 17 }, 15u));
		list.Add(FakePickup.create_fake_pickup(2774000464172079912uL, 2u, new byte[2] { 0, 203 }, 15u));
		list.Add(FakePickup.create_fake_pickup(4052690289582601366uL, 5u, new byte[2] { 1, 199 }, 15u));
		list.Add(FakePickup.create_fake_pickup(15732414849243282895uL, 0u, new byte[2] { 2, 18 }, 21u));
		list.Add(FakePickup.create_fake_pickup(13296637487518400273uL, 11u, new byte[2] { 4, 235 }, 23u));
		list.Add(FakePickup.create_fake_pickup(4133901881028310574uL, 10u, new byte[2] { 6, 187 }, 52u));
		list.Add(FakePickup.create_fake_pickup(9955656508473190866uL, 2u, new byte[2] { 0, 138 }, 63u));
		list.Add(FakePickup.create_fake_pickup(9955656508473190866uL, 2u, new byte[2] { 0, 140 }, 63u));
		list.Add(FakePickup.create_fake_pickup(9955656508473190866uL, 2u, new byte[2] { 0, 165 }, 63u));
		list.Add(FakePickup.create_fake_pickup(7063455547734255887uL, 3u, new byte[2] { 2, 178 }, 76u));
		list.Add(FakePickup.create_fake_pickup(7063455547734255887uL, 4u, new byte[2] { 1, 210 }, 76u));
		list.Add(FakePickup.create_fake_pickup(7063455547734255887uL, 4u, new byte[2] { 1, 230 }, 76u));
		list.Add(FakePickup.create_fake_pickup(17766988414710659705uL, 3u, new byte[2] { 1, 219 }, 97u));
		list.Add(FakePickup.create_fake_pickup(17766988414710659705uL, 6u, new byte[2] { 0, 139 }, 97u));
		list.Add(FakePickup.create_fake_pickup(9708827741160794862uL, 5u, new byte[2] { 2, 83 }, 98u));
		list.Add(FakePickup.create_fake_pickup(9708827741160794862uL, 6u, new byte[2] { 1, 58 }, 98u));
		list.Add(FakePickup.create_fake_pickup(4585599704880367469uL, 3u, new byte[2] { 1, 15 }, 99u));
		list.Add(FakePickup.create_fake_pickup(4585599704880367469uL, 4u, new byte[2] { 0, 120 }, 99u));
		return list.ToArray();
	}
}
