using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }


    public Dictionary dictionary;
    public WordInput wordInput;
    public CellGrid cellGrid;
    public WordFinder wordFinder;

    public int Number;
    private bool isFirst = true;
    private bool isSet = false;

    public void SetBoard()
    {
        if (isFirst)
        {
            cellGrid.setGrid();
            isFirst = false;
        }
        if (isSet == false)
        {
            wordInput.ValidWords = dictionary.Themes[0].Words;
            wordInput.PopulateBoard(Number);
            isSet = true;
        }
    }

    public void ResetBoard()
    {
        isSet = false;
        cellGrid.ResetBoard();
        wordInput.ResetInput();
        wordFinder.ResetWords();
    }


}
