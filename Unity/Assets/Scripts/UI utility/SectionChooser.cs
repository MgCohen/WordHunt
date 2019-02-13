using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionChooser : MonoBehaviour
{
    public Dictionary dictionary;

    public GameObject portraitPrefab;
    public Transform portraitMenu;

    public List<GameObject> portraits;

    private void OnEnable()
    {
        foreach(Section sec in dictionary.Themes)
        {
            GameObject newPortrait = Instantiate(portraitPrefab, portraitMenu);
            portraits.Add(newPortrait);
            newPortrait.GetComponent<SectionPortrait>().setPortrait(sec);
        }
    }
}
