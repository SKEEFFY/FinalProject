using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSettings : MonoBehaviour
{
    public static UnityEvent EnableSoundSetting = new();

    private void Awake()
    {
        MenuButtons.CloseGameSettings.AddListener(CloseSettings);
    }

    public void EnableSetting()
    {
        gameObject.SetActive(true);
        EnableSoundSetting.Invoke();
    }

    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
