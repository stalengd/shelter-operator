using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions
{
    public static Color WithAlpha(this Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }

    public static Color WithRGB(this Color color, Color rgb)
    {
        return new Color(rgb.r, rgb.g, rgb.b, color.a);
    }

    public static Color WithRGB(this Color color, float r, float g, float b)
    {
        return new Color(r, g, b, color.a);
    }
}