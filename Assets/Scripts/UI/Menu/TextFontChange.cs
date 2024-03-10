using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextFontChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected TMP_Text _TMP_ProText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _TMP_ProText.fontStyle = FontStyles.SmallCaps;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _TMP_ProText.fontStyle = FontStyles.Normal;
    }
}
