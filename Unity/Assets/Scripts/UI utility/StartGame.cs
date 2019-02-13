using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public Button but;
    LevelData level = MenuManager.instance.level;

    private void Update()
    {
        //verifica se todos os campos foram utilizados para poder começar o jogo
        if (level.Theme == null || level.NumberOfWords == 0 || level.MaxWordSize == 0 || level.GridSize.magnitude < 7)
        {
            but.interactable = false;
        }
        else
        {
            but.interactable = true;
        }
    }

    public void startGame()
    {
        if(CheckConditions())
        SceneManager.LoadScene("Main");
        else
        {
            //show message suggesting to adjust parameters
        }
    }


    //verifica se os parametros podem formar um tabuleiro
    public bool CheckConditions()
    {
        if(level.NumberOfWords > Utility.FindLesserOnList(level.Theme.Words, level.MaxWordSize))
        {
            return false;
        }
        return true;
    }
}
