using Godot;

#if TOOLS

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Shape;

[Tool]
[GlobalClass]
public partial class ShapeNodeData : GraphNodeData {

    [Export]
    public ShapeType ShapeType { get; set; }

}
#endif
