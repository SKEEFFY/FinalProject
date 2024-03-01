using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconOnCompas : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private RawImage _imageOnCompassWidth;
    [SerializeField] private GameObject imagePrefab;
    [SerializeField] private float _maxViewDistance_Transparent = 50f;
    [SerializeField] private float _maxViewDistance_SizeIcon = 150f;

    private List<Image> Marker = new List<Image>();
    private List<Vector2> MarkerPosition = new List<Vector2>();
    private float _compassUnit;

    private void Awake()
    {
        ImageOnObject.SetSpriteOnCompass.AddListener(AddMarker);
    }

    private void Start()
    {
        _compassUnit = _imageOnCompassWidth.rectTransform.rect.width / 360f;
    }

    private void Update()
    {
        _imageOnCompassWidth.uvRect = new Rect(_player.localEulerAngles.y / 360f, 0f, 1f, 1f);
        for (int i = 0; i < Marker.Count; i++)
        {
            Marker[i].rectTransform.anchoredPosition = GetPosOnCompas(i);

            float dst = Vector2.Distance(new Vector2(_player.transform.position.x, _player.transform.position.z), MarkerPosition[i]);
            float scale = 0f;

            if (dst < _maxViewDistance_SizeIcon)
            {
                scale = 1f - (dst / _maxViewDistance_SizeIcon);
            }
            Marker[i].rectTransform.localScale = Vector3.one * scale;
            Color tempColor = Marker[i].color;
            tempColor.a = GetDistanceToItem(i);
            Marker[i].color = tempColor;
        }
    }

    private void AddMarker(Sprite sprite, Vector2 vector)
    {
        GameObject imgObject = Instantiate(imagePrefab, _imageOnCompassWidth.transform);
        Image img = imgObject.GetComponent<Image>();
        img.sprite = sprite;
        img.rectTransform.sizeDelta = new Vector2(40, 40);
        Marker.Add(img);
        MarkerPosition.Add(vector);
    }

    private Vector2 GetPosOnCompas(int markerElemnt)
    {
        Vector2 playerPos = new Vector2(_player.transform.position.x, _player.transform.position.z);
        Vector2 playerFwd = new Vector2(_player.transform.forward.x, _player.transform.forward.z);
        float angle = Vector2.SignedAngle(MarkerPosition[markerElemnt] - playerPos, playerFwd);
        return new Vector2(_compassUnit * angle, 0f);
    }

    private float GetDistanceToItem(int markerElement) 
    {
        return 1 - Vector2.Distance(_player.position, MarkerPosition[markerElement]) / _maxViewDistance_Transparent;
    }
}
