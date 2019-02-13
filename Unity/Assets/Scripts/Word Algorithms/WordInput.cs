using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    //Classe base para inserção de palavras na grid



    public List<string> ValidWords;
    public List<string> usedWords;
    private Vector2 direction;

    public CellGrid grid;
    public WordFinder finder;

    private bool fail;

    public int counter = 0;

    //Coloca todas as palavras no tabuleiro
    public void PopulateBoard(int NumberOfWords)
    {
        //inicializa contagem para sair de loop infinito
        //inicializa contagem de palavras presentes
        int wordCounter = 0;
        if (counter > 15)
        {
            Debug.Log("too many attempts");
            return;
        }
        //loop o numero de palavras requisitadas
        for (int i = 0; i < NumberOfWords; i++)
        {
            string currentWord = getValidWorld();
            //verifica se a palavra pode ser encaixada ou se ainda existem palavras
            while (!setWord(currentWord) && currentWord != null) 
            {
                //tenta outra palavra valida
                currentWord = getValidWorld();
            }
            if (currentWord == null)
            {
                //não existem mais palavras validas, recomeçar
                fail = true;
                break;

            }
        }
        //se a criação do tabuleiro falhou, recomeçar
        if (fail)
        {
            fail = false;
            Manager.instance.ResetBoard();
            Manager.instance.SetBoard();
            counter += 1;
        }
        else
        {
            //se houver algum palavrão refazer tabuleiro
            foreach (string bannedWord in Manager.instance.dictionary.BannedWords)
            {
                if (WordFilter.SearchWord(bannedWord) != null)
                {
                    fail = false;
                    Manager.instance.ResetBoard();
                    Manager.instance.SetBoard();
                    counter += 1;
                    return;
                }
            }
            //verifica o numero de palavras escolhidas no tabuleiro
            foreach (string repeatedWord in Manager.instance.level.Theme.Words)
            {
                if(WordFilter.SearchWord(repeatedWord) != null)
                {
                    wordCounter += 1;
                }
            }
            //caso seja maior que o numero de palavras requisitado, recomeçar
            if(wordCounter > Manager.instance.gridWords.Count)
            {
                fail = false;
                Manager.instance.ResetBoard();
                Manager.instance.SetBoard();
                counter += 1;
            }
            else
            {
                counter = 0;
            }
        }

    }

    //pega palavra de lista e verifica se é aceitavel.
    public string getValidWorld()
    {

        int MaxStringSize = Mathf.Max((int)grid.GridSize.x, (int)grid.GridSize.y);
        //pega uma palavra aleatoria e verifica se atende as condições
        string tryWord = ValidWords[Random.Range(0, ValidWords.Count)];
        while ((usedWords.Contains(tryWord) || tryWord.Length >= MaxStringSize) && usedWords.Count != ValidWords.Count)
        {
            usedWords.Add(tryWord);
            tryWord = ValidWords[Random.Range(0, ValidWords.Count)];
        }
        //caso ainda tenha palavras validas, usa a palavra selecionada
        if (usedWords.Count != ValidWords.Count)
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
    
        if (word == null)
        {
            return false;
        }
        if(WordFilter.SearchWord(word) != null) //se a palavra ja existe no tabuleiro, use-a
        {
            int index = Random.Range(0, 2);
            Manager.instance.gridWords.Add(WordFilter.SearchWord(word, index));
            WordFilter.SearchWord(word, index).setRandom(false);
            return true;
        }

        List<Cell> usedCells = new List<Cell>();
        word = word.ToUpper();
        Cell target = grid.RandomCell();

        //checa todas as direções e posições possiveis em cada celula
        while (!CheckforEachDirection(word, target) && usedCells.Count != grid.cells.Length) 
        {
            usedCells.Add(target);
            while (usedCells.Contains(target) && usedCells.Count != grid.cells.Length)
            {
                target = grid.RandomCell();
            }
        }
        if (usedCells.Count != grid.cells.Length) //se passou do while e ainda existe diferença, é pq a direção deu certo
        {
            PlaceWord(target, direction, word); //coloca a palavra
            return true;
        }
        else
        {
            return false;
        }
    }

    //Escolhe uma direção aleatoria e verifica se é possivel colocar a palavra
    public bool CheckforEachDirection(string word, Cell target)
    {
        //vetor direções predefinidas
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


    //Checar se a palavra cabe no na celula alvo e se a celular ja esta sendo usada
    //usa a direção recebida de CheckAllDirections para saber para onde verificar
    public bool CheckFit(string word, Cell target, Vector2 dir)
    {
        int wordSize = word.Length;
        if (((target.gridPos.x * dir.x) + wordSize > grid.GridSize.x) || ((target.gridPos.y * dir.y) + wordSize > grid.GridSize.y))
        {
            return false;
        }
        else
        {
            for (int i = 0; i < wordSize; i++)
            {
                Cell newTarget = grid.cells[(int)(target.gridPos.x + (dir.x * i)), (int)(target.gridPos.y + (dir.y * i))];
                if (!newTarget.random && newTarget.Char != word.ToUpper()[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    //Coloca a palavra verificada nas celulas verificadas nos metodos anteriores
    public void PlaceWord(Cell target, Vector2 Dir, string Word)
    {
        List<Cell> usedCells = new List<Cell>();
        for (int i = 0; i < Word.Length; i++)
        {
            Cell targetCell = grid.cells[(int)(target.gridPos.x + (Dir.x * i)), (int)(target.gridPos.y + (Dir.y * i))];
            targetCell.setCell(false, Word[i]);
            usedCells.Add(targetCell);
        }
        //cria uma instancia de GridedWords para ser usado na localização da palavra
        Manager.instance.gridWords.Add(new GridedWord(Word, usedCells));
    }

    //reset palavras usadas para refazer o board
    public void ResetInput()
    {
        usedWords.Clear();
    }
}


