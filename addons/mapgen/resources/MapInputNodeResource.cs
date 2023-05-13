using Godot;

namespace procgengraph.addons.mapgen.resources;

[Tool]
public partial class MapInputNodeResource : Resource {

    [Export]
    public int Seed { get; set; }

}
