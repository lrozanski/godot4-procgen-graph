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
        shapeTypeDropdown.ItemSelected += index => shapeType = Enum.GetValues<ShapeType>()[index];
    }

}
#endif
