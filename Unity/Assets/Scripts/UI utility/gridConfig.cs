using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gridConfig : MonoBehaviour
{

    public TMP_InputField gridX;
    public TMP_InputField gridY;

    //verifica para qual valor foi modificado, e se for menor q 5 muda para 5
    public void checkChange()
    {
        Debug.Log("changed");
        if(gridX.text == "" || gridY.text == "")
        {
            Debug.Log("is Empty");
            return;
        }
        Vector2 gridSize = new Vector2(Mathf.Clamp(int.Parse(gridX.text), 5, 15), Mathf.Clamp(int.Parse(gridY.text), 5, 15));
        gridX.text = gridSize.x.ToString();
        gridY.text = gridSize.y.ToString();

        SendChange(gridSize);
    }

    //modifica as informações do level
    public void SendChange(Vector2 gridSize)
    {
        MenuManager.instance.level.GridSize = gridSize;
    }
}
