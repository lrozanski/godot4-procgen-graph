#if TOOLS
using System.Collections.Generic;
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator;

[Tool]
public partial class NodePopupMenu : PopupMenu {

    private static readonly Dictionary<long, PackedScene> IdToNodeScene = new() {
        { 0L, GD.Load<PackedScene>("res://addons/GraphMapGenerator/Nodes/bounds_node.tscn") }
    };

    private MapGeneratorGraphEdit graphEdit;
    private Vector2 nodePosition;

    public override void _EnterTree() {
        graphEdit = Owner.GetNode<MapGeneratorGraphEdit>("GraphEdit");
        graphEdit.PopupRequest += position => {
            nodePosition = position + graphEdit.ScrollOffset;
            Position = (Vector2I) position;
            Show();
        };
        
        IdPressed += id => {
            var node = IdToNodeScene[id].Instantiate<GraphNode>();
            node.PositionOffset = nodePosition;
            graphEdit.AddChild(node);
        };
    }

}
#endif
