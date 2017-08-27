using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    public event EventHandler<TileSelectedArgs> OnTileSelected = (sender, e) => { };

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(CheckTouch())
            OnTouch();
    }

    private void OnMouseDown()
    {
        var args = new TileSelectedArgs();
        
        OnTileSelected.Invoke(this, args);
    }
    
    public void HandlePositionChanged(object sender, TilePositionChangedArgs e)
    {
        transform.position = e.Coords;
    }

    public void HandleTypeChanged(object sender, TileTypeChangedArgs e)
    {
        Color newTileColor;
        
        switch (e.NewType)
        {
            case Tile.Type.None:
                newTileColor = Colors.White.WithAlpha(0.5f);
                break;
            case Tile.Type.Blank:
                newTileColor = Colors.White;
                break;
            case Tile.Type.Warp:
                newTileColor = Colors.VividViolet;
                break;
            case Tile.Type.Loot:
                newTileColor = Colors.DarkGreen;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        spriteRenderer.material.color = newTileColor;
    }

    public void HandleDestroying(object sender, TileDestroyingArgs e)
    {
        Destroy(this.gameObject);
    }

    private bool CheckTouch()
    {
        if (Input.touchCount <= 0) return false;
        
        for (var i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            var touchWorldPos = PanCamera.Active.Camera.ScreenToWorldPoint(touch.position);
            var touch2D = new Vector2(touchWorldPos.x, touchWorldPos.y);
            var hit = Physics2D.Raycast(touch2D, PanCamera.Active.transform.forward);

            if (hit.collider.gameObject == this.gameObject)
                return true;
        }

        return false;
    }

    private void OnTouch()
    {
        var args = new TileSelectedArgs();
        
        OnTileSelected.Invoke(this, args);
    }
}

public class TileSelectedArgs : EventArgs
{

}
