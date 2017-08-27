using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
	private GameBoard activeBoard;

	private void Awake()
	{
		
	}

	private void Start () 
	{
		
	}
	
	private void Update () 
	{
		
	}

	public void LoadBoard(string fileName)
	{
		activeBoard = new GameBoard();
		activeBoard.LoadBoard(fileName);
	}
}
