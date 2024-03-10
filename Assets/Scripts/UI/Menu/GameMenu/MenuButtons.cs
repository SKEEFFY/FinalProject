using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButtons : MonoBehaviour
{
    public static UnityEvent CloseGameSettings = new();

    private void Awake()
    {
        GameSettings.EnableSoundSetting.AddListener(ActiveMenuButtons);
    }

    private void ActiveMenuButtons()
    {
        gameObject.SetActive(false);
    }

    public void ExitFromGameSettings()
    {
        gameObject.SetActive(true);
        CloseGameSettings.Invoke();
    }
}
