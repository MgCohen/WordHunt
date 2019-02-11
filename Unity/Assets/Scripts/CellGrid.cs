using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellGrid : MonoBehaviour
{
    public static CellGrid Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }



    public GameObject Cell; //Cell prefab para fazer o tabuleiro
    public RectTransform gameArea; //area que sera utilizada como tabuleiro
    public Vector2 GridSize; //numero de letras usadas
    public GridLayoutGroup grid;

    public Cell[,] cells;

    private void OnEnable()
    {
        cells = new Cell[(int)GridSize.x, (int)GridSize.y];
        grid.cellSize = getCellSize();
        for (int i = 0; i < GridSize.y; i++)
        {
            for (int j = 0; j < GridSize.x; j++)
            {
                GameObject newCellObj = Instantiate(Cell, gameArea);
                Cell newCell = newCellObj.GetComponent<Cell>();
                newCell.setCell(new Vector2(j, i), false, RandomCharacter.getCharacter());
                //cells.Add(new GridedCell(newCell, new Vector2(j, i)));
                cells[j, i] = newCell;
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

[System.Serializable]
public class GridedCell
{

    public GridedCell(Cell myCell, Vector2 myPos)
    {
        cell = myCell;
        Pos = myPos;
    }
    public Cell cell;
    public Vector2 Pos;
}
