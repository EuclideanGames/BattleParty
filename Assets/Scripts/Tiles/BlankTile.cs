using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankTile : Tile
{
    public BlankTile()
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
