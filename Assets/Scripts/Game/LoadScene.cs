using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene("Igor'Anim");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
