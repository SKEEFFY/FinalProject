using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyStats _enemyStats;
    private int _healthPoint;

    public static UnityEvent RanOutOfHealth = new();

    public void Start()
    {
        _healthPoint = _enemyStats.HealthPoint;
        PlayerFight.PlayerAttackEnemy.AddListener(TakeDamage);
    }

    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;
        Debug.Log("Enemy Health" + _healthPoint.ToString());
        if (_healthPoint <= 0)
        {
            RanOutOfHealth.Invoke();
        }
    }        
}
