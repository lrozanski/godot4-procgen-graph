#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator;

[Tool]
public partial class MapGeneratorGraphEdit : GraphEdit {

    public override void _EnterTree() {
        ConnectionRequest += HandleConnectionRequest;
        DisconnectionRequest += HandleDisconnectionRequest;
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

}
#endif
