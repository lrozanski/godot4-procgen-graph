#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Controls;

[Tool]
[GlobalClass]
public partial class GraphNodeRowResource : Resource {

    [Export]
    public GraphNodeValueType valueType;

    [Export]
    public bool leftPort;
    
    [Export]
    public bool rightPort;

}
#endif
