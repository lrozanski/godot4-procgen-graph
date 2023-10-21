#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes;

[Tool]
[GlobalClass]
public abstract partial class GraphNodeData : Resource {

    [Export]
    public Vector2I Position { get; set; }

}
#endif
