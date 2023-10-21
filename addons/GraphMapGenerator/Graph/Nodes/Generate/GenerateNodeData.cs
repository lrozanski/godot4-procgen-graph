using Godot;

#if TOOLS

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Generate;

[Tool]
[GlobalClass]
public partial class GenerateNodeData : GraphNodeData {

    [Export]
    public int CellValue { get; set; }

}
#endif
