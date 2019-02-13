using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wordCountUI : MonoBehaviour
{

    public TextMeshProUGUI text;
    private int foundWords;
    private int totalwords;

    public ParticleSystem particle;


    private void Start()
    {
        totalwords = Manager.instance.level.NumberOfWords;
        text.text = (totalwords - Manager.instance.wordsFound).ToString();
        foundWords = 0;
    }
    void Update()
    {
        if (foundWords != Manager.instance.wordsFound)
        {
            text.text = (totalwords - Manager.instance.wordsFound).ToString();
            foundWords = Manager.instance.wordsFound;
            particle.Play();
        }
    }
}
