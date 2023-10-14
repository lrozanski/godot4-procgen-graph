#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class BoundsNode : GraphNode {

    [Export]
    public Rect2I Bounds {
        get => bounds;
        set {
            bounds = value;

            if (xSpinBox != null && ySpinBox != null && widthSpinBox != null && heightSpinBox != null) {
                xSpinBox.Value = bounds.Position.X;
                ySpinBox.Value = bounds.Position.Y;
                widthSpinBox.Value = bounds.Size.X;
                heightSpinBox.Value = bounds.Size.Y;
            }
        }
    }

    private Rect2I bounds;

    private SpinBox xSpinBox;
    private SpinBox ySpinBox;
    private SpinBox widthSpinBox;
    private SpinBox heightSpinBox;

    public override void _EnterTree() {
        xSpinBox = GetNode<SpinBox>("X/SpinBox");
        ySpinBox = GetNode<SpinBox>("Y/SpinBox");
        widthSpinBox = GetNode<SpinBox>("Width/SpinBox");
        heightSpinBox = GetNode<SpinBox>("Height/SpinBox");

        xSpinBox.ValueChanged += value => bounds = new Rect2I((int) value, bounds.Position.Y, bounds.Size.X, bounds.Size.Y);
        ySpinBox.ValueChanged += value => bounds = new Rect2I(bounds.Position.X, (int) value, bounds.Size.X, bounds.Size.Y);
        widthSpinBox.ValueChanged += value => bounds = new Rect2I(bounds.Position.X, bounds.Position.Y, (int) value, bounds.Size.Y);
        heightSpinBox.ValueChanged += value => bounds = new Rect2I(bounds.Position.X, bounds.Position.Y, bounds.Size.X, (int) value);
    }

}
#endif
