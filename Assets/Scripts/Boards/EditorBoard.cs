using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class EditorBoard : Board
{
    private List<EditorTile> editorTiles;
    
    public EditorBoard()
    {
        editorTiles = new List<EditorTile>();
    }

    public void CreateBoard(int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var tileID = i + j * width;
                
                var tilePair = TileFactory.Active.CreateTile("Editor");
                var eTile = (EditorTile)tilePair.Key;

                eTile.TileType = Tile.Type.None;
                eTile.ID = tileID;
                eTile.Position = new Point(i, j);
                
                editorTiles.Add(eTile);
            }
        }
    }

    public void DeleteBoard()
    {
        
    }

    public override void SaveBoard(string fileName)
    {
        var path = Application.persistentDataPath + "/" + fileName + ".board";
        
        File.WriteAllLines(
            path, 
            editorTiles
                .Where(tile => tile.TileType != Tile.Type.None)
                .Select(tile => tile.ToString()).ToArray());
    }

    public override void LoadBoard(string fileName)
    {
        var path = Application.persistentDataPath + "/" + fileName + ".board";

        var tileStrings = File.ReadAllLines(path);
        
        foreach(var existingTile in editorTiles)
            existingTile.Destroy();
        editorTiles = new List<EditorTile>();

        foreach (var tileString in tileStrings)
        {
            var tilePair = TileFactory.Active.CreateTile("Editor");
            var eTile = (EditorTile)tilePair.Key;
            
            eTile.Parse(tileString);
            
            editorTiles.Add(eTile);
        }
    }
}
