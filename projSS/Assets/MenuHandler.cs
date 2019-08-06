using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
   public void openGame()
    {
        Application.LoadLevel("Game");


    }
    public void quitGame()
    {
        Application.Quit();


    }
}
