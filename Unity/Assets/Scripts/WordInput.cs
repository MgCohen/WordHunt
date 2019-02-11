﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public List<string> ValidWords;
    public List<string> usedWords;
    private Vector2 direction;

    public CellGrid grid;


    public WordFinder finder;

    //Coloca todas as palavras no tabuleiro
    public void PopulateBoard(int NumberOfWords)
    {
        //loop o numero de palavras requisitadas
        for (int i = 0; i < NumberOfWords; i++)
        {
            string currentWord = getValidWorld();
            while (!setWord(currentWord) && currentWord != null)
            {
                currentWord = getValidWorld();
            }
            if (currentWord == null)
            {
                //repeat because couldn't finish
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
        if (usedWords.Count != ValidWords.Count)
        {
            Debug.Log("here");
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
        Cell target = grid.RandomCell();
        while (!CheckforEachDirection(word, target) && usedCells.Count != grid.cells.Length) //checa todas as direções e posições possiveis
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
        List<Cell> usedCells = new List<Cell>();
        for (int i = 0; i < Word.Length; i++)
        {
            Cell targetCell = grid.cells[(int)(target.gridPos.x + (Dir.x * i)), (int)(target.gridPos.y + (Dir.y * i))];
            targetCell.setCell(false, Word[i]);
            usedCells.Add(targetCell);
        }
        //cria uma instancia de GridedWords para ser usado na localização da palavra
        finder.gridWords.Add(new GridedWord(Word, usedCells));
    }

    //reset palavras usadas para refazer o board
    public void ResetInput()
    {
        usedWords.Clear();
    }
}

//instance of word that was grided, so we can find it's position
[System.Serializable]
public class GridedWord
{
    public GridedWord(string thisWord, List<Cell> myPos)
    {
        word = thisWord;
        positions = myPos;
    }
    public string word;
    public List<Cell> positions;
}