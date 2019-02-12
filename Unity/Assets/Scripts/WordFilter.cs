using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFilter : MonoBehaviour
{
    public Section sec;
    public List<GridedWord> foundWords;

    public List<char> chars = new List<char>();

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    getLines();
        //}
    }


    public void getLines()
    {
        foreach (string Word in sec.Words)
        {
            Debug.Log("Next Word");
            SearchWord(Word);
        }
    }

    public void SearchWord(string word)
    {
        List<Cell> targets = findFirstLetter(word.ToUpper()[0]);
        foreach (Cell cell in targets)
        {
            Debug.Log("Next Cell");
            checkOnBoard(cell, word);
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
        Vector2[] directions = new Vector2[3] { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        foreach (Vector2 dir in directions)
        {
            targetCells.Add(target);
            for (int i = 1; i < word.Length; i++)
            {
                Vector2 newTarget = target.gridPos + (dir * i);
                if ((newTarget - Manager.instance.cellGrid.GridSize).x >= 0 || (newTarget - Manager.instance.cellGrid.GridSize).y >= 0)
                {
                    Debug.Log("bigger than grid");
                    targetCells.Clear();
                    break;
                }
                if (Manager.instance.cellGrid.cells[(int)newTarget.x, (int)newTarget.y].Char != word.ToUpper()[i])
                {
                    //check why didn't match
                    Debug.Log(new Vector2((int)newTarget.x, (int)newTarget.y) + " " + Manager.instance.cellGrid.cells[(int)newTarget.x, (int)newTarget.y].Char + " not match " + word.ToUpper()[i]);
                    targetCells.Clear();
                    break;
                }
                targetCells.Add(Manager.instance.cellGrid.cells[(int)newTarget.x, (int)newTarget.y]);
            }
            if (targetCells.Count > 0)
            {
                Debug.Log("found");
                foundWords.Add(new GridedWord(word, targetCells, true));
            }
            targetCells.Clear();
        }
    }

}

