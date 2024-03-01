using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("PlayerStats")]
    [SerializeField] private int _damage = 20;
    [SerializeField] private int _spendStaminaOnBlock = 3;
    [SerializeField] private int _spendStaminaOnAttack = 5;
    private int _healthPoint = 100;
    private int _staminaPoints = 100;

    public static UnityEvent<int> UpdateStaminaSlider = new();  

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public int SpendStaminaOnBlock
    {
        get => _spendStaminaOnBlock;
        set => _spendStaminaOnBlock = value;
    }

    public int SpendStaminaOnAttack
    {
        get => _spendStaminaOnAttack;
        set => _spendStaminaOnAttack = value;
    }

    public int HealthPoint => _healthPoint;

    public int StaminaPoints
    {
        get => _staminaPoints;
        set
        {
            _staminaPoints = value;
            if(_staminaPoints > 100)
            {
                _staminaPoints = 100;
            }
            UpdateStaminaSlider.Invoke(_staminaPoints);
        }
    }
    

}
