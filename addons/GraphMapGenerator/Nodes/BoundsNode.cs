#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class BoundsNode : MapGenGraphNode {

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
        base._EnterTree();

        xSpinBox = GetNode<SpinBox>("X/SpinBox");
        ySpinBox = GetNode<SpinBox>("Y/SpinBox");
        widthSpinBox = GetNode<SpinBox>("Width/SpinBox");
        heightSpinBox = GetNode<SpinBox>("Height/SpinBox");

        var xCallable = Callable.From<double>(UpdateBoundsX);
        var yCallable = Callable.From<double>(UpdateBoundsY);
        var widthCallable = Callable.From<double>(UpdateBoundsWidth);
        var heightCallable = Callable.From<double>(UpdateBoundsHeight);

        if (!xSpinBox.IsConnected(Range.SignalName.ValueChanged, xCallable)) {
            xSpinBox.Connect(Range.SignalName.ValueChanged, xCallable);
        }
        if (!ySpinBox.IsConnected(Range.SignalName.ValueChanged, yCallable)) {
            ySpinBox.Connect(Range.SignalName.ValueChanged, yCallable);
        }
        if (!widthSpinBox.IsConnected(Range.SignalName.ValueChanged, widthCallable)) {
            widthSpinBox.Connect(Range.SignalName.ValueChanged, widthCallable);
        }
        if (!heightSpinBox.IsConnected(Range.SignalName.ValueChanged, heightCallable)) {
            heightSpinBox.Connect(Range.SignalName.ValueChanged, heightCallable);
        }
    }

    private void UpdateBoundsX(double value) => bounds = new Rect2I((int) value, bounds.Position.Y, bounds.Size.X, bounds.Size.Y);

    private void UpdateBoundsY(double value) => bounds = new Rect2I(bounds.Position.X, (int) value, bounds.Size.X, bounds.Size.Y);

    private void UpdateBoundsWidth(double value) => bounds = new Rect2I(bounds.Position.X, bounds.Position.Y, (int) value, bounds.Size.Y);

    private void UpdateBoundsHeight(double value) => bounds = new Rect2I(bounds.Position.X, bounds.Position.Y, bounds.Size.X, (int) value);

}
#endif
