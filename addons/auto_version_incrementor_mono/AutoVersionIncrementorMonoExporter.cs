#if TOOLS
using Godot;
using System;

[Tool]
public partial class AutoVersionIncrementorMonoExporter : EditorExportPlugin
{
    public const string CONFIG_PATH = "res://addons/auto_version_incrementor_mono/settings.cfg";

    public AutoVersionIncrementorMonoExporter() { }

    public override string _GetName()
    {
        return "Auto Version Incrementor Mono";
    }

    public override void _ExportBegin(string[] features, bool isDebug, string path, uint flags)
    {
        var settings = LoadSettings();
        if (settings.IncrementOnExport)
        {
            IncrementVersionNumber();
        }
    }

    public void IncrementVersionNumber()
    {
        string version = (string)ProjectSettings.GetSetting("application/config/version");
        if (string.IsNullOrWhiteSpace(version)) return;
        string[] data = version.Split('.');
        int build = 0;
        if (int.TryParse(data[data.Length - 1], out build))
        {
            build++;
            version = "";
            for(int i = 0; i < data.Length - 1; i++)
            {
                version += data[i] + ".";
            }
            version += build;
            ProjectSettings.SetSetting("application/config/version", version);
        }
    }

    public override void _ExportEnd()
    {
        
    }

    public AutoVersionIncrementorSettings LoadSettings()
    {
        ConfigFile config = new ConfigFile();
        config.Load(CONFIG_PATH);
        return new AutoVersionIncrementorSettings(config);
    }
}
#endif
