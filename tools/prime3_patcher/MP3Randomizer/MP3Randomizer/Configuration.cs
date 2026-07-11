using System;

namespace MP3Randomizer;

public class Configuration
{
	public string input_path;

	public string output_path;

	public string encoded_permalink;

	public bool random_door_colors;

	public bool random_welding_colors;

	public StartingItemsType starting_items_type;

	public string starting_items_custom;

	public StartingLocationType starting_location_type;

	public ulong starting_world;

	public ulong starting_area;

	public bool add_hyper_hints;

	public bool add_fast_flying;

	public bool phaaze_skip;

	public bool require_launcher;

	public bool require_ship_missile;

	public static Configuration get_configuration(string[] cli_args)
	{
		Configuration configuration = new Configuration();
		string[] array = new string[6] { "-h", "--h", "-help", "--help", "help", "h" };
		if (cli_args.Length == 0 || Array.IndexOf(array, cli_args[0]) != -1)
		{
			display_help();
			Environment.Exit(0);
		}
		configuration.random_door_colors = false;
		configuration.random_welding_colors = false;
		configuration.add_hyper_hints = false;
		configuration.add_fast_flying = false;
		configuration.phaaze_skip = false;
		configuration.require_launcher = false;
		configuration.require_ship_missile = false;
		configuration.starting_items_type = StartingItemsType.OriginalWithCommand;
		configuration.starting_location_type = StartingLocationType.Norion;
		for (int i = 0; i < cli_args.Length; i++)
		{
			if (cli_args[i] == "--input-path")
			{
				configuration.input_path = cli_args[i + 1];
			}
			else if (cli_args[i] == "--output-path")
			{
				configuration.output_path = cli_args[i + 1];
			}
			else if (cli_args[i] == "--layout")
			{
				configuration.encoded_permalink = cli_args[i + 1];
			}
			else if (cli_args[i] == "--random-door-colors" || cli_args[i] == "-random-door-colors")
			{
				configuration.random_door_colors = true;
			}
			else if (cli_args[i] == "--random-welding-colors" || cli_args[i] == "-random-welding-colors")
			{
				configuration.random_welding_colors = true;
			}
			else if (cli_args[i] == "--hyper-hints" || cli_args[i] == "-hyper-hints")
			{
				configuration.add_hyper_hints = true;
			}
			else if (cli_args[i] == "--fast-flying" || cli_args[i] == "-fast_flying")
			{
				configuration.add_fast_flying = true;
			}
			else if (cli_args[i] == "--phaaze-skip" || cli_args[i] == "-phaaze-skip")
			{
				configuration.phaaze_skip = true;
			}
			else if (cli_args[i] == "--require-launcher" || cli_args[i] == "-require-launcher")
			{
				configuration.require_launcher = true;
			}
			else if (cli_args[i] == "--require-ship-missile" || cli_args[i] == "-require-ship-missile")
			{
				configuration.require_ship_missile = true;
			}
			else if (cli_args[i] == "--starting-items")
			{
				if (cli_args[i + 1] == "original-with-command")
				{
					configuration.starting_items_type = StartingItemsType.OriginalWithCommand;
					continue;
				}
				if (cli_args[i + 1] == "post-norion-no-lasso")
				{
					configuration.starting_items_type = StartingItemsType.PostNorionNoLasso;
					continue;
				}
				if (!(cli_args[i + 1] == "custom"))
				{
					throw new ArgumentException("Unrecognized starting items: " + cli_args[i + 1]);
				}
				configuration.starting_items_type = StartingItemsType.Custom;
				configuration.starting_items_custom = cli_args[i + 2];
			}
			else
			{
				if (!(cli_args[i] == "--starting-location"))
				{
					continue;
				}
				if (cli_args[i + 1] == "olympus")
				{
					configuration.starting_location_type = StartingLocationType.Olympus;
					continue;
				}
				if (cli_args[i + 1] == "norion")
				{
					configuration.starting_location_type = StartingLocationType.Norion;
					continue;
				}
				if (cli_args[i + 1] == "valhalla")
				{
					configuration.starting_location_type = StartingLocationType.Valhalla;
					continue;
				}
				if (!(cli_args[i + 1] == "custom"))
				{
					throw new ArgumentException("Unrecognized starting location: " + cli_args[i + 1]);
				}
				configuration.starting_location_type = StartingLocationType.Custom;
				configuration.starting_world = Convert.ToUInt64("0x" + cli_args[i + 2].ToString().Trim(), 16);
				configuration.starting_area = Convert.ToUInt64("0x" + cli_args[i + 3].ToString().Trim(), 16);
			}
		}
		return configuration;
	}

	public static void display_help()
	{
		Console.WriteLine("USAGE");
		Console.WriteLine("MP3Randomizer.exe [FLAGS]");
		Console.WriteLine("");
		Console.WriteLine("REQUIRED FLAGS");
		Console.WriteLine("--input-path \"INPUT_PATH\"           Folder containing the pak files");
		Console.WriteLine("--output-path \"OUTPUT_PATH\"         Folder to save the randomized paks to");
		Console.WriteLine("--layout \"LAYOUT\"                   The item layout/seed");
		Console.WriteLine("");
		Console.WriteLine("OPTIONAL FLAGS");
		Console.WriteLine("--fast-flying                       Reduces the duration of gunship travel.");
		Console.WriteLine("--hyper-hints                       Adds hints for Hyper Missile and Hyper Grapple on Valhalla Scanbots.");
		Console.WriteLine("--skip-phaaze                       Flying to Phaaze brings you to the end cutscene.");
		Console.WriteLine("--require-launcher                  Missile Launcher will be required to fire missiles.");
		Console.WriteLine("--require-ship-missile              The main Ship Missile item will be required to use ship missiles.");
		Console.WriteLine("--random-door-colors                Randomize the colors of doors");
		Console.WriteLine("--random-welding-colors             Randomize the beam colors during welding puzzles");
		Console.WriteLine("--starting-items ITEMS_TYPE         The items the player will start with");
		Console.WriteLine("                                    ('original-with-command', 'post-norion-no-lasso',");
		Console.WriteLine("                                    'custom' [custom_starting_items])");
		Console.WriteLine("--starting-location LOCATION_TYPE   The starting location for the player");
		Console.WriteLine("                                    ('olympus', 'norion', 'valhalla', 'custom' [world_id] [area_id])");
	}
}
