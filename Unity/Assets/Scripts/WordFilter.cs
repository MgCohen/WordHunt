using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFilter : MonoBehaviour
{
    public string Word;
    public List<GridedWord> foundWords;

    public List<char> chars = new List<char>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //test();
            //getLines();
            string str = new string(chars.ToArray());
            Debug.Log(str);
        }
    }

    public void getLines()
    {
        List<Cell> targets = findFirstLetter(Word[0]);
        foreach(Cell cell in targets)
        {
            checkOnBoard(cell);
        }
    }

    public List<Cell> findFirstLetter(char Char)
    {
        List<Cell> letters = new List<Cell>();
        foreach(Cell cell in Manager.instance.cellGrid.cells)
        {
            if(cell.Char == Char)
            {
                letters.Add(cell);
            }
        }

        return letters;
    }

    public void checkOnBoard(Cell target)
    {
        List<Cell> targetCells = new List<Cell>();
        for (int i = 1; i < Word.Length; i++)
        {
            Debug.Log(Word[i]);
            if (target.gridPos.x + i > Manager.instance.cellGrid.GridSize.x || Manager.instance.cellGrid.cells[(int)target.gridPos.x + i,(int)target.gridPos.y].Char != Word[i])
            {
                Debug.Log("not the same");
                return;
            }
        }
        Debug.Log("found");
    }

}

