using MP3Randomizer;
using Xunit;

namespace MP3Randomizer.Tests;

public class ConfigurationTests
{
    [Fact]
    public void GetConfiguration_ParsesRequiredAndOptionalFlags()
    {
        Configuration configuration = Configuration.get_configuration(
        [
            "--input-path",
            @"C:\input path",
            "--output-path",
            @"C:\output path",
            "--layout",
            "SEED123",
            "--starting-items",
            "original-with-command",
            "--starting-location",
            "valhalla",
            "--random-door-colors",
            "--random-welding-colors",
            "--hyper-hints",
            "--fast-flying",
            "--require-launcher",
            "--require-ship-missile",
            "--phaaze-skip",
        ]);

        Assert.Equal(@"C:\input path", configuration.input_path);
        Assert.Equal(@"C:\output path", configuration.output_path);
        Assert.Equal("SEED123", configuration.encoded_permalink);
        Assert.True(configuration.random_door_colors);
        Assert.True(configuration.random_welding_colors);
        Assert.True(configuration.add_hyper_hints);
        Assert.True(configuration.add_fast_flying);
        Assert.True(configuration.require_launcher);
        Assert.True(configuration.require_ship_missile);
        Assert.True(configuration.phaaze_skip);
        Assert.Equal(StartingItemsType.OriginalWithCommand, configuration.starting_items_type);
        Assert.Equal(StartingLocationType.Valhalla, configuration.starting_location_type);
    }

    [Fact]
    public void GetConfiguration_ParsesCustomStartingLocation()
    {
        Configuration configuration = Configuration.get_configuration(
        [
            "--input-path",
            "input",
            "--output-path",
            "output",
            "--layout",
            "SEED123",
            "--starting-items",
            "custom",
            "Missile Expansion",
            "--starting-location",
            "custom",
            "1A",
            "2B",
        ]);

        Assert.Equal(StartingItemsType.Custom, configuration.starting_items_type);
        Assert.Equal("Missile Expansion", configuration.starting_items_custom);
        Assert.Equal(StartingLocationType.Custom, configuration.starting_location_type);
        Assert.Equal(0x1Aul, configuration.starting_world);
        Assert.Equal(0x2Bul, configuration.starting_area);
    }
}
