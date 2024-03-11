using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class OnOpenSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _instrumentChannel;

    private float _initialVolume;

    private const string InstrumentVolume = "MusicInstrumentalVolume";

    private void Start()
    {
        _instrumentChannel.GetFloat(InstrumentVolume, out _initialVolume);
        PauseGame.ActivePause.AddListener(VolumeDownOnInstruments);
    }

    private void VolumeDownOnInstruments(bool isActive)
    {
        if(!isActive)
        {
            Debug.LogWarning("1111");
            _instrumentChannel.SetFloat(InstrumentVolume, 0.001f);
        }
        else
        {
            _instrumentChannel.SetFloat(InstrumentVolume, _initialVolume);
        }
    }
}
