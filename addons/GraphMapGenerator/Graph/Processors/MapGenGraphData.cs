#if TOOLS
using Godot;
using Godot.Collections;
using GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Processors;

[Tool]
[GlobalClass]
public partial class MapGenGraphData : Resource {

    [Export]
    public int Width { get; set; }

    [Export]
    public int Height { get; set; }

    private Array<GraphNodeData> nodes = new();

    public int[,] Generate() {
        var cellData = new int[Width, Height];

        return cellData;
    }

}
#endif
