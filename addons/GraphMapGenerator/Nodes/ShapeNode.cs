#if TOOLS
using System;
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class ShapeNode : GraphNode {

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
        shapeTypeDropdown = GetNode<OptionButton>("ShapeType/OptionButton");
        var values = Enum.GetValues<ShapeType>();

        foreach (var value in values) {
            shapeTypeDropdown.AddItem(Enum.GetName(value), (int) value);
        }
        shapeTypeDropdown.ItemSelected += index => shapeType = values[index];
    }

}
#endif
