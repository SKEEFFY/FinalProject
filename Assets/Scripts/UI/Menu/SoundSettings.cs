using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;

    private const string MusicVolume = "MusicVolume";
    private const string SFXVolume = "SFXVolume";
    private const string HFXVolume = "HFXVolume";

    private bool _isVolume = true;

    public static UnityEvent CloseSettingMenu = new();
    public static UnityEvent<bool> PlayStopMusic = new();

    private void Start()
    {
        ChangeMusicVolume();
        ChangeSFXVolume();
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
        }

        if(_musicVolumeSlider.value == 0f)
        {
            _isVolume = false;
            PlayStopMusic.Invoke(_isVolume);
        }
    }

    public void ChangeSFXVolume()
    {
        _audioMixer.SetFloat(SFXVolume, Mathf.Log(_sfxVolumeSlider.value) * 20);
        _audioMixer.SetFloat(HFXVolume, Mathf.Log(_sfxVolumeSlider.value) * 20);
    }

}
