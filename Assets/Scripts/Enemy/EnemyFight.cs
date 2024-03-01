using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackDistance = 2.2f;
    [SerializeField] private EnemyStats _enemyStats;

    private static readonly int AnimatorParametrAttack = Animator.StringToHash("Attack");

    public static UnityEvent<int> EnemyAttackPlayer = new();

    private void Start()
    {
        EnemyHitBox.EnemyHitPlayer.AddListener(Attack);
    }
    private void Update()
    {
        IsCanAttack();
    }

    private void IsCanAttack()
    {
        if (Vector3.Distance(transform.position, _target.position) <= _attackDistance)
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                _animator.SetBool(AnimatorParametrAttack, true);
            }
        }
        else
        {
            _animator.SetBool(AnimatorParametrAttack, false);
            _agent.SetDestination(_target.position); 
        }
    }

    private void Attack()
    {
        EnemyAttackPlayer.Invoke(_enemyStats.Damage);
    }
}
