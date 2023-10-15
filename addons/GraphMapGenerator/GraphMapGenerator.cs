#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator;

[Tool]
public partial class GraphMapGenerator : EditorPlugin {

    private Control graphEditScene;

    public override void _EnterTree() {
        graphEditScene = GD.Load<PackedScene>("res://addons/GraphMapGenerator/map_generation_graph_dock.tscn").Instantiate<Control>();
        AddControlToBottomPanel(graphEditScene, "Map Generation Graph");
    }

    public override void _ExitTree() {
        RemoveChild(graphEditScene);
        RemoveControlFromBottomPanel(graphEditScene);
    }
}
#endif
