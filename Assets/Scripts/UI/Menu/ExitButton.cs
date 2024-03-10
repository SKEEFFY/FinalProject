using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : TextFontChange
{
    public void ExitFromGame()
    {
        Application.Quit();
    }
    
}
