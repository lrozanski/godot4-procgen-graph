using Godot;

namespace procgengraph.addons.mapgen.editor;

public partial class SceneTreeDialog : ConfirmationDialog {

    [Signal]
    public delegate void NodeSelectedEventHandler(NodePath selected);

    private Node root;
    private Panel panel;
    private Tree tree;

    public override void _EnterTree() {
        GD.Print("Enter Tree");

        // panel = controls.Instantiate<Panel>();
        // AddChild(panel);

        var vbox = new VBoxContainer();
        AddChild(vbox);

        tree = new Tree { CustomMinimumSize = new Vector2(500, 600) };
        vbox.AddChild(tree);

        Confirmed += () => {
            var selected = tree.GetSelected();

            if (selected == null) {
                return;
            }
            backing_NodeSelected?.Invoke(selected.GetMetadata(0).AsNodePath());
            GD.Print($"{selected.GetMetadata(0)}");
            Hide();
        };
        Size = new Vector2I(500, 600);
    }

    public void InitTree(Node root) {
        tree.Clear();

        this.root = root;
        var newRoot = tree.CreateItem();

        for (var i = 0; i < root.GetChildCount(); i++) {
            AddTreeItem(i, root.GetChild(i), newRoot);
        }
    }

    private void AddTreeItem(int index, Node node, TreeItem parent = null) {
        var treeItem = tree.CreateItem(parent, index);
        treeItem.SetText(0, node.Name);
        treeItem.SetMetadata(0, CalculateNodePath(node));

        for (var i = 0; i < node.GetChildCount(); i++) {
            AddTreeItem(i, node.GetChild(i), treeItem);
        }
    }

    private NodePath CalculateNodePath(Node node) {
        var rootPath = root.GetPath();
        var nodePath = node.GetPath();

        return nodePath.ToString().Substring(rootPath.ToString().Length + 1);
    }

    public override void _ExitTree() {
        RemoveChild(panel);
    }

}
