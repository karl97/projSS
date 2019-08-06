using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIhandler : MonoBehaviour
{
    public void goReset()
    {
        Application.LoadLevel("Game");
    }
    public void goMenu()
    {

        Application.LoadLevel("MainMenu");

    }
}
