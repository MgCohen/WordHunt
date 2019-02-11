using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showWord : MonoBehaviour
{

    public Transform target;
    public GameObject wordPrefab;

    public void displayWord(string word)
    {
        (Instantiate(wordPrefab, target)).GetComponentInChildren<TextMeshProUGUI>().text = word;
    }
}
