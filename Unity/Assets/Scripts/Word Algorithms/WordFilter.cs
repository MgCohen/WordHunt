using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFilter : MonoBehaviour
{


    public static GridedWord SearchWord(string word, int Index = 0)
    {
        List<Cell> targets = findFirstLetter(word.ToUpper()[0]);
        foreach (Cell cell in targets)
        {
            //Debug.Log("Next Cell");
            if(LookOnBoard(cell, word).Count > 0)
            {
                return LookOnBoard(cell, word)[Mathf.Clamp(Index,0,LookOnBoard(cell,word).Count - 1)];
            }
        }
        return null;
    }

    //procura todas as posicoes da primeira letra da palavra requisitada
    public  static List<Cell> findFirstLetter(char Char)
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

    //verifica se a palavra existe no endereço requisitado, 
    //retorna 1 ou mais instancias da palavra a partir da celula selecionada
    public static List<GridedWord> LookOnBoard(Cell target, string word)
    {
        List<GridedWord> foundWords = new List<GridedWord>();
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
                    //Debug.Log("bigger than grid");
                    targetCells.Clear();
                    break;
                }
                if (Manager.instance.cellGrid.cells[(int)newTarget.x, (int)newTarget.y].Char != word.ToUpper()[i])
                {
                    //check why didn't match
                    //Debug.Log(new Vector2((int)newTarget.x, (int)newTarget.y) + " " + Manager.instance.cellGrid.cells[(int)newTarget.x, (int)newTarget.y].Char + " not match " + word.ToUpper()[i]);
                    targetCells.Clear();
                    break;
                }
                targetCells.Add(Manager.instance.cellGrid.cells[(int)newTarget.x, (int)newTarget.y]);
            }
            if (targetCells.Count > 0)
            {
                //Debug.Log("found");
                foundWords.Add(new GridedWord(word, targetCells));
            }
            targetCells.Clear();
        }
        return foundWords;
    }

}

