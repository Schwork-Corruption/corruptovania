using System;

namespace MP3Randomizer;

public class CosmeticPatches
{
	public static void add_random_door_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "DOOR" }, new uint[1], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 71, 180, 232, 99 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_actor_modinca_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "ACTR" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 248, 223, 108, 210 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_camera_filter_keyframe_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "FILT" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_color_modulate_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "CLRM" }, new uint[0], new uint[0], new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 214, 163, 210, 111 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 80, 55, 160, 193 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_dialogue_menu_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "DGMN" }, new uint[0], new uint[0], new PropertyModification[5]
		{
			PropertyModification.import(new byte[4] { 239, 80, 89, 101 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 105, 253, 178, 101 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 63, 57, 230, 53 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 96, 215, 133, 105 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 89, 8, 239, 57 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_subtitles_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "SUBT" }, new uint[0], new uint[0], new PropertyModification[3]
		{
			PropertyModification.import(new byte[4] { 63, 57, 230, 53 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 96, 215, 133, 105 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 89, 8, 239, 57 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_text_pane_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "TXPN" }, new uint[0], new uint[0], new PropertyModification[3]
		{
			PropertyModification.import(new byte[4] { 63, 57, 230, 53 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 96, 215, 133, 105 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 89, 8, 239, 57 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_distance_fog_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "DFOG" }, new uint[0], new uint[0], new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 183, 36, 104, 67 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_dynamic_light_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "DLHT" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_fish_cloud_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "FISH" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 31, 131, 211, 80 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_fog_overlay_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "FOGO" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_fog_volume_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "FOGV" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 229, 120, 192, 221 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_grapple_point_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "GRAP" }, new uint[0], new uint[0], new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 198, 134, 147, 39 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 63, 168, 5, 146 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_light_volume_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "LVOL" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 62, 219, 227, 114 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_multi_model_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "MMDL" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 248, 223, 108, 210 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_skybox_modinca_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "SBMI" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_visor_goo_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "VGOO" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_debris_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "DEBR" }, new uint[0], new uint[0], new PropertyModification[3]
		{
			PropertyModification.import(new byte[4] { 58, 86, 52, 216 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 124, 110, 190, 152 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 90, 245, 134, 125 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_physics_debris_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "PDBR" }, new uint[0], new uint[0], new PropertyModification[3]
		{
			PropertyModification.import(new byte[4] { 58, 86, 52, 216 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 124, 110, 190, 152 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 90, 245, 134, 125 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_random_visor_flare_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "FLAR" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_random_water_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "WATR" }, new uint[0], new uint[0], new PropertyModification[4]
		{
			PropertyModification.import(new byte[4] { 4, 19, 152, 213 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 90, 150, 33, 140 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 19, 181, 108, 34 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 229, 120, 192, 221 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_area_attributes_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "REAA" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 55, 199, 208, 157 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_scan_beam_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "SBEM" }, new uint[0], new uint[0], new PropertyModification[4]
		{
			PropertyModification.import(new byte[4] { 76, 65, 220, 212 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 202, 213, 174, 122 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 30, 82, 18, 78 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 152, 198, 96, 224 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_mogenar_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 9708827741160794862uL }, new string[1] { "SDB1" }, new uint[0], new uint[0], new PropertyModification[6]
		{
			PropertyModification.import(new byte[4] { 49, 150, 178, 231 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 119, 211, 179, 134 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 169, 190, 16, 129 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 124, 229, 196, 124 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 249, 101, 108, 57 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 215, 20, 42, 254 }, new RandomColorPropertyValue(rng))
		}));
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[1] { 9708827741160794862uL }, new string[1] { "SBO1" }, new uint[0], new uint[0], new PropertyModification[1] { PropertyModification.import(new byte[4] { 159, 65, 73, 175 }, new RandomColorPropertyValue(rng)) }));
	}

	public static void add_plant_scarab_swarm_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "PSSM" }, new uint[0], new uint[0], new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 191, 149, 161, 48 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 139, 74, 7, 210 }, new RandomColorPropertyValue(rng))
		}));
	}

	public static void add_context_welding_color_patch(Patches patches, Random rng)
	{
		patches.object_modification_patches.Add(ScriptObjectModificationPatch.import(new ulong[0], new string[1] { "CAWL" }, new uint[0], new uint[0], new PropertyModification[2]
		{
			PropertyModification.import(new byte[4] { 191, 172, 231, 98 }, new RandomColorPropertyValue(rng)),
			PropertyModification.import(new byte[4] { 55, 97, 200, 232 }, new RandomColorPropertyValue(rng))
		}));
	}
}
