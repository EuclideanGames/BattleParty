using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Board
{
    public int BoardTileWidth;
    public int BoardTileHeight;

    public virtual void SaveBoard(string fileName) { }
    public virtual void LoadBoard(string fileName) { }
}
