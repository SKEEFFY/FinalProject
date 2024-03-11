using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private IsActivePauseMenu _pauseMenu;
    [SerializeField] private GameObject _gameHUD;
    //[SerializeField] private 
    public static UnityEvent<bool> ActivePause = new();

    private bool _isActivePause = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EnableDisablePause();
        }
    }

    private void EnableDisablePause()
    {
        if(!_isActivePause)
        {
            Time.timeScale = 0f;
            Activator(_isActivePause);
        }
        else
        {
            Time.timeScale = 1;
            Activator(_isActivePause);
        }
    }

    private void Activator(bool isActive)
    {
        _isActivePause = !isActive;
        ActivePause.Invoke(isActive);
        _gameHUD.SetActive(isActive);
        _pauseMenu.gameObject.SetActive(!isActive);
    }
}