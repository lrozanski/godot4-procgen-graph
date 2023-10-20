#if TOOLS
using System.Collections.Generic;
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator.Controls;

[Tool]
[GlobalClass]
public partial class GraphNodeRow : HBoxContainer {

    [Export]
    public bool FieldVisible {
        get => fieldVisible;
        set {
            fieldVisible = value;

            if (GetLabel() != null && GetField<Control>() != null) {
                ToggleField(fieldVisible);
            }
        }
    }

    [Export]
    public GraphNodeRowResource RowData { get; set; }

    public Label GetLabel() => GetChild<Label>(0);

    public T GetField<T>() where T : Control => GetChild<T>(1);

    public void ToggleField(bool active) {
        var field = GetField<Control>();

        if (field == null) {
            return;
        }
        field.Visible = active;
        UpdateLabelAlignment(active);
    }

    private void UpdateLabelAlignment(bool active) {
        var label = GetLabel();

        if (label == null || RowData == null) {
            return;
        }
        label.HorizontalAlignment = active switch {
            false when RowData.LeftPort => HorizontalAlignment.Left,
            false when RowData.RightPort => HorizontalAlignment.Right,
            false when RowData.LeftPort && RowData.RightPort => HorizontalAlignment.Center,
            _ => HorizontalAlignment.Right,
        };
    }

    private bool fieldVisible = true;
    private MapGenGraphNode graphNode;

    public override void _EnterTree() {
        graphNode = GetParent<MapGenGraphNode>();
        RowData ??= new GraphNodeRowResource();
        UpdateLabelAlignment(FieldVisible);
    }

    public override string[] _GetConfigurationWarnings() {
        var baseWarnings = base._GetConfigurationWarnings();
        List<string> warnings = new();

        if (baseWarnings != null) {
            warnings.AddRange(base._GetConfigurationWarnings());
        }

        if (GetChildCount() < 2) {
            warnings.Add("This node requires at least two children (in order): Label, Control");
        }

        if (GetChildOrNull<Label>(0) == null) {
            warnings.Add("First child must be a descendant of Label");
        }

        if (GetChildOrNull<Control>(1) == null) {
            warnings.Add("Second child must be a descendant of Control");
        }

        return warnings.ToArray();
    }
}
#endif
