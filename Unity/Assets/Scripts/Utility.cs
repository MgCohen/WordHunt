using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    //pegar caracter aleatorio de lista definida
    static string RC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static char getCharacter()
    {
        return RC[Random.Range(0, RC.Length)];
    }

    //algoritmo para comparar se 2 listas sao identicas independente da ordem
    public static bool CompareLists<T>(List<T> aListA, List<T> aListB, bool differentSize = false)
    {
        if (aListA == null || aListB == null || (aListA.Count != aListB.Count && differentSize == false))
            return false;
        if (aListA.Count == 0)
            return true;
        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count))
            {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count))
            {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB 
        return (differentSize == true || lookUp.Count == 0) ? true : false;
    }


    public static bool CompareOrderedLists<T>(List<T> one, List<T> theOther)
    {
        if (one == null || theOther == null || one.Count != theOther.Count)
            return false;
        if (one.Count == 0)
            return true;
        if (one.Count != theOther.Count) return false;
        for (var i = 0; i < one.Count; i++)
        {
            if (!one[i].Equals(theOther[i])) return false;
        }
        return true;
    }
}
