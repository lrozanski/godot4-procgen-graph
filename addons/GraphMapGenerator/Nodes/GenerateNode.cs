#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class GenerateNode : GraphNode {

    [Export]
    public Rect2I Bounds { get; set; }

    [Export]
    public int CellValue {
        get => cellValue;
        set {
            cellValue = value;

            if (cellValueSpinBox != null) {
                cellValueSpinBox.Value = cellValue;
            }
        }
    }

    private int cellValue;
    private SpinBox cellValueSpinBox;

    public override void _EnterTree() {
        cellValueSpinBox = GetNode<SpinBox>("CellValue/SpinBox");
    }

}
#endif
