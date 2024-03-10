using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : TextFontChange
{
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
