using Godot;
using procgengraph.addons.mapgen.editor;

namespace procgengraph;

[Tool]
public partial class MapInputNode : GraphNode {

    public EditorInterface EditorInterface { get; set; }

    [Export]
    private TileMap TileMap { get; set; }

    [Export]
    private TileSet TileSet { get; set; }

    [Export]
    private Vector2I MapSize { get; set; }

    private SceneTreeDialog sceneTreeDialog;

    public override void _EnterTree() {
        sceneTreeDialog ??= new SceneTreeDialog();
        AddChild(sceneTreeDialog);

        // sceneTreeDialog.InitTree(MapGen.EditorSceneRoot);
        sceneTreeDialog.NodeSelected += selected => { GetNode<LineEdit>("HBoxContainer/LineEdit").Text = selected; };

        GetNode<Button>("HBoxContainer/Button").Pressed += () => {
            sceneTreeDialog.InitTree(EditorInterface.GetEditedSceneRoot());
            sceneTreeDialog.PopupCentered();
        };
    }

    public override void _ExitTree() {
        RemoveChild(sceneTreeDialog);
        sceneTreeDialog.Free();
    }

}
