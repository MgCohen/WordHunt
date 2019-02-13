using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    //Classe controladora durante GamePlay
    //Singleton usado para facilitar acesso ao dicionario e a construção do board


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


    //flags para setar o board
    private bool isFirst = true;
    private bool isSet = false;

    //lista de palavras e a posicao de cada letra
    public List<GridedWord> gridWords;
    //contador de palavras encontradas
    public int wordsFound;

    //referencia ao painel de vitoria para finalizar partida
    public GameObject winPanel;

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
    }

    private void OnEnable()
    {
        SetBoard();
    }

    public void ResetBoard()
    {
        isSet = false;
        cellGrid.ResetBoard();
        wordInput.ResetInput();
        showWords.ClearWords();

        wordsFound = 0;
    }

    public void findWord(GridedWord word)
    {
        wordsFound += 1;
        if (wordsFound == level.NumberOfWords)
        {
            winPanel.SetActive(true);
        }
        showWords.wordFound(word.word);
    }

}
