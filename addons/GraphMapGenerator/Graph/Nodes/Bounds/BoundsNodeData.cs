using Godot;

#if TOOLS

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Input;

[Tool]
[GlobalClass]
public partial class BoundsNodeData : GraphNodeData {

    [Export]
    public int X { get; set; }

    [Export]
    public int Y { get; set; }

    [Export]
    public int Width { get; set; }

    [Export]
    public int Height { get; set; }

}
#endif
