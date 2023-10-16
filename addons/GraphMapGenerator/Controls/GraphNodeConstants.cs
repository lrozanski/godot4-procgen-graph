#if TOOLS
using System.Collections.Generic;
using Godot;

namespace GraphMapGenerator.addons.GraphMapGenerator.Controls;

[Tool]
public static class GraphNodeConstants {

    public static readonly Dictionary<GraphNodeValueType, Color> ValueToColor = new() {
        { GraphNodeValueType.Number, Color.FromHtml("ff8014") },
        { GraphNodeValueType.Boolean, Color.FromHtml("fb007a") },
        { GraphNodeValueType.Rect, Color.FromHtml("ffff14") },
        { GraphNodeValueType.Collection, Color.FromHtml("00ff00") },
        { GraphNodeValueType.MapData, Color.FromHtml("6800ff") },
        { GraphNodeValueType.Operator, Color.FromHtml("888888") },
    };

}
#endif
