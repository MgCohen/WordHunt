using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPossibleWords : MonoBehaviour
{


    private Section ChoosenSection;

    public List<GameObject> words;

    public Transform parent;
    public GameObject wordPrefab;

    private void Update()
    {
        if(MenuManager.instance.level.Theme != ChoosenSection)
        {
            ChoosenSection = MenuManager.instance.level.Theme;
            EraseWords();
            fillWords();
        }
    }

    public void EraseWords()
    {
        foreach(GameObject obj in words)
        {
            Destroy(obj);
        }
        words.Clear();
    }

    public void fillWords()
    {
        foreach(string word in ChoosenSection.Words)
        {
            GameObject newWord = Instantiate(wordPrefab, parent);
            words.Add(newWord);
            newWord.GetComponentInChildren<TextMeshProUGUI>().text = word;
        }
    }
}
