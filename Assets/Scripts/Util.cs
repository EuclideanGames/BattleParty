using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static T Random<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static Color WithAlpha(this Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }

    public static Color32 WithAlpha(this Color32 color, byte alpha)
    {
        return new Color32(color.r, color.g, color.b, alpha);
    }
}
