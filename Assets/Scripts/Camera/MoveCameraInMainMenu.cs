using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class MoveCameraInMainMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _virtualCamera;
    private Transform[] _startCamerasPositions;

    [Header("Target Positions For Cameras")]
    [SerializeField] private Transform[] _targetPosition;

    [SerializeField] private float _duration;

    private bool[] _isCameraActive = new[] { true, true, true };
    private int _activeCameraNumber;


    private void Awake()
    {
        _startCamerasPositions = new Transform[_virtualCamera.Length];
        AddStartCamerasPositions(_virtualCamera);
    }

    private void Start()
    {
        MoveCameras(_virtualCamera, _startCamerasPositions, _targetPosition);
    }

    private void MoveCameras(CinemachineVirtualCamera[] virtualCamera, Transform[] startPos, Transform[] targetPos)
    {
        var sequence = DOTween.Sequence();
        for (int i = 0; i < virtualCamera.Length; i++)
        {
            sequence.Join(virtualCamera[i].transform.DOMove(targetPos[i].position, _duration).SetEase(Ease.Linear).OnComplete(NextCamera));
            sequence.Append(virtualCamera[i].transform.DOMove(startPos[i].position, 1));
        }
    }

    private void NextCamera()
    {
        if (_activeCameraNumber == 3)
        {
            _activeCameraNumber = 0;
        }
        _virtualCamera[_activeCameraNumber].gameObject.SetActive(_isCameraActive[_activeCameraNumber] = !_isCameraActive[_activeCameraNumber]);
        _virtualCamera[0].transform.SetPositionAndRotation(_startCamerasPositions[0].position, _startCamerasPositions[0].rotation);
        _activeCameraNumber++;

    }

    public void AddStartCamerasPositions(CinemachineVirtualCamera[] cameras)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            _startCamerasPositions[i] = cameras[i].transform;
        }
    }
}
