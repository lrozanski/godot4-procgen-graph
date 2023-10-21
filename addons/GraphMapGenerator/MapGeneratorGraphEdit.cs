#if TOOLS
using Godot;
using Godot.Collections;
using GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Input;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;
using OutputNode = GraphMapGenerator.addons.GraphMapGenerator.Graph.Nodes.Output.OutputNode;

namespace GraphMapGenerator.addons.GraphMapGenerator;

[Tool]
public partial class MapGeneratorGraphEdit : GraphEdit {

    public override void _EnterTree() {
        ConnectionRequest += HandleConnectionRequest;
        DisconnectionRequest += HandleDisconnectionRequest;
        DeleteNodesRequest += HandleDeleteNodesRequest;
    }

    private void HandleConnectionRequest(StringName node, long port, StringName toNode, long toPort) {
        if (node == toNode) {
            return;
        }
        ConnectNode(node, (int) port, toNode, (int) toPort);
        GetNode<MapGenGraphNode>((string) toNode).ToggleFieldVisibility((int) toPort, false);
    }

    private void HandleDisconnectionRequest(StringName node, long port, StringName toNode, long toPort) {
        if (node == toNode) {
            return;
        }
        DisconnectNode(node, (int) port, toNode, (int) toPort);
        GetNode<MapGenGraphNode>((string) toNode).ToggleFieldVisibility((int) toPort, true);
    }

    private void HandleDeleteNodesRequest(Array nodes) {
        foreach (var nodePath in nodes) {
            var nodeName = (string) nodePath.AsStringName();
            var node = GetNode<MapGenGraphNode>(nodeName);

            if (node is InputNode or OutputNode) {
                continue;
            }
            DisconnectAllPorts(node);
            RemoveChild(node);
            node.QueueFree();
        }
    }

    private void DisconnectAllPorts(MapGenGraphNode node) {
        foreach (var entry in GetConnectionList()) {
            var from = (string) entry["from_node"].AsStringName();
            var fromPort = entry["from_port"].AsInt32();
            var to = (string) entry["to_node"].AsStringName();
            var toPort = entry["to_port"].AsInt32();

            if (to == node.Name) {
                node.ToggleFieldVisibility(toPort, true);
            }
            if (from == node.Name || to == node.Name) {
                DisconnectNode(from, fromPort, to, toPort);
            }
        }
    }

}
#endif
