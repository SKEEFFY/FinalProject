using UnityEngine;
using UnityEngine.Events;

public class ImageOnObject : MonoBehaviour
{
    [SerializeField] private Sprite _iconImage;
    [SerializeField] private Transform _positionOnScene;

    public static UnityEvent<Sprite, Vector2> SetSpriteOnCompass = new UnityEvent<Sprite, Vector2>();


    private void Start()
    {
        CreateEvent();
    }

    private void CreateEvent()
    {
        Vector2 vctr = new Vector2(_positionOnScene.transform.position.x, _positionOnScene.transform.position.z);
        SetSpriteOnCompass?.Invoke(_iconImage, vctr);
    }
}
