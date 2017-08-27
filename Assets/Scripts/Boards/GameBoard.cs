using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameBoard : Board
{
    private List<Tile> activeTiles;
    
    public GameBoard()
    {
        activeTiles = new List<Tile>();
    }

    public override void SaveBoard(string fileName)
    {
        
    }

    public override void LoadBoard(string fileName)
    {
        var path = Application.persistentDataPath + "/" + fileName + ".board";

        var tileStrings = File.ReadAllLines(path);

        foreach(var existingTile in activeTiles)
            existingTile.Destroy();
        activeTiles = new List<Tile>();
        
        foreach (var tileString in tileStrings)
        {
            var type = (Tile.Type) int.Parse(tileString.Split(';')[0]);

            var tileType = string.Empty;
            
            switch (type)
            {
                case Tile.Type.Blank:
                    tileType = "Blank";
                    break;
                case Tile.Type.Warp:
                    tileType = "Warp";
                    break;
                case Tile.Type.Loot:
                    tileType = "Loot";
                    break;
                default:
                    throw new Exception("Invalid game board tile");
            }

            var tilePair = TileFactory.Active.CreateTile(tileType);
            var tile = tilePair.Key;
            
            tile.Parse(tileString);
            
            activeTiles.Add(tile);
        }
    }
}
