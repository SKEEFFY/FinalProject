using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivePauseMenuButtons : MonoBehaviour
{
    public static UnityEvent CloseGameSettings = new();
    private void Start()
    {
        GameSettings.EnableSoundSetting.AddListener(CloseActivePauseMenuButtons);
    }

    public static UnityEvent OnResume = new();
    public void Resume()
    {
        OnResume.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void CloseActivePauseMenuButtons()
    {
        gameObject.SetActive(false);
    }
    public void CloseSettings()
    {
        CloseGameSettings.Invoke();
        gameObject.SetActive(true);
    }
}
