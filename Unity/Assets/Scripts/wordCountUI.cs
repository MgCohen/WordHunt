using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wordCountUI : MonoBehaviour
{

    public TextMeshProUGUI text;
    private int totalwords;
    // Update is called once per frame

    private void Start()
    {
        totalwords = Manager.instance.level.NumberOfWords;
    }
    void Update()
    {
        text.text = (totalwords - Manager.instance.wordsFound).ToString();
    }
}
