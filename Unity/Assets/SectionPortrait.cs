using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SectionPortrait : MonoBehaviour
{

    public Section section;

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
}
