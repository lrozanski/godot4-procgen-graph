#if TOOLS
using Godot;

namespace procgengraph.addons.mapgen;

[Tool]
public partial class MapGen : EditorPlugin {

    public static Node EditorSceneRoot { get; private set; }

    private MapGenGraph mapGenGraph;

    public override void _EnterTree() {
        EditorSceneRoot = GetEditorInterface().GetEditedSceneRoot();
        mapGenGraph ??= new MapGenGraph();
        mapGenGraph.editorInterface = GetEditorInterface();

        AddControlToBottomPanel(mapGenGraph, "Map Generator Graph");
    }

    public override void _ExitTree() {
        RemoveControlFromBottomPanel(mapGenGraph);
    }

    public override bool _Handles(GodotObject node) => node is TileMap;

    public override void _Edit(GodotObject node) {
        mapGenGraph.Edit(node as TileMap);
    }

    public override void _Clear() {
        mapGenGraph.Clear();
    }

    public override void _MakeVisible(bool visible) {
        if (visible) {
            mapGenGraph.Show();
        } else {
            mapGenGraph.Clear();
            mapGenGraph.Hide();
        }
    }

}
#endif
