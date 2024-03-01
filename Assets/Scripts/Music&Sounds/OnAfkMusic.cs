using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OnAfkMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AFK _afk;
    [SerializeField] private float _pitchSpeed;

    public static UnityEvent EndMusic = new UnityEvent();
    public void Start()
    {
        _afk.OnAfk.AddListener(PlayAfkMusic);
        _afk.OffAfk.AddListener(StartCorout);
    }

    private void PlayAfkMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();
        }
    }

    private void StartCorout()
    {
        StartCoroutine(StopAfkMusic());
    }

    private IEnumerator StopAfkMusic()
    {
        while (_audioSource.pitch > 0)
        {
            _audioSource.pitch -= _pitchSpeed * Time.deltaTime;
            yield return null;
        }
        _audioSource.Stop();
        _audioSource.pitch = 1;
    }

    private IEnumerator WaitMusicStopsPlaying()
    {
        while (_audioSource.isPlaying) {
        yield return new WaitForSeconds(1);
        }
        EndMusic.Invoke();
    }
}
