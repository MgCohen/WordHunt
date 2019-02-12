using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Transform one;
    public Transform last;

    private void Update()
    {
        Debug.Log(Vector2.Angle(one.position, last.position));
    }
}
