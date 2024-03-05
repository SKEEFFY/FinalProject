using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ReleaseMenuText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;

    private void Start()
    {
        ReleaseMenu();
    }

    private void ReleaseMenu()
    {
        foreach (var text in _texts)
        {
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1);
            text.fontMaterial.DOFloat(0, ShaderUtilities.ID_FaceDilate, 3f);
        }
    }
}
