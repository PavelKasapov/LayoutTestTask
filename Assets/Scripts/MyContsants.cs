using System.Collections.Generic;
using UnityEngine;

public static class MyContsants
{
    public static Dictionary<TitleColor, Color> TitleColors = new Dictionary<TitleColor, Color>() {
        [TitleColor.Default] = new Color(0.01176471f, 0.01176471f, 0.003921569f),
        [TitleColor.Red] = new Color(0.8901961f, 0.2588235f, 0.003921569f),
        [TitleColor.Yellow] = new Color(1f, 0.7686275f, 0.1215686f),
    };
}
