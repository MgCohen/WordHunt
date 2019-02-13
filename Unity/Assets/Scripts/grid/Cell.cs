using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

    //elemento basico que compõe o board
    //cada celula representa uma letra, e pode ser selecionada para formar uma palavra


    public Vector2 gridPos; //pos no tabuleiro
    public bool random; //essa celula pertecen a uma palavra ou é aleatoria?
    public char Char; //letra da celula

    [SerializeField]
    private Animator anim = null;

    [SerializeField]
    private TextMeshProUGUI text = null; //letra da celula(texto)

    //Setter das celulas para definir seus valores
    public void setCell(Vector2 pos, bool isRandom, char character)
    {
        gridPos = pos;
        random = isRandom;
        text.text = character.ToString();
        Char = character;
    }

    //Setter da celula quando ela ja possui posições definidas
    public void setCell(bool isRandom, char Character)
    {
        random = isRandom;
        Char = Character;
        text.text = Character.ToString();
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

        bool selection = anim.GetBool("Selected");
        anim.SetBool("Selected", !selection);
        if (!selection)
        {
            Manager.instance.wordFinder.SelectCell(this);
        }
        else
        {
            Manager.instance.wordFinder.DeselectCell(this);
        }

    }
}
