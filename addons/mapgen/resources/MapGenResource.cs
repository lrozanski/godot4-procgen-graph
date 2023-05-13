using Godot;

namespace procgengraph.addons.mapgen.resources;

[Tool]
public partial class MapGenResource : Resource {

    [Export]
    public TileSet TileSet { get; set; }

    [Export(PropertyHint.ResourceType, nameof(MapInputNodeResource))]
    public MapInputNodeResource MapInputNode { get; set; }

}
