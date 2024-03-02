using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using Unity.VisualScripting.Dependencies.NCalc;

public class MoveCameraInMainMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _virtualCameras;

    [Header("Positions For Cameras")]
    [SerializeField] private Transform _stopPosCam_1;
    [SerializeField] private Transform _stopPosCam_2;
    [SerializeField] private Transform _stopPosCam_3;
    [SerializeField] private float _duration;

    private bool isActiveCamera_1 = true;
    private bool isActiveCamera_2 = true;
    private bool isActiveCamera_3 = true;

    private void Start()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(_virtualCameras[0].transform.DOMove(_stopPosCam_1.position, _duration).SetEase(Ease.Linear).OnComplete(OnOffCamera_1));
        sequence.Append(_virtualCameras[1].transform.DOMove(_stopPosCam_2.position, _duration).SetEase(Ease.Linear).OnComplete(OnOffCamera_2));
        sequence.Append(_virtualCameras[2].transform.DOMove(_stopPosCam_3.position, _duration).SetEase(Ease.Linear).OnComplete(OnOffCamera_3).OnComplete(OnOffCamera_1));

    }
    private void OnOffCamera_1()
    {
        _virtualCameras[0].gameObject.SetActive(isActiveCamera_1 = !isActiveCamera_1);
    }
    private void OnOffCamera_2()
    {
        _virtualCameras[1].gameObject.SetActive(isActiveCamera_2 = !isActiveCamera_2);
    } 
    private void OnOffCamera_3()
    {
        _virtualCameras[2].gameObject.SetActive(isActiveCamera_3 = !isActiveCamera_3);
    }
}
