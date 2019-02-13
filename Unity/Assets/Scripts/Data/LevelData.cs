using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Level")]
public class LevelData : ScriptableObject
{

    public int NumberOfWords; //numero de palavras que devem existir no mapa
    public Vector2 GridSize; //tamanho do mapa
    public Section Theme; //tematica usada
    public int MaxWordSize; //maximo numero de caracteres em uma palavra
    public int NumberOfHints; //numero de dicas que podem ser dadas em cada partida


}


