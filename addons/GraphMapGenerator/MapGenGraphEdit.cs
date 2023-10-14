#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator;

[Tool]
public partial class MapGenGraphEdit : GraphEdit {

    public override void _EnterTree() {
        PopupRequest += _ => GD.Print("Popup requested");
    }

    public override void _ExitTree() { }

}
#endif
