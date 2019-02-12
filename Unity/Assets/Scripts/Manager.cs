using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }


    public LevelData level;
    public Dictionary dictionary;
    public WordInput wordInput;
    public CellGrid cellGrid;
    public WordFinder wordFinder;
    public showWord showWords;

    private bool isFirst = true;
    private bool isSet = false;

    //lista de palavras e a posicao de cada letra
    public List<GridedWord> gridWords;

    public int wordsFound;

    public void SetBoard()
    {
        if (isFirst)
        {
            cellGrid.setGrid(level.GridSize);
            isFirst = false;
        }
        if (isSet == false)
        {
            gridWords.Clear();
            wordInput.ValidWords = level.Theme.Words;
            wordInput.PopulateBoard(level.NumberOfWords);
            isSet = true;
        }
        Debug.Log("set");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(testing());
        }
    }

    public void ResetBoard()
    {
        isSet = false;
        cellGrid.ResetBoard();
        wordInput.ResetInput();
        showWords.ClearWords();

        wordsFound = 0;
        Debug.Log("Reset");
    }

    public void findWord(GridedWord word)
    {
        wordsFound += 1;
        if (wordsFound == level.NumberOfWords)
        {
            //win
        }
        showWords.displayWord(word.word);
    }


    IEnumerator testing()
    {
        while (true)
        {
            SetBoard();
            yield return null;
            ResetBoard();
            yield return null;
        }
    }

}
