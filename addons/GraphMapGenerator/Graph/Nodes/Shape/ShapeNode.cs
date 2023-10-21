#if TOOLS
using System;
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Shape;

[Tool]
[GlobalClass]
public partial class ShapeNode : MapGenGraphNode {

    [Export]
    public ShapeNodeData NodeData { get; set; }

    private OptionButton shapeTypeDropdown;

    public override void _EnterTree() {
        base._EnterTree();
        NodeData ??= new ShapeNodeData();
        shapeTypeDropdown = GetNode<OptionButton>("ShapeType/OptionButton");

        foreach (var value in Enum.GetValues<ShapeType>()) {
            shapeTypeDropdown.AddItem(Enum.GetName(value), (int) value);
        }
        TryConnect<long>(shapeTypeDropdown, OptionButton.SignalName.ItemSelected, SelectItem);
    }

    private void SelectItem(long index) => NodeData.ShapeType = Enum.GetValues<ShapeType>()[index];

}
#endif
