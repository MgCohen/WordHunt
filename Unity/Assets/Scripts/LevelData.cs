using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Level")]
public class LevelData : ScriptableObject
{

    public int NumberOfWords;
    public Vector2 GridSize;
    public Section Theme;
}
