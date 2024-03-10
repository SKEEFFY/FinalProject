using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [Header("Sliders")]
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;
    [Header("Icons")]
    [SerializeField] private Image _musicIcon;
    [SerializeField] private Image _soundIcon;

    private Color _color;
     
    private const string MusicVolume = "MusicVolume";
    private const string SFXVolume = "SFXVolume";
    private const string HFXVolume = "HFXVolume";

    private bool _isVolume = true;

    public static UnityEvent CloseSettingMenu = new();
    public static UnityEvent<bool> PlayStopMusic = new();

    private void Awake()
    {
        ChangeMusicVolume();
        ChangeSFXVolume();
        _color = _musicIcon.color;
    }

    public void CloseSoundSettings()
    {
        CloseSettingMenu.Invoke();
    }

    public void ChangeMusicVolume()
    {
        PlayStopMusic.Invoke(true);
        _audioMixer.SetFloat(MusicVolume, Mathf.Log(_musicVolumeSlider.value) * 20);
        if(_musicVolumeSlider.value != 0 && !_isVolume)
        {
            _isVolume = true;
            PlayStopMusic.Invoke(_isVolume);
            _musicIcon.color = _color;

        }

        if(_musicVolumeSlider.value == 0f)
        {
            _isVolume = false;
            PlayStopMusic.Invoke(_isVolume);
            _musicIcon.color = Color.red;
        }
    }

    public void ChangeSFXVolume()
    {
        _audioMixer.SetFloat(SFXVolume, Mathf.Log(_sfxVolumeSlider.value) * 20);
        _audioMixer.SetFloat(HFXVolume, Mathf.Log(_sfxVolumeSlider.value) * 20);
    }

}
