#if TOOLS
using Godot;
using Godot.Collections;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

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
    }

    private void HandleDisconnectionRequest(StringName node, long port, StringName toNode, long toPort) {
        if (node == toNode) {
            return;
        }
        DisconnectNode(node, (int) port, toNode, (int) toPort);
    }

    private void HandleDeleteNodesRequest(Array nodes) {
        foreach (var nodePath in nodes) {
            var nodeName = (string) nodePath.AsStringName();
            var node = GetNode<GraphNode>(nodeName);

            if (node is InputNode or OutputNode) {
                continue;
            }
            DisconnectAllPorts(node);
            RemoveChild(node);
            node.QueueFree();
        }
    }

    private void DisconnectAllPorts(GraphNode node) {
        foreach (var entry in GetConnectionList()) {
            var from = (string) entry["from_node"].AsStringName();
            var fromPort = entry["from_port"].AsInt32();
            var to = (string) entry["to_node"].AsStringName();
            var toPort = entry["to_port"].AsInt32();

            if (from == node.Name || to == node.Name) {
                DisconnectNode(from, fromPort, to, toPort);
            }
        }
    }

}
#endif
