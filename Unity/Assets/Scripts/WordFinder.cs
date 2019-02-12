using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach (GridedWord gridWord in Manager.instance.level.gridWords)
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
