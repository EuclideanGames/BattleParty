using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Tile
{
    public static readonly float TileWidth = 1.0f;
    public static readonly float TileHeight = 1.0f;
    public static readonly float IsoTileWidth = 1.6f;
    public static readonly float IsoTileHeight = 0.8f;
    public static readonly float HalfWidth = IsoTileWidth * 0.5f;
    public static readonly float HalfHeight = IsoTileHeight * 0.5f;
    
    public int ID;
    public List<int> Next;
    public List<int> Previous;

    protected bool IsIso;
    
    private Point position;
    private Type tileType;
    
    public event EventHandler<TilePositionChangedArgs> OnPositionChanged = (sender, e) => { };
    public event EventHandler<TileTypeChangedArgs> OnTypeChanged = (sender, e) => { };
    public event EventHandler<TileDestroyingArgs> OnDestroying = (sender, e) => { };
    
    public enum Type
    {
        None,
        Blank,
        Warp,
        Loot
    }
    
    public Point Position
    {
        get { return position; }
        set
        {
            position = value;
            var args = new TilePositionChangedArgs(value, IsIso);
            OnPositionChanged.Invoke(this, args);
        }
    }

    public Point IsoPosition
    {
        get
        {
            return new Point(
                (position.X - position.Y) * HalfWidth,
                (position.X + position.Y) * HalfHeight);
        }
    }

    public Type TileType
    {
        get { return tileType; }
        set
        {
            tileType = value;
            var args = new TileTypeChangedArgs(value);
            OnTypeChanged.Invoke(this, args);
        }
    }
    
    public virtual void HandleTileSelected(object sender, TileSelectedArgs e) { }

    public void Parse(string str)
    {
        var tileInfo = str.Split(';');

        TileType = (Tile.Type) int.Parse(tileInfo[0]);
        ID = int.Parse(tileInfo[1]);
        Position = Point.Parse(tileInfo[2]);

        var nextIDs = tileInfo[3].Split(',');
        var prevIDs = tileInfo[4].Split(',');

        foreach (var id in nextIDs)
        {
            int num;
            if (int.TryParse(id, out num))
                Next.Add(num);
        }
        foreach(var id in prevIDs)
        {
            int num;
            if (int.TryParse(id, out num))
                Previous.Add(num);
        }
    }

    public void Destroy()
    {
        var args = new TileDestroyingArgs();
        OnDestroying.Invoke(this, args);
    }
    
    public override string ToString()
    {
        return string.Format(
            "{0};{1};{2};{3};{4};",
            (int)TileType,
            ID,
            Position,
            string.Join(",", Next.Select(x => x.ToString()).ToArray()),
            string.Join(",", Previous.Select(x => x.ToString()).ToArray()));
    }
}

public class TilePositionChangedArgs : EventArgs
{
    public Vector2 Coords;

    public TilePositionChangedArgs(Point newPosition, bool isometric)
    {
        Coords = !isometric 
            ? new Vector2(
                newPosition.X * Tile.TileWidth, 
                newPosition.Y * Tile.TileHeight) 
            : new Vector2(
                (newPosition.X - newPosition.Y) * Tile.HalfWidth, 
                (newPosition.X + newPosition.Y) * Tile.HalfHeight);
    }
}

public class TileTypeChangedArgs : EventArgs
{
    public Tile.Type NewType;

    public TileTypeChangedArgs(Tile.Type newType)
    {
        NewType = newType;
    }
}

public class TileDestroyingArgs : EventArgs
{
    
}
