#if TOOLS
using System.Net.Http.Headers;
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Input;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Bounds;

[Tool]
[GlobalClass]
public partial class BoundsNode : MapGenGraphNode {

    [Export]
    public BoundsNodeData NodeData { get; set; }

    private SpinBox xSpinBox;
    private SpinBox ySpinBox;
    private SpinBox widthSpinBox;
    private SpinBox heightSpinBox;

    public override void _EnterTree() {
        base._EnterTree();
        NodeData ??= new BoundsNodeData();

        xSpinBox = GetNode<SpinBox>("X/SpinBox");
        ySpinBox = GetNode<SpinBox>("Y/SpinBox");
        widthSpinBox = GetNode<SpinBox>("Width/SpinBox");
        heightSpinBox = GetNode<SpinBox>("Height/SpinBox");

        TryConnect<double>(xSpinBox, Range.SignalName.ValueChanged, UpdateBoundsX);
        TryConnect<double>(ySpinBox, Range.SignalName.ValueChanged, UpdateBoundsY);
        TryConnect<double>(widthSpinBox, Range.SignalName.ValueChanged, UpdateBoundsWidth);
        TryConnect<double>(heightSpinBox, Range.SignalName.ValueChanged, UpdateBoundsHeight);
    }

    private void UpdateBoundsX(double value) => NodeData.X = (int) value;

    private void UpdateBoundsY(double value) => NodeData.Y = (int) value;

    private void UpdateBoundsWidth(double value) => NodeData.Width = (int) value;

    private void UpdateBoundsHeight(double value) => NodeData.Height = (int) value;

}
#endif
