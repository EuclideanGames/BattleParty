using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    public static TileFactory Active;
    
    public TileObject BlankTileObject;
    public TileObject WarpTileObject;
    public TileObject LootTileObject;
    public TileObject EditorTileObject;

    private void Awake()
    {
        Active = this;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public KeyValuePair<Tile, TileObject> CreateTile(string tileType)
    {
        Tile tile;
        TileObject tileObject;

        switch (tileType)
        {
            case "Editor":
                tile = new EditorTile();
                tileObject = Instantiate(EditorTileObject);
                break;
            case "Warp":
                tile = new WarpTile();
                tileObject = Instantiate(WarpTileObject);
                break;
            case "Loot":
                tile = new LootTile();
                tileObject = Instantiate(LootTileObject);
                break;
            case "Blank":
                tile = new BlankTile();
                tileObject = Instantiate(BlankTileObject);
                break;
            default:
                throw new Exception("Invalid tile type");
        }

        tile.OnPositionChanged += tileObject.HandlePositionChanged;
        tile.OnTypeChanged += tileObject.HandleTypeChanged;
        tile.OnDestroying += tileObject.HandleDestroying;
        tileObject.OnTileSelected += tile.HandleTileSelected;

        return new KeyValuePair<Tile, TileObject>(tile, tileObject);
    }
}
