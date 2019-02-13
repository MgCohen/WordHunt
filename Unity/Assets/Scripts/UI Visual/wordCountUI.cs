using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wordCountUI : MonoBehaviour
{
    //Conta o numero de palavras a serem encontradas/ja encontradas e mostra ao jogador
    //ativa uma particula toda vez que é executado


    public TextMeshProUGUI text;
    private int foundWords;
    private int totalwords;

    public ParticleSystem particle;

    //define os valores base
    private void Start()
    {
        totalwords = Manager.instance.level.NumberOfWords;
        text.text = (totalwords - Manager.instance.wordsFound).ToString();
        foundWords = 0;
    }

    //se o valor atual for diferente do valor do level, atualiza e mostra
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
