using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Section", menuName = "Dictionary/Section")]
public class Section : ScriptableObject
{
    public string Theme;
    public Sprite ThemeImage;
    public List<string> Words;
}
