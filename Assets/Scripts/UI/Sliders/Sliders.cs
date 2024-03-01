using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _staminaSlider;

    private void Start()
    {
        PlayerHealth.UpdateHealthSlider.AddListener(UpdateHealthSlider);
        PlayerStats.UpdateStaminaSlider.AddListener(UpdateStaminaSlider);
    }

    private void UpdateHealthSlider(int value)
    {
        _healthSlider.value = value;
    }

    private void UpdateStaminaSlider(int value)
    {
        _staminaSlider.value = value;
    }
    
    
}
