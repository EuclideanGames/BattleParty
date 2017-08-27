using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    public float X;
    public float Y;

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static float Distance(Point a, Point b)
    {
        return Mathf.Abs(
            Mathf.Sqrt(
                Mathf.Pow(b.X - a.X, 2) + Mathf.Pow(b.Y - a.Y, 2)));
    }
    //spruce this up so that it doesn't ever error, just quick n dirty for now
    public static Point Parse(string str)
    {
        string[] split = str.Split(',');
        return new Point(float.Parse(split[0]), float.Parse(split[1]));
    }
    
    public Vector2 ToV2()
    {
        return new Vector2(X, Y);
    }

    public override string ToString()
    {
        return string.Format("{0},{1}", X, Y);
    }
}
