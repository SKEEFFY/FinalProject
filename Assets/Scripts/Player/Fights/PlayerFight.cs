using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _restPoint = 1;

    private float _animationAttackLength = 1.11f;
    private float _animationBlockLength = 0.7f;
    public bool IsSpendStaminaCoroutineRuning { get; private set; } = false;
    private bool _isCorotineStart = false;

    private static readonly int HashAnimatorBoolAttack = Animator.StringToHash("Attack");
    private static readonly int HashAnimatorBoolBlock = Animator.StringToHash("Block");

    public static UnityEvent<int> PlayerAttackEnemy = new();
    public static UnityEvent<int> EnemyAttackPlayer = new();

    private void Start()
    {
        PauseGame.ActivePause.AddListener(DisablePlayerFight);
        PlayerHitBox.PlayerHitEnemy.AddListener(Attack);
        EnemyFight.EnemyAttackPlayer.AddListener(TakeDamage);
    }

    private void Update()
    {
        IsCanAttack();
        Block();
        StartCoroutine(Rest());
    }

    private void DisablePlayerFight(bool isActive)
    {
        if (isActive)
        {
            PlayerFight playerFight = this;
            playerFight.enabled = !playerFight.enabled;
        }
        else
        {
            PlayerFight playerFight = this;
            playerFight.enabled = !playerFight.enabled;
        }
    }

    private void IsCanAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !IsSpendStaminaCoroutineRuning && _playerStats.StaminaPoints >= _playerStats.SpendStaminaOnAttack)
        {
            StartCoroutine(SpendStamina(_playerStats.SpendStaminaOnAttack, _animationAttackLength));
            _animator.SetBool(HashAnimatorBoolAttack, true);
            StartCoroutine(WaitAnimation(_animationAttackLength, HashAnimatorBoolAttack));
        }
    }

    private void Attack()
    {
        PlayerAttackEnemy.Invoke(_playerStats.Damage);
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.Mouse1) && !IsSpendStaminaCoroutineRuning && _playerStats.StaminaPoints >= _playerStats.SpendStaminaOnBlock)// переписать логику траты стамины если получил урон в один метод
        {
            StartCoroutine(SpendStamina(_playerStats.SpendStaminaOnBlock, _animationBlockLength));
            _animator.SetBool(HashAnimatorBoolBlock, true);
            StartCoroutine(WaitAnimation(_animationBlockLength, HashAnimatorBoolBlock));
        }

    }

    private void TakeDamage(int damage)
    {
        if (_animator.GetBool(HashAnimatorBoolBlock) == true && _playerStats.StaminaPoints >= damage)
        {
            SpendStamina(damage);
        }
        else
        {
            EnemyAttackPlayer.Invoke(damage);
        }
    }
    private void SpendStamina(int damage)
    {
        _playerStats.StaminaPoints -= damage / 2;
    }

    private IEnumerator Rest()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !_isCorotineStart)
        {
            _isCorotineStart = true;
            _playerStats.StaminaPoints += _restPoint;
            yield return new WaitForSeconds(1);
            _isCorotineStart = false;
        }
    }

    private IEnumerator SpendStamina(int staminaType, float animationLength)
    {
        if (_playerStats.StaminaPoints >= staminaType)
        {
            IsSpendStaminaCoroutineRuning = true;
            _playerStats.StaminaPoints -= staminaType;

            yield return new WaitForSeconds(animationLength);
            IsSpendStaminaCoroutineRuning = false;
        }

    }

    private IEnumerator WaitAnimation(float length, int hashAnimator)
    {
        yield return new WaitForSeconds(length);

        _animator.SetBool(hashAnimator, false);
    }
}
