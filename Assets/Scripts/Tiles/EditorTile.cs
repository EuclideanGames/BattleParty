using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTile : Tile
{
    public EditorTile()
    {
        TileType = Type.None;
        ID = 0;
        Next = new List<int>();
        Previous = new List<int>();
        IsIso = false;
    }
    
    public override void HandleTileSelected(object sender, TileSelectedArgs e)
    {
        CycleType();
    }

    private void CycleType()
    {
        var currentType = (int) TileType;

        if (++currentType >= Enum.GetNames(typeof(Tile.Type)).Length)
            currentType = 0;

        TileType = (Tile.Type) currentType;
    }
}
