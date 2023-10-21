#if TOOLS
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Input;

[Tool]
[GlobalClass]
public partial class InputNode : MapGenGraphNode {

    [Export]
    public InputNodeData NodeData { get; set; }

    private SpinBox seedSpinBox;
    private SpinBox widthSpinBox;
    private SpinBox heightSpinBox;

    public override void _EnterTree() {
        base._EnterTree();
        NodeData ??= new InputNodeData();

        seedSpinBox = GetNode<SpinBox>("Seed/SpinBox");
        widthSpinBox = GetNode<SpinBox>("Width/SpinBox");
        heightSpinBox = GetNode<SpinBox>("Height/SpinBox");

        TryConnect<double>(seedSpinBox, Range.SignalName.ValueChanged, value => NodeData.Seed = (int) value);
        TryConnect<double>(widthSpinBox, Range.SignalName.ValueChanged, value => NodeData.Width = (int) value);
        TryConnect<double>(heightSpinBox, Range.SignalName.ValueChanged, value => NodeData.Height = (int) value);
    }

}
#endif
