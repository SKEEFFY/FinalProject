using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    [Header("EnemyStats")]
    [SerializeField] private int _damage = 20;
    [SerializeField] private int _healthPoint = 100;

    [Header("NavMeshAgent Steering")]
    private NavMeshAgent _navMeshAgent;
    private float _movementSpeed = 3.5f;
    private float _angularSpeed = 720f;
    private float _accelaration = 200f;

    public EnemyStats()
    {
        _damage = 20;
        _healthPoint = 100;
        _movementSpeed = 3.5f;
        _angularSpeed = 720f;
        _accelaration = 200f;
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _movementSpeed;
        _navMeshAgent.angularSpeed = _angularSpeed;
        _navMeshAgent.acceleration = _accelaration;
    }

    public int Damage
    { get => _damage;}

    public int HealthPoint => _healthPoint;
        
}
