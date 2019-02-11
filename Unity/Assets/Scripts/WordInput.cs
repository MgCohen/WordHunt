using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{

    public void setWord(string word)
    {
        //Vector2 testPos = CellGrid.Instance.cells[Random.Range(0, CellGrid.Instance.cells.Length)].Pos;
        //Cell testCell = CellGrid.Instance.cells[Random.Range(0, CellGrid.Instance.cells.Length)].cell;
        //CheckFit(word, testCell);
    }

    public bool CheckFit(string word, Cell target)
    {
        int wordSize = word.Length;
        if(target.gridPos.x + wordSize > CellGrid.Instance.GridSize.x)
        {
            Debug.Log("don't fit");
            return false;
        }
        else
        {
            for (int i = 0; i < wordSize; i++)
            {
                Cell newTarget = CellGrid.Instance.cells[(int)target.gridPos.x + i, (int)target.gridPos.y];
                if(!newTarget.random && newTarget.Char != word.ToUpper()[i])
                {
                    Debug.Log("already used");
                    return false;
                }
            }
            Debug.Log("Match");
            return true;
        }
    }

    public void CheckforEachDirection()
    {
        CheckFit("x", new Cell());
    }


    public void PlaceWord(Cell target, Vector2 Dir, string Word)
    {
        for (int i = 0; i < Word.Length; i++)
        {
            CellGrid.Instance.cells[(int)(target.gridPos.x + (Dir.x * i)), (int)(target.gridPos.y + (Dir.y * i))].setCell(false, Word[i]);
        }
    }

}
