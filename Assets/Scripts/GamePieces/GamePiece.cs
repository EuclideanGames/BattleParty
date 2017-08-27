using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePiece
{
    public Type PieceType;

    public event EventHandler<PieceMovedArgs> OnPieceMoved = (sender, e) => { };
    
    public enum Type
    {
        Player,
        Enemy
    }

    public virtual void HandlePieceSelected(object sender, PieceSelectedArgs e) { }

    public virtual void MovePiece(Tile destination)
    {
        var args = new PieceMovedArgs(destination);
        
        OnPieceMoved.Invoke(this, args);
    }
}

public class PieceMovedArgs : EventArgs
{
    public Tile Destination;

    public PieceMovedArgs(Tile destination)
    {
        Destination = destination;
    }
}
