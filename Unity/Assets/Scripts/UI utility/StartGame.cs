using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StartGame : MonoBehaviour
{


    public GameObject errorPanel;
    public TextMeshProUGUI text;
    private LevelData level;

    public void startGame()
    {
        level = MenuManager.instance.level;
        if (CheckConditions())
        SceneManager.LoadScene("Main");
    }


    //verifica se os parametros podem formar um tabuleiro
    public bool CheckConditions()
    {

        if (level.NumberOfWords > Utility.FindLesserOnList(level.Theme.Words, level.MaxWordSize) ||
            level.NumberOfWords == 0 ||
            level.NumberOfWords > Mathf.Max(level.GridSize.x, level.GridSize.y) - 1)
        {
            text.text = "Erro: Number of Words nao aceitavel \n * Number of Words deve ser maior que 0 \n * Number of Words deve ser menor q o tamanho do grid \n * Talvez nao existam palavras o suficiente com esse tamanho";
            errorPanel.SetActive(true);
            return false;
        }

        if (level.MaxWordSize == 0 || 
            level.MaxWordSize > Mathf.Max(level.GridSize.x, level.GridSize.y))
        {
            text.text = "Erro: Max Word Size nao aceitavel \n * Max Word Size deve ser maior que 0 \n * Max Word Size deve ser menor que Grid \n * devem existir palavra o suficiente nesse parametros";
            errorPanel.SetActive(true);
            return false;
        }

        if(level.GridSize.magnitude < 7)
        {
            text.text = "Erro: Grid muito pequena \n * Grid deve ser pelo menos 5 x 5";
            errorPanel.SetActive(true);
            return false;
        }
        return true;
    }
}
