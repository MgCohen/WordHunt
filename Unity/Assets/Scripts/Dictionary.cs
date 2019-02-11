using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dictionary", menuName = "Dictionary/Dictionary")]
public class Dictionary : ScriptableObject
{
    public List<Section> Themes; //grupo de palavras para ser usado em cada tema

    public List<string> BannedWords; //palavras para serem filtradas
}

