using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public Section Dct;

    public List<string> usedWords;
    public List<string> gridWords;
    private Vector2 direction;

    //Coloca todas as palavras no tabuleiro
    public void PopulateBoard(int NumberOfWords)
    {
        Debug.Log("here");
        //loop o numero de palavras requisitadas
        for (int i = 0; i < NumberOfWords; i++)
        {
            string currentWord = getValidWorld();
            if(currentWord != null)
            {
                if (!setWord(currentWord))
                {
                    //restart map
                }
                else
                {
                    gridWords.Add(currentWord);
                }
            }

        }
    }

    //pega palavra de lista e verifica se é aceitavel.
    public string getValidWorld()
    {
        //pega a lista de possiveis palavras e define o tamanho maximo como o maior lado do tabuleiro
        List<string> PossibleWords = Dct.Words;
        int MaxStringSize = Mathf.Max((int)CellGrid.Instance.GridSize.x, (int)CellGrid.Instance.GridSize.y);

        //pega uma palavra aleatoria e verifica se atende as condições
        string tryWord = PossibleWords[Random.Range(0, PossibleWords.Count)];
        while (usedWords.Contains(tryWord) && tryWord.Length <= MaxStringSize && usedWords.Count != PossibleWords.Count)
        {
            usedWords.Add(tryWord);
            tryWord = PossibleWords[Random.Range(0, PossibleWords.Count)];
        }
        if (usedWords.Count != PossibleWords.Count)
        {
            usedWords.Add(tryWord);
            return tryWord;
        }
        else
        {
            return null;
        }
    }

    //Tenta Colocar uma palavra no tabuleiro, testando todas as direcoes e posicoes possiveis em ordem aleatoria
    public bool setWord(string word)
    {
        List<Cell> usedCells = new List<Cell>();
        word = word.ToUpper();
        Cell target = CellGrid.Instance.RandomCell();
        while (!CheckforEachDirection(word, target) && usedCells.Count != CellGrid.Instance.cells.Length) //checa todas as direções e posições possiveis
        {
            usedCells.Add(target);
            while (usedCells.Contains(target) && usedCells.Count != CellGrid.Instance.cells.Length)
            {
                target = CellGrid.Instance.RandomCell();
            }
        }
        if (usedCells.Count != CellGrid.Instance.cells.Length) //se passou do while e ainda existe diferença, é pq a direção deu certo
        {
            PlaceWord(target, direction, word); //coloca a palavra
            return true;
        }
        else
        {
            return false;
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
