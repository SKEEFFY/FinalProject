using UnityEngine;

public class SoundsOnPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _walkSound;

    private void Start()
    {
        PlayerControll.OnPlayJumpSound.AddListener(PlayJumpSound);
        PlayerControll.OnPlayWalkSound.AddListener(PlayWalkSound);
        PlayerControll.StopPlayWalkSound.AddListener(StopPlayWalkSound);
    }

    private void PlayJumpSound()
    {
        _jumpSound.Play();
    }

    private void PlayWalkSound()
    {
        if (!_walkSound.isPlaying)
        {
            _walkSound.Play();
        }
    }

    private void StopPlayWalkSound()
    {
        if (_walkSound.isPlaying)
        {
            _walkSound.Stop();
        }
    }
}
