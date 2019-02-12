using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SectionPortrait : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Section section;

    public Animator anim;

    public TextMeshProUGUI Theme;
    public TextMeshProUGUI Sample1;
    public TextMeshProUGUI Sample2;
    public TextMeshProUGUI Sample3;
    public TextMeshProUGUI Sample4;

    public Image sprite;


    public void setPortrait(Section mySection)
    {
        section = mySection;
        Theme.text = section.Theme;
        sprite.sprite = section.ThemeImage;
        Sample1.text = section.Words[0];
        Sample2.text = section.Words[1];
        Sample3.text = section.Words[2];
        Sample4.text = section.Words[3];
    }


    public void OnPointerEnter(PointerEventData data)
    {
        anim.SetBool("Hover", true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        anim.SetBool("Hover", false);
    }

    public void OnPointerClick(PointerEventData data)
    {
        anim.SetBool("Hover", false);
        anim.SetBool("Selected", true);
    }
}
