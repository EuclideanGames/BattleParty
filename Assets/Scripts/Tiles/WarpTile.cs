using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpTile : Tile
{
    public WarpTile()
    {
        ID = 0;
        Next = new List<int>();
        Previous = new List<int>();
        IsIso = true;
    }
    
    public override void HandleTileSelected(object sender, TileSelectedArgs e)
    {
        base.HandleTileSelected(sender, e);
    }
}
