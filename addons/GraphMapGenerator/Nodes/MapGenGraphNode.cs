#if TOOLS
using System.Collections.Generic;
using System.Linq;
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Controls;

namespace GraphMapGenerator.addons.GraphMapGenerator.Nodes;

[Tool]
[GlobalClass]
public abstract partial class MapGenGraphNode : GraphNode {

    public GraphNodeRow GetField(int index) => GetChild<GraphNodeRow>(index);

    public void ToggleFieldVisibility(int index, bool state) => GetField(index).FieldVisible = state;
    
    public override void _EnterTree() {
        var callableWithArgs = Callable.From<Node>(UpdatePortsWithArgs);
        var callable = Callable.From(UpdatePorts);

        if (!IsConnected(Node.SignalName.ChildEnteredTree, callableWithArgs)) {
            Connect(Node.SignalName.ChildEnteredTree, callableWithArgs);
        }
        if (!IsConnected(Node.SignalName.ChildExitingTree, callableWithArgs)) {
            Connect(Node.SignalName.ChildExitingTree, callableWithArgs);
        }
        if (!IsConnected(Node.SignalName.ChildOrderChanged, callable)) {
            Connect(Node.SignalName.ChildOrderChanged, callable);
        }
        if (!IsConnected(CanvasItem.SignalName.VisibilityChanged, callable)) {
            Connect(CanvasItem.SignalName.VisibilityChanged, callable);
        }
    }

    private void UpdatePortsWithArgs(Node node) => UpdatePorts();

    public void UpdatePorts() {
        if (!IsInstanceValid(this)) {
            return;
        }
        var nodes = GetChildren();

        for (var i = 0; i < nodes.Count; i++) {
            var child = nodes[i];

            if (!IsInstanceValid(child)) {
                continue;
            }
            if (child is not GraphNodeRow row) {
                SetSlot(i, false, -1, Colors.White, false, -1, Colors.White);
                continue;
            }
            var data = row.RowData;
            if (data == null) {
                return;
            }
            SetSlot(i, data.LeftPort, (int) data.ValueType, data.PortColor, data.RightPort, (int) data.ValueType, data.PortColor);
        }
        QueueRedraw();
    }

    public override string[] _GetConfigurationWarnings() {
        var baseWarnings = base._GetConfigurationWarnings();
        List<string> warnings = new();

        if (baseWarnings != null) {
            warnings.AddRange(base._GetConfigurationWarnings());
        }
        if (GetChildren().Any(child => child is not GraphNodeRow)) {
            warnings.Add("This node only supports GraphNodeRow controls");
        }
        return warnings.ToArray();
    }
}
#endif
