#if TOOLS
using Godot;

public class AutoVersionIncrementorSettings
{
    public const string SETTINGS_SECTION = "settings";

    public bool IncrementOnBuild { get; set; } = false;
    public bool IncrementOnExport { get; set; } = true;

    public AutoVersionIncrementorSettings() { }
    public AutoVersionIncrementorSettings(ConfigFile config)
    {
        if (!config.HasSection(SETTINGS_SECTION))
        {
            config.SetValue(SETTINGS_SECTION, "increment_on_build", IncrementOnBuild);
            config.SetValue(SETTINGS_SECTION, "increment_on_export", IncrementOnExport);
            config.Save(AutoVersionIncrementorMonoExporter.CONFIG_PATH);
        }
        IncrementOnBuild = (bool)config.GetValue(SETTINGS_SECTION, "increment_on_build", false);
        IncrementOnExport = (bool)config.GetValue(SETTINGS_SECTION, "increment_on_export", true);
    }
}
#endif