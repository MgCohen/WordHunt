using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordFilter : MonoBehaviour
{
    public Section sec;
    public List<GridedWord> foundWords;

    public List<char> chars = new List<char>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            getLines();
        }
    }


    public void getLines()
    {
        foreach (string Word in sec.Words)
        {
            Debug.Log("Next Word");
            List<Cell> targets = findFirstLetter(Word.ToUpper()[0]);
            foreach (Cell cell in targets)
            {
                cell.GetComponent<Image>().enabled = false;
                Debug.Log("Next Cell");
                checkOnBoard(cell, Word);
            }
        }
    }

    //procura todas as posicoes da primeira letra da palavra requisitada
    public List<Cell> findFirstLetter(char Char)
    {
        List<Cell> letters = new List<Cell>();
        foreach (Cell cell in Manager.instance.cellGrid.cells)
        {
            if (cell.Char == Char)
            {
                letters.Add(cell);
            }
        }

        return letters;
    }

    //verifica se a palavra existe no endereço requisitado, retorna a palavra no grid se verdadeiro
    public void checkOnBoard(Cell target, string word)
    {
        List<Cell> targetCells = new List<Cell>();

        Vector2 dir = new Vector2(1, 0);

        for (int i = 1; i < word.Length; i++)
        {
            Debug.Log(i);
            if ((target.gridPos+(dir * i)) == Manager.instance.cellGrid.GridSize)
            {
                Debug.Log("bigger than grid");
                targetCells.Clear();
                break;
            }
            if (Manager.instance.cellGrid.cells[(int)target.gridPos.x + i, (int)target.gridPos.y].Char != word.ToUpper()[i])
            {
                Debug.Log(new Vector2((int)target.gridPos.x + i, (int)target.gridPos.y) + " " + Manager.instance.cellGrid.cells[(int)target.gridPos.x + i, (int)target.gridPos.y].Char + " not match " + word.ToUpper()[i]);
                targetCells.Clear();
                break;
            }
            targetCells.Add(Manager.instance.cellGrid.cells[(int)target.gridPos.x + i, (int)target.gridPos.y]);
            Debug.Log(word.ToUpper()[i]);
        }
        if (targetCells.Count > 0)
        {
            Debug.Log("found");
            foundWords.Add(new GridedWord(word, targetCells));
        }
        targetCells.Clear();
    }

}

