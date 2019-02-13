using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWordsConfig : MonoBehaviour
{
    public TMP_InputField NumberWords;

    private void OnEnable()
    {
        NumberWords.text = MenuManager.instance.level.NumberOfWords.ToString();
        CheckChange();
    }

    public void CheckChange()
    {
        if(NumberWords.text == "")
        {
            return;
        }
        int max = (int)Mathf.Max(MenuManager.instance.level.GridSize.x, MenuManager.instance.level.GridSize.y);
        int number = int.Parse(NumberWords.text);

        number = Mathf.Clamp(number, 4, max -1);
        NumberWords.text = number.ToString();
        SendChange();
    }

    public void SendChange()
    {
        MenuManager.instance.level.NumberOfWords = int.Parse(NumberWords.text);
    }
}
