using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{


    public GameObject errorPanel;
    LevelData level = MenuManager.instance.level;

    public void startGame()
    {
        if(CheckConditions())
        SceneManager.LoadScene("Main");
        else
        {
            errorPanel.SetActive(true);
        }
    }


    //verifica se os parametros podem formar um tabuleiro
    public bool CheckConditions()
    {
        if(level.NumberOfWords > Utility.FindLesserOnList(level.Theme.Words, level.MaxWordSize) || level.Theme == null || level.NumberOfWords == 0 || level.MaxWordSize == 0 || level.GridSize.magnitude < 7)
        {
            return false;
        }
        return true;
    }
}
