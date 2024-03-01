using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    private int _health;

    public static UnityEvent<int> UpdateHealthSlider = new();
    public static UnityEvent OnPlayerDeath = new();

    private void Start()
    {
        PlayerFight.EnemyAttackPlayer.AddListener(TakeDamage);
        _health = _playerStats.HealthPoint;
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log("Player Damaged" + damage.ToString());
        UpdateHealthSlider.Invoke(_health);
        if (_health <= 0)
        {
            OnPlayerDeath.Invoke();
        }
    }
}
