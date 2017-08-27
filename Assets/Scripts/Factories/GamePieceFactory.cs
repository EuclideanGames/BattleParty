using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceFactory : MonoBehaviour
{
    public static GamePieceFactory Active;
    
    public GamePieceObject PlayerObject;
    public GamePieceObject EnemyObject;

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

    public KeyValuePair<GamePiece, GamePieceObject> CreatePiece(GamePiece.Type pieceType)
    {
        GamePiece piece;
        GamePieceObject pieceObject;

        switch (pieceType)
        {
            case GamePiece.Type.Player:
                piece = new Player();
                pieceObject = Instantiate(PlayerObject);
                break;
            case GamePiece.Type.Enemy:
                piece = new Enemy();
                pieceObject = Instantiate(EnemyObject);
                break;
            default:
                throw new System.Exception("Invalid piece type for factory");
                break;
        }

        piece.OnPieceMoved += pieceObject.HandlePieceMoved;
        pieceObject.OnPieceSelected += piece.HandlePieceSelected;

        return new KeyValuePair<GamePiece, GamePieceObject>(piece, pieceObject);
    }
}
