using UnityEngine;

public class SoundsOnPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _walkSound;

    private void Start()
    {
        PauseGame.ActivePause.AddListener(StopPlayWalkSound);
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
    private void StopPlayWalkSound(bool isActive)
    {
        _walkSound.Stop();
    }
}
