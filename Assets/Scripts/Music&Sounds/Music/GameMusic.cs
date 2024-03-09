using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSource;
    [SerializeField] private AudioClip[] _audioClip;

    private bool _isPlaying = true;

    private void Start()
    {
        SoundSettings.PlayStopMusic.AddListener(PlayStopMusic);
    }

    private void FixedUpdate()
    {
        PlayGameMusic();
    }

    private void PlayGameMusic()
    {
        if (!_audioSource[0].isPlaying && _isPlaying)
        {
            for (int i = 0; i < _audioSource.Length; i++)
            {
                _audioSource[i].clip = _audioClip[i];
                _audioSource[i].Play();
            }
        }
    }

    private void PlayStopMusic(bool isPlay)
    {
        _isPlaying = isPlay;
        if (isPlay)
        {
            PlayGameMusic();
        }
        else
        {
            foreach (AudioSource audioSource in _audioSource)
            {
                audioSource.Stop();
            }
        }
    }
}
