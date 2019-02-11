using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public Dictionary Dct;

    public List<string> usedWords;
    private Vector2 direction;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            setWord("First");
        }
    }

    public void PopulateBoard(int NumberOfWords, int MaxStringSize, List<string> PossibleWords)
    {
        //get random index from possible words
        //see if word size is ok
        //try to fit
        //count total


        //setWord();
    }

    public void setWord(string word)
    {
        List<Cell> usedCells = new List<Cell>();
        word = word.ToUpper();
        Cell target = CellGrid.Instance.RandomCell();
        while (!CheckforEachDirection(word, target) || usedCells.Count != CellGrid.Instance.cells.Length)
        {

        }
        if (CheckforEachDirection(word, target))
        {
            PlaceWord(target, direction, word);
        }
        else
        {
            //repeat
        }
    }


    //Checar se a palavra cabe no na celula alvo e se a celular ja esta sendo usada
    //usa a direção recebida de CheckAllDirections para saber para onde verificar
    public bool CheckFit(string word, Cell target, Vector2 dir)
    {
        int wordSize = word.Length;
        if (((target.gridPos.x * dir.x) + wordSize > CellGrid.Instance.GridSize.x) || ((target.gridPos.y * dir.y) + wordSize > CellGrid.Instance.GridSize.y))
        {
            Debug.Log("don't fit");
            return false;
        }
        else
        {
            Debug.Log("fits");
            for (int i = 0; i < wordSize; i++)
            {
                Cell newTarget = CellGrid.Instance.cells[(int)(target.gridPos.x + (dir.x * i)), (int)(target.gridPos.y + (dir.y * i))];
                if (!newTarget.random && newTarget.Char != word.ToUpper()[i])
                {
                    Debug.Log("already used");
                    return false;
                }
            }
            Debug.Log("Match");
            return true;
        }
    }

    //Escolhe uma direção aleatoria e verifica se é possivel colocar a palavra
    public bool CheckforEachDirection(string word, Cell target) 
    {
        List<Vector2> PossibleDirections = new List<Vector2>() { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        for (int i = 0; i < 3; i++)
        {
            Vector2 tryVector = PossibleDirections[Random.Range(0, PossibleDirections.Count)];
            if (CheckFit(word, target, tryVector))
            {
                direction = tryVector;
                return true;
            }
            else
            {
                PossibleDirections.Remove(tryVector);
            }
        }
        return false;
    }

    //Coloca a palavra verificada nas celulas verificadas nos metodos anteriores
    public void PlaceWord(Cell target, Vector2 Dir, string Word)
    {
        for (int i = 0; i < Word.Length; i++)
        {
            CellGrid.Instance.cells[(int)(target.gridPos.x + (Dir.x * i)), (int)(target.gridPos.y + (Dir.y * i))].setCell(false, Word[i]);
        }
        usedWords.Add(Word);
    }

}
