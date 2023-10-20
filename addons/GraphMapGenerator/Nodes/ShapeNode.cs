#if TOOLS
using System;
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class ShapeNode : MapGenGraphNode {

    [Export]
    public ShapeType ShapeType {
        get => shapeType;
        set {
            shapeType = value;
            shapeTypeDropdown?.Select((int) shapeType);
        }
    }

    [Export]
    public Rect2I Bounds { get; set; }

    private ShapeType shapeType;
    private OptionButton shapeTypeDropdown;

    public override void _EnterTree() {
        base._EnterTree();
        shapeTypeDropdown = GetNode<OptionButton>("ShapeType/OptionButton");

        foreach (var value in Enum.GetValues<ShapeType>()) {
            shapeTypeDropdown.AddItem(Enum.GetName(value), (int) value);
        }
        TryConnect<long>(shapeTypeDropdown, OptionButton.SignalName.ItemSelected, SelectItem);
    }

    private void SelectItem(long index) => shapeType = Enum.GetValues<ShapeType>()[index];

}
#endif
