using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellGrid : MonoBehaviour
{

    public GameObject Cell; //Cell prefab para fazer o tabuleiro
    public RectTransform gameArea; //area que sera utilizada como tabuleiro
    public Vector2 GridSize; //numero de letras usadas
    public GridLayoutGroup grid;

    public List<Cell> cells;

    private void OnEnable()
    {
        grid.cellSize = getCellSize();
        for (int i = 0; i < GridSize.y; i++)
        {
            for (int j = 0; j < GridSize.x; j++)
            {
                GameObject newCellObj = Instantiate(Cell, gameArea);
                Cell newCell = newCellObj.GetComponent<Cell>();
                newCell.setCell(new Vector2(j, i), false, RandomCharacter.getCharacter());
                cells.Add(newCell);
            }
        }
    }

    public Vector2 getCellSize() //tamanho da celula baseado na area de jogo/numero de celulas
    {
        Vector2 area = gameArea.sizeDelta;
        Vector2 cellSize;

        cellSize = area / GridSize;
        return cellSize;
    }
}
