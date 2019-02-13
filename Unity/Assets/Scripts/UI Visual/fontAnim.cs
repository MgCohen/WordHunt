using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fontAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        anim.SetBool("hover", true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        anim.SetBool("hover", false);
    }
}
