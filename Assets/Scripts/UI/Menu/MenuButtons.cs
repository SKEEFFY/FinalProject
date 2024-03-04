using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text _startText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _startText.fontStyle = FontStyles.SmallCaps;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _startText.fontStyle = FontStyles.Normal;
    }
}
