#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Controls;

[Tool]
[GlobalClass]
public partial class GraphNodeRowResource : Resource {

    [Export]
    public GraphNodeValueType ValueType { get; set; }

    [Export]
    public bool LeftPort { get; set; }
    
    [Export]
    public bool RightPort { get; set; }

    public Color PortColor => GraphNodeConstants.ValueToColor[ValueType];
}
#endif
