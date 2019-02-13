using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class themeRestriction : MonoBehaviour
{

    private void Update()
    {
        if(MenuManager.instance.level.Theme == null)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
