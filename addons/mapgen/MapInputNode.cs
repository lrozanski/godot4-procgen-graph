using Godot;
using procgengraph.addons.mapgen.resources;

namespace procgengraph.addons.mapgen;

[Tool]
public partial class MapInputNode : GraphNode {

    [Export]
    public Vector2I MapSize { get; set; }

    [Export]
    public int Seed { get; set; }

    public override void _EnterTree() { }

    public override void _ExitTree() { }

    public void LoadState(MapInputNodeResource mapInput) {
        var seedInput = GetNode<SpinBox>("%Seed");

        seedInput.Value = mapInput.Seed;
        seedInput.ValueChanged += value => { mapInput.Seed = (int) value; };
    }

}
