using UnityEngine;
using UnityEngine.UI;

public class CompassCardinalDirections : MonoBehaviour
{
    [SerializeField] private RawImage _compassImage;
    [SerializeField] private Transform _player;

    private void Update()
    {
        _compassImage.uvRect = new Rect(_player.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
