using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordFinder : MonoBehaviour
{

    //lista de celulas selecionadas
    public List<Cell> selectedCells;

    //adiciona nova celula e verifica se encontrou palavra
    public void SelectCell(Cell cell)
    {
        selectedCells.Add(cell);
        CheckCells();
    }

    //remove celula e verifica se encontrou palavra
    public void DeselectCell(Cell cell)
    {
        selectedCells.Remove(cell);
        CheckCells();
    }

    //limpa seleção visualmente e lista
    public void ClearSelection()
    {
        foreach (Cell cell in selectedCells)
        {
            cell.GetComponent<Animator>().SetBool("Selected", false);
        }
        selectedCells.Clear();
    }

    //verifica se as celulas selecionadas formam uma palavra
    public bool CheckCells()
    {
        foreach (GridedWord gridWord in Manager.instance.gridWords)
        {
            if (Utility.CompareLists(gridWord.positions, selectedCells))
            {
                if (!gridWord.isFound)
                {
                    Manager.instance.findWord(gridWord);
                    gridWord.isFound = true;
                    ClearSelection();
                    return true;
                }
                ClearSelection();
            }
        }
        return false;
    }

}

//classe usada para definir uma palavra no grid e ter sua localização possivel
[System.Serializable]
public class GridedWord
{
    public GridedWord(string thisWord, List<Cell> myPos, bool reveal = false)
    {
        word = thisWord;
        fillList(myPos, reveal);
        //positions = myPos;
        wordChars.AddRange(thisWord.ToUpper());
    }

    public GridedWord(List<char> letters, List<Cell> myPos, bool reveal = false)
    {
        word = new string(letters.ToArray());
        fillList(myPos, reveal);
        //positions = myPos;
        wordChars = letters;
    }

    public void fillList(List<Cell> newPos, bool reveal = false)
    {
        positions.Clear();
        foreach (Cell cell in newPos)
        {
            positions.Add(cell);
            if(reveal)
            cell.GetComponent<Image>().enabled = false;
        }
    }

    public string word;
    public List<Cell> positions = new List<Cell>();
    public bool isFound;
    public List<char> wordChars = new List<char>();
}
