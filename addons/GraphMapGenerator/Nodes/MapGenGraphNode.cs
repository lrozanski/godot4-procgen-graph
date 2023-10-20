#if TOOLS
using System;
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
        TryConnect<Node>(this, Node.SignalName.ChildEnteredTree, UpdatePortsWithArgs);
        TryConnect<Node>(this, Node.SignalName.ChildExitingTree, UpdatePortsWithArgs);
        TryConnect(this, Node.SignalName.ChildOrderChanged, UpdatePorts);
        TryConnect(this, CanvasItem.SignalName.VisibilityChanged, UpdatePorts);
    }

    private void UpdatePortsWithArgs(Node node) => UpdatePorts();

    public void UpdatePorts() {
        if (!IsInstanceValid(this) || GetChildCount() == 0) {
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
        if (GetChildCount() > 0 && GetChildren().Any(child => child is not GraphNodeRow)) {
            warnings.Add("This node only supports GraphNodeRow controls");
        }
        return warnings.ToArray();
    }

    protected void TryConnect(Node node, StringName signalName, Action action) => TryConnect(node, signalName, Callable.From(action));

    protected void TryConnect<[MustBeVariant] T>(Node node, StringName signalName, Action<T> action) => TryConnect(node, signalName, Callable.From(action));

    protected void TryConnect<TR>(Node node, StringName signalName, Func<TR> func) => TryConnect(node, signalName, Callable.From(func));

    protected void TryConnect<[MustBeVariant] T, TR>(Node node, StringName signalName, Func<T, TR> func) => TryConnect(node, signalName, Callable.From(func));

    private void TryConnect(Node node, StringName signalName, Callable callable) {
        if (node.IsConnected(signalName, callable)) {
            return;
        }
        node.Connect(signalName, callable);
    }
}
#endif
