#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class InputNode : MapGenGraphNode {

    [Export]
    public int Seed {
        get => seed;
        set {
            seed = value;

            if (seedSpinBox != null) {
                seedSpinBox.Value = seed;
            }
        }
    }

    [Export]
    public int Width {
        get => width;
        set {
            width = value;

            if (widthSpinBox != null) {
                widthSpinBox.Value = width;
            }
        }
    }

    [Export]
    public int Height {
        get => height;
        set {
            height = value;

            if (heightSpinBox != null) {
                heightSpinBox.Value = height;
            }
        }
    }

    private int seed;
    private int width;
    private int height;

    private SpinBox seedSpinBox;
    private SpinBox widthSpinBox;
    private SpinBox heightSpinBox;

    public override void _EnterTree() {
        base._EnterTree();
        
        seedSpinBox = GetNode<SpinBox>("Seed/SpinBox");
        widthSpinBox = GetNode<SpinBox>("Width/SpinBox");
        heightSpinBox = GetNode<SpinBox>("Height/SpinBox");

        seedSpinBox.ValueChanged += value => seed = (int) value;
        widthSpinBox.ValueChanged += value => width = (int) value;
        heightSpinBox.ValueChanged += value => height = (int) value;
    }

}
#endif
