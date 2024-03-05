using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MenuButtons
{
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
