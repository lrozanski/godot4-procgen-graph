using Godot;
using procgengraph.addons.mapgen.editor;

namespace procgengraph;

[Tool]
public partial class MapGenGraph : GraphEdit {

    public EditorInterface editorInterface { get; set; }

    private MapInputNode inputNode;
    private SceneTreeDialog sceneTreeDialog;
    private PackedScene mapInputNodeScene;

    public override void _EnterTree() { }

    public override void _ExitTree() {
        Clear();
    }

    public void GenerateMap() { }

    public void Edit(TileMap tileMap) {
        Clear();

        mapInputNodeScene = GD.Load<PackedScene>("res://addons/mapgen/nodes/map_input_node.tscn");
        inputNode ??= mapInputNodeScene.Instantiate<MapInputNode>();
        inputNode.EditorInterface = editorInterface;

        AddChild(inputNode);
    }

    public void Clear() {
        if (inputNode == null) {
            return;
        }
        RemoveChild(inputNode);
        inputNode.Free();
    }

}
