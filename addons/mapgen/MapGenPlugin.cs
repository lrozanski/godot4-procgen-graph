#if TOOLS
using System.Collections.Generic;
using Godot;
using procgengraph.addons.mapgen.resources;

namespace procgengraph.addons.mapgen;

[Tool]
public partial class MapGenPlugin : EditorPlugin {

    private record struct CustomResourceEntry(string name, CSharpScript script);

    private static readonly HashSet<CustomResourceEntry> CustomResources = new() {
        new CustomResourceEntry(nameof(MapGenResource), GD.Load<CSharpScript>("res://addons/mapgen/resources/MapGenResource.cs")),
        new CustomResourceEntry(nameof(MapInputNodeResource), GD.Load<CSharpScript>("res://addons/mapgen/resources/MapInputNodeResource.cs")),
    };

    private MapGenGraph mapGenGraph;

    public override void _EnterTree() {
        RegisterCustomResources();

        mapGenGraph ??= new MapGenGraph();
        AddControlToBottomPanel(mapGenGraph, "Map Generator Graph");
    }

    private void RegisterCustomResources() {
        foreach (var (name, script) in CustomResources) {
            AddCustomType(name, nameof(Resource), script, null);
        }
    }

    private void RemoveCustomResources() {
        foreach (var (name, _) in CustomResources) {
            RemoveCustomType(name);
        }
    }

    public override void _ExitTree() {
        RemoveControlFromBottomPanel(mapGenGraph);
        RemoveCustomResources();
    }

    public override bool _Handles(GodotObject node) => node is MapGenResource;

    public override void _Edit(GodotObject node) => mapGenGraph.Edit(node as MapGenResource);

    public override void _MakeVisible(bool visible) {
        if (visible) {
            mapGenGraph.Show();
        } else {
            mapGenGraph.Hide();
        }
    }

}
#endif
