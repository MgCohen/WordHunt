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
        setGrid();
    }

    public void setGrid() //criando o tabuleiro/grid que vai ser usado
    {
        cells = new Cell[(int)GridSize.x, (int)GridSize.y];
        grid.cellSize = getCellSize();
        for (int i = 0; i < GridSize.y; i++)
        {
            for (int j = 0; j < GridSize.x; j++)
            {
                Cell newCell = (Instantiate(Cell, gameArea)).GetComponent<Cell>();
                newCell.setCell(new Vector2(j, i), true, "\0"[0]);
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

    public Cell RandomCell() //pegar uma celula aleatoria do grid
    {
        int x = Random.Range(0, (int)GridSize.x);
        int y = Random.Range(0, (int)GridSize.y);

        return cells[x, y];
    }
}
