#if TOOLS
using Godot;
using Godot.Collections;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class OutputNode : GraphNode {

    [Export]
    public Array<Array<int>> MapData { get; set; }

}
#endif
