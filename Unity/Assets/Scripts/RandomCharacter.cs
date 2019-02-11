using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacter
{
    static string RC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static char getCharacter()
    {
        return RC[Random.Range(0, RC.Length)];
    }
}
