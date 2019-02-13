using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintConfig : MonoBehaviour
{
    public TMP_InputField hintNumber;

    public void sendChange()
    {
        if (hintNumber.text != "")
        MenuManager.instance.level.NumberOfHints = int.Parse(hintNumber.text);
    }
}
