using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceObject : MonoBehaviour
{
    public event EventHandler<PieceSelectedArgs> OnPieceSelected = (sender, e) => { };

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
        var args = new PieceSelectedArgs();
        
        OnPieceSelected.Invoke(this, args);
    }

    public void HandlePieceMoved(object sender, PieceMovedArgs e)
    {
        transform.position = e.Destination.IsoPosition.ToV2();
    }
}

public class PieceSelectedArgs : EventArgs
{
    public PieceSelectedArgs()
    {
        
    }
}
