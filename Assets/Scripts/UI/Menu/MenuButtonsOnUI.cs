using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuButtonsOnUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMeshPro;

    private void OnMouseOver()
    {
        _textMeshPro.fontStyle = FontStyles.Underline;
    }

    private void OnMouseExit()
    {
        _textMeshPro.fontStyle = FontStyles.Normal;
    }
}
