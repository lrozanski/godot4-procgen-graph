using Godot;
using procgengraph.addons.mapgen.resources;

namespace procgengraph.addons.mapgen;

[Tool]
public partial class MapGenGraph : GraphEdit {

    private MapInputNode inputNode;
    private PackedScene mapInputNodeScene;

    public override void _EnterTree() {
        mapInputNodeScene = GD.Load<PackedScene>("res://addons/mapgen/nodes/map_input_node.tscn");
        inputNode ??= mapInputNodeScene.Instantiate<MapInputNode>();

        AddChild(inputNode);
    }

    public void Edit(MapGenResource mapGenResource) {
        Clear();
        LoadState(mapGenResource);
    }

    private void LoadState(MapGenResource mapGenResource) {
        inputNode.LoadState(mapGenResource.MapInputNode);
    }

    public void Clear() {
        RemoveChild(inputNode);
        inputNode = mapInputNodeScene.Instantiate<MapInputNode>();
        AddChild(inputNode);
    }

    public void GenerateMap() { }

}
