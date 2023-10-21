#if TOOLS
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Generate;

[Tool]
[GlobalClass]
public partial class GenerateNode : MapGenGraphNode {

    [Export]
    public GenerateNodeData NodeData { get; set; }

    private SpinBox cellValueSpinBox;

    public override void _EnterTree() {
        base._EnterTree();
        NodeData ??= new GenerateNodeData();
        cellValueSpinBox = GetNode<SpinBox>("CellValue/SpinBox");

        TryConnect<double>(cellValueSpinBox, Range.SignalName.ValueChanged, UpdateCellValue);
    }

    private void UpdateCellValue(double value) => NodeData.CellValue = (int) value;

}
#endif
