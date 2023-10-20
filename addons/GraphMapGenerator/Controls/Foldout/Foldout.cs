#if TOOLS
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Controls.Foldout;

[Tool]
[GlobalClass]
public partial class Foldout : VBoxContainer {

    [Export]
    public bool Expanded {
        get => expanded;
        set {
            expanded = value;

            if (IsNodeReady() && IsInstanceValid(content)) {
                ToggleContent(expanded);
            }
        }
    }

    private bool expanded = true;

    private Control content;
    private Button foldoutButton;

    private void ToggleContent(bool state) {
        content.Visible = state;
        foldoutButton.Text = state switch {
            true => "v",
            false => ">",
        };
    }
}
#endif
