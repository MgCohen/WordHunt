using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class wordSizeConfig : MonoBehaviour
{

    public TMP_InputField wordSize;

    public void CheckChange()
    {
        if(wordSize.text == "")
        {
            return;
        }
        int max = (int)Mathf.Max(MenuManager.instance.level.GridSize.x, MenuManager.instance.level.GridSize.y);

        int number = int.Parse(wordSize.text);
        number = Mathf.Clamp(number, 5, max);

        wordSize.text = number.ToString();

        sendChange();
    }

    public void sendChange()
    {
        MenuManager.instance.level.MaxWordSize = int.Parse(wordSize.text);
    }
}
