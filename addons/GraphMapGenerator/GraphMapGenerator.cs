#if TOOLS
using Godot;
using GraphMapGenerator.addons.GraphMapGenerator.Nodes;

namespace GraphMapGenerator.addons.GraphMapGenerator;

[Tool]
public partial class GraphMapGenerator : EditorPlugin {

    private MapGenGraphEdit graphEdit;
    private InputNode inputNode;
    private OutputNode outputNode;
    private BoundsNode boundsNode;

    public override void _EnterTree() {
        graphEdit = new MapGenGraphEdit();

        inputNode = GD.Load<PackedScene>("res://addons/GraphMapGenerator/Nodes/input_node.tscn").Instantiate<InputNode>();
        graphEdit.AddChild(inputNode);
        
        outputNode = GD.Load<PackedScene>("res://addons/GraphMapGenerator/Nodes/output_node.tscn").Instantiate<OutputNode>();
        outputNode.PositionOffset = new Vector2(1200, 0);
        graphEdit.AddChild(outputNode);
        
        boundsNode = GD.Load<PackedScene>("res://addons/GraphMapGenerator/Nodes/bounds_node.tscn").Instantiate<BoundsNode>();
        boundsNode.PositionOffset = new Vector2(400, 200);
        graphEdit.AddChild(boundsNode);

        AddControlToBottomPanel(graphEdit, "Map Generation Graph");
    }

    public override void _ExitTree() {
        graphEdit.RemoveChild(inputNode);
        
        inputNode.Free();
        inputNode = null;
        
        outputNode.Free();
        outputNode = null;
        
        boundsNode.Free();
        boundsNode = null;
        
        RemoveControlFromBottomPanel(graphEdit);
    }

}
#endif
