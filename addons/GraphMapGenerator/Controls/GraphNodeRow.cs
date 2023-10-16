#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Controls;

[Tool]
[GlobalClass]
public partial class GraphNodeRow : HBoxContainer {

    [Export]
    private GraphNodeRowResource rowData;
    
    public Label Label { get; set; }

    public T GetField<T>() where T : Control => GetChild<T>(1);

    public override void _EnterTree() {
        Label = GetChild<Label>(0);
    }

    public void ToggleField(bool active) {
        GetField<Control>().Visible = active;
    }

}
#endif
