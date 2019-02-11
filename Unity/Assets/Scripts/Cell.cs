﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{

    public Vector2 gridPos; //pos no tabuleiro
    public bool random; //essa celula pertecen a uma palavra ou é aleatoria?
    public char Char; //letra da celula

    [SerializeField]
    private TextMeshProUGUI text = null; //letra da celula(texto) (null para evitar warning no console)



    //Setter das celulas para definir seus valores
    public void setCell(Vector2 pos, bool isRandom, char character) 
    {
        gridPos = pos;
        random = isRandom;
        text.text = character.ToString();
        Char = character;
    }

    public void setCell(bool isRandom, char Character)
    {
        random = isRandom;
        Char = Character;
        text.text = Character.ToString();
        
    }
}
