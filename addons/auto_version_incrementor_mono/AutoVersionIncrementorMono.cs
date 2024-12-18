#if TOOLS
using Godot;
using System;

[Tool]
public partial class AutoVersionIncrementorMono : EditorPlugin
{
    private AutoVersionIncrementorMonoExporter _exporter;

	public override void _EnterTree()
	{
        // Initialization of the plugin goes here.
        _exporter = new AutoVersionIncrementorMonoExporter();
        AddExportPlugin(_exporter);
    }

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		RemoveExportPlugin(_exporter);
	}

    public override bool _Build()
    {
        var settings = _exporter.LoadSettings();
        if (settings.IncrementOnBuild)
        {
            GD.Print("building");
            _exporter.IncrementVersionNumber();
        }
		return true;
    }
}
#endif
