using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Level")]
public class LevelData : ScriptableObject
{

    public int NumberOfWords; //numero de palavras que devem existir no mapa
    public Vector2 GridSize; //tamanho do mapa
    public Section Theme; //tematica usada

    //lista de palavras e a posicao de cada letra
    public List<GridedWord> gridWords;

}


//classe usada para definir uma palavra no grid e ter sua localização possivel
[System.Serializable]
public class GridedWord
{
    public GridedWord(string thisWord, List<Cell> myPos)
    {
        word = thisWord;
        positions = myPos;
        wordChars.AddRange(thisWord);
    }

    public GridedWord(List<char> letters, List<Cell> myPos)
    {
        word = new string(letters.ToArray());
        positions = myPos;
        wordChars = letters;
    }
    public string word;
    public List<Cell> positions;
    public bool isFound;
    public List<char> wordChars = new List<char>();
}