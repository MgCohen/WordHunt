using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFinder : MonoBehaviour
{


    public List<GridedWord> gridWords;

    public void ResetWords()
    {
        gridWords.Clear();
    }

}
