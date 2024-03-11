using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class IsActivePauseMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _pausedText;

    private void Start()
    {
        BlinkPauseText();
    }

    private void BlinkPauseText()
    {
        _pausedText.DOFade(0.3f, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
