using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordFinder : MonoBehaviour
{
    public GameObject wordMaker;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            MarkFoundCells(Manager.instance.gridWords[0]);
        }
    }

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

    public void MarkFoundCells(GridedWord gridWord)
    {
        GameObject marker = Instantiate(wordMaker, transform);
        RectTransform markerTransform = marker.GetComponent<RectTransform>();
        Vector2 one = gridWord.positions[0].transform.position;
        Vector2 last = gridWord.positions[gridWord.positions.Count-1].transform.position;
        Vector2 middle = new Vector2((one.x + last.x) / 2, (one.y + last.y) / 2);
        float width = (last - one).magnitude;

        marker.transform.position = middle;
        markerTransform.sizeDelta = new Vector2(width, markerTransform.sizeDelta.y );

        Debug.Log(Vector2.Angle(one, last));
    }

}

//classe usada para definir uma palavra no grid e ter sua localização possivel
[System.Serializable]
public class GridedWord
{


    public string word;
    public List<Cell> positions = new List<Cell>();
    public bool isFound;
    public List<char> wordChars = new List<char>();

    public GridedWord(string thisWord, List<Cell> myPos)
    {
        word = thisWord;
        fillList(myPos);
        wordChars.AddRange(thisWord.ToUpper());
    }

    public GridedWord(List<char> letters, List<Cell> myPos)
    {
        word = new string(letters.ToArray());
        fillList(myPos);
        wordChars = letters;
    }

    public void fillList(List<Cell> newPos)
    {
        positions.Clear();
        foreach (Cell cell in newPos)
        {
            positions.Add(cell);
        }
    }

}
