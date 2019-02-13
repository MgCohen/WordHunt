using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPossibleWords : MonoBehaviour
{
    //demonstra palavras possiveis de serem usadas em um determinado painel baseado no tema escolhido

    private Section ChoosenSection;

    public List<GameObject> words;

    public Transform parent;
    public GameObject wordPrefab;

    private void Update()
    {
        //caso o tema escolhido não seja o tema apresentado, apaga as palavras presentes e instancia as corretas
        if(MenuManager.instance.level.Theme != ChoosenSection)
        {
            ChoosenSection = MenuManager.instance.level.Theme;
            EraseWords();
            fillWords();
        }
    }

    //apaga todas as instancias de palavras atuais
    public void EraseWords()
    {
        foreach(GameObject obj in words)
        {
            Destroy(obj);
        }
        words.Clear();
    }

    //coloca novas instancias de palavras com o tema correto
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
