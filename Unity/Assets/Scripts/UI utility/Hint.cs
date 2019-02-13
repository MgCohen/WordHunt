using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hint : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int numberOfHints;
    private List<Cell> hintedCells = new List<Cell>();

    private void OnEnable()
    {
        numberOfHints = Manager.instance.level.NumberOfHints;
        text.text = "Hint: " + numberOfHints.ToString();
    }

    public void giveHint()
    {
        if(numberOfHints <= 0)
        {
            GetComponent<Button>().interactable = false;
            return;
        }
        numberOfHints -= 1;
        int index1 = Random.Range(0, Manager.instance.gridWords.Count);
        while (Manager.instance.gridWords[index1].isFound)
        {
            index1 = Random.Range(0, Manager.instance.gridWords.Count);
        }
        int index2 = Random.Range(0, Manager.instance.gridWords[index1].positions.Count);
        while (hintedCells.Contains(Manager.instance.gridWords[index1].positions[index2]))
        {
            index2 = Random.Range(0, Manager.instance.gridWords[index1].positions.Count);
        }

        hintedCells.Add(Manager.instance.gridWords[index1].positions[index2]);
        Manager.instance.gridWords[index1].positions[index2].GetComponent<Animator>().SetBool("Selected", true);
        Manager.instance.wordFinder.SelectCell(Manager.instance.gridWords[index1].positions[index2]);

        text.text = "Hints: " + numberOfHints.ToString();
        if(numberOfHints <= 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
