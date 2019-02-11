using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dictionary", menuName = "Dictionary")]
public class Dictionary : ScriptableObject
{
    public List<Section> Themes; //grupo de palavras para ser usado em cada tema

    public List<string> BannedWords; //palavras para serem filtradas
}

[System.Serializable]
public class Section
{
    public string Theme;
    public Sprite ThemeImage;
    public List<string> Words;
}
