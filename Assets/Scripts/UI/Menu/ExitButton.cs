using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MenuButtons
{
    public void ExitFromGame()
    {
        Application.Quit();
    }
    
}
