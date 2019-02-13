using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class themeName : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = Manager.instance.level.Theme.Theme;
    }
}
