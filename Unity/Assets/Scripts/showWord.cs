using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showWord : MonoBehaviour
{

    public Transform target;
    public GameObject wordPrefab;
    public List<GameObject> words;

    public void displayWord(string word)
    {
        GameObject newWord = Instantiate(wordPrefab, target);
        words.Add(newWord);
        newWord.GetComponentInChildren<TextMeshProUGUI>().text = word;
    }


    public void ClearWords()
    {
        foreach(GameObject obj in words)
        {
            Destroy(obj);
        }
        words.Clear();
    }
}
