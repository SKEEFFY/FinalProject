using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    [SerializeField] private GameObject _loseImage;
    [SerializeField] private GameObject _winImage;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private PlayerControll _playerObject;
    [SerializeField] private GameObject[] _enemies;

    private void Start()
    {
        PlayerHealth.OnPlayerDeath.AddListener(ShowLoseScreensaver);
        EnemyHealth.RanOutOfHealth.AddListener(ShowWinScreensaver);
    }

    private void ShowWinScreensaver()
    {
        _winImage.SetActive(true);
        _playerObject.enabled = false;
        foreach (var player in _enemies)
        {
            player.SetActive(false);
        }
        _buttons.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void ShowLoseScreensaver()
    {
        _loseImage.SetActive(true);
        _playerObject.enabled = false;
        foreach (var enemie in _enemies)
        {
            enemie.SetActive(false);
        }
        _buttons.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
