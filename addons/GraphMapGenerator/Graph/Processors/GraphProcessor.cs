using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Processors;

public abstract partial class GraphProcessor : Node {

    [Export]
    public MapGenGraphData graphData;

    public abstract void ProcessCells(in int[,] cellData);

    public void Generate() {
        var cellData = graphData.Generate();
        ProcessCells(cellData);
    }

}
