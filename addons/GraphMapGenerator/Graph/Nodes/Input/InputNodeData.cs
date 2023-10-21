using Godot;

#if TOOLS

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Input;

[Tool]
[GlobalClass]
public partial class InputNodeData : GraphNodeData {

    [Export]
    public int Seed { get; set; }

    [Export]
    public int Width { get; set; }

    [Export]
    public int Height { get; set; }

}
#endif
