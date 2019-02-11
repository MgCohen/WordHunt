using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFinder : MonoBehaviour
{

    //lista de palavras e a posicao de cada letra
    public List<GridedWord> gridWords;

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

    public void ClearSelection()
    {
        foreach(Cell cell in selectedCells)
        {
            cell.GetComponent<Animator>().SetBool("Selected", false);
        }
        selectedCells.Clear();
    }

    //verifica se as celulas selecionadas formam uma palavra
    public bool CheckCells()
    {
        foreach (GridedWord gridWord in gridWords)
        {
            if (CompareLists(gridWord.positions, selectedCells))
            {
                Debug.Log("FOUND");
                Manager.instance.findWord(gridWord);
                ClearSelection();
                gridWord.isFound = true;
                return true;
            }
        }
        return false;
    }

    //algoritmo para comparar se 2 listas sao identicas independente da ordem
    public bool CompareLists(List<Cell> aListA, List<Cell> aListB)
    {
        if (aListA == null || aListB == null || aListA.Count != aListB.Count)
            return false;
        if (aListA.Count == 0)
            return true;
        Dictionary<Cell, int> lookUp = new Dictionary<Cell, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count))
            {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count))
            {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
        return lookUp.Count == 0;
    }


    public void ResetWords()
    {
        gridWords.Clear();
    }

}
