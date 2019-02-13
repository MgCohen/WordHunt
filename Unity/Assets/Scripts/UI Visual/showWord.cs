using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showWord : MonoBehaviour
{

    public Transform target;
    public GameObject wordPrefab;
    public List<GameObject> words;

    private void Start()
    {
        foreach(GridedWord word in Manager.instance.gridWords)
        {
            displayWord(word.word);
        }
    }

    public void displayWord(string word)
    {
        GameObject newWord = Instantiate(wordPrefab, target);
        words.Add(newWord);
        newWord.GetComponentInChildren<TextMeshProUGUI>().text = word;
    }

    public void wordFound(string word)
    {
        foreach(GameObject wordObj in words)
        {
            if(wordObj.GetComponentInChildren<TextMeshProUGUI>().text == word)
            {
                wordObj.transform.SetAsLastSibling();
                wordObj.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
            }
        }
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
