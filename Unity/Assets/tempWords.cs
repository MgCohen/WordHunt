using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//temporary word collection just for testing

public class tempWords : MonoBehaviour
{
    
    public List<string> words;
    public CellGrid CG;

    private void Start()
    {
        //getChar();
    }

    public void checkPossiblePositions()
    {
        foreach(string word in words)
        {
        }
    }


    public List<Cell> getChar(char Char)
    {
        List<Cell> cells = new List<Cell>();
        foreach(Cell cell in CG.cells)
        {
            if(cell.Char == Char)
            {
                cells.Add(cell);
            }
        }
        return cells;
    }

    public void forEachDirectino()
    {

    }

    public void checkSize()
    {

    }

    public void checkRandom()
    {

    }


}

