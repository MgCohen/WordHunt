using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class themeName : MonoBehaviour
{
    //modifcação de texto baseado no tema atualmente escolhido


    TextMeshProUGUI text;
    private enum type { Menu, Game }
    [SerializeField]
    private type themeType = type.Menu;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (themeType == type.Game && Manager.instance.level.Theme != null && text.text != Manager.instance.level.Theme.Theme)
            text.text = Manager.instance.level.Theme.Theme;

        if (themeType == type.Menu && MenuManager.instance.level.Theme != null && text.text != MenuManager.instance.level.Theme.Theme)
            text.text = MenuManager.instance.level.Theme.Theme;
    }
}
