using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showWord : MonoBehaviour
{
    //representação visual de todas as palavras ja encontradas durante o gameplay


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

    //para cada palavra presente no jogo, coloca na lista
    public void displayWord(string word)
    {
        GameObject newWord = Instantiate(wordPrefab, target);
        words.Add(newWord);
        newWord.GetComponentInChildren<TextMeshProUGUI>().text = word;
    }


    //se uma palavra for encontrada, muda a cor e coloca no fim da lista
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
