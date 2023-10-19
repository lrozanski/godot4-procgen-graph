#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public partial class GenerateNode : MapGenGraphNode {

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

    [Export]
    private SpinBox cellValueSpinBox;

    private int cellValue;

}
#endif
