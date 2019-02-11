using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Dictionary dictionary;
    public WordInput wordInput;
    public CellGrid cellGrid;

    public int Number;
    private bool isFirst = true;

    private void Start()
    {

    }

    public void SetBoard()
    {
        if (isFirst)
        {
            cellGrid.setGrid();
            isFirst = false;
        }
        wordInput.ValidWords = dictionary.Themes[0].Words;
        wordInput.PopulateBoard(Number);
    }

    public void ResetBoard()
    {
        cellGrid.ResetBoard();
        wordInput.ResetInput();
    }


}
