using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
	private EditorBoard activeBoard;
	
	private void Start() { }

	private void Update() { }

	public void CreateNewEditorBoard()
	{
		if (activeBoard != null)
		{
			activeBoard.DeleteBoard();
			activeBoard = null;
		}
		
		activeBoard = new EditorBoard();
		activeBoard.CreateBoard(10, 10);
	}

	public void SaveActiveBoard()
	{
		if (activeBoard == null) return;
		
		activeBoard.SaveBoard(DateTime.Now.ToString("ddMMyyyyHHmmss"));
	}
}
