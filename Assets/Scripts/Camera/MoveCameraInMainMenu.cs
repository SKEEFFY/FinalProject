using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System;

public class MoveCameraInMainMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _virtualCameras;
    private Transform[] _startCamerasPositions;

    [Header("Stop Positions For Cameras")]
    [SerializeField] private Transform _stopPosCam_1;
    [SerializeField] private Transform _stopPosCam_2;
    [SerializeField] private Transform _stopPosCam_3;
    [SerializeField] private float _duration;

    private bool[] _isCameraActive = new[] { true, true, true };

    private int _activeCameraNumber;

    private void Awake()
    {
        
        
    }

    private void Start()
    {
        _startCamerasPositions = new Transform[_virtualCameras.Length];
        AddStartCamerasPositions(_virtualCameras);

        Debug.Log("  +" + Convert.ToString(_virtualCameras[_activeCameraNumber].transform.position.x));
        var sequence = DOTween.Sequence();

        sequence.Append(_virtualCameras[0].transform.DOMove(_stopPosCam_1.position, _duration).SetEase(Ease.Linear).OnComplete(NextCamera));
        sequence.Append(_virtualCameras[1].transform.DOMove(_stopPosCam_2.position, _duration).SetEase(Ease.Linear).OnComplete(NextCamera));
        sequence.Append(_virtualCameras[2].transform.DOMove(_stopPosCam_3.position, _duration).SetEase(Ease.Linear).OnComplete(NextCamera).OnKill(NextCamera));
        
    }

    public void UPD()
    {
        _virtualCameras[0].transform.position = _startCamerasPositions[0].position;
        _virtualCameras[0].transform.SetPositionAndRotation(_startCamerasPositions[0].position, _startCamerasPositions[0].rotation);
        Debug.Log("  +" + Convert.ToString(_virtualCameras[0].transform.position.x));
    }

    private void NextCamera()
    {
        if(_activeCameraNumber == 2)
        {
            _activeCameraNumber = 0;
        }
        _virtualCameras[_activeCameraNumber].gameObject.SetActive(_isCameraActive[_activeCameraNumber] = !_isCameraActive[_activeCameraNumber]);
        _virtualCameras[_activeCameraNumber].transform.SetPositionAndRotation(_startCamerasPositions[_activeCameraNumber].position, _startCamerasPositions[_activeCameraNumber].rotation);
        _activeCameraNumber++;
        
    }

    public void AddStartCamerasPositions(CinemachineVirtualCamera[] cameras)
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            _startCamerasPositions[i] = cameras[i].transform;
        }
    }
}
