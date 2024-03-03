using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class MoveCameraInMainMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _virtualCamera;
    private Transform[] _startCamerasPositions;

    [Header("Target Positions For Cameras")]
    [SerializeField] private Transform[] _targetPosition;

    [SerializeField] private float _duration;

    private int _activeCameraIndex = 1;
    private int _priorityIndex;


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
        for (int i = 1; i < virtualCamera.Length; i++)
        {
            sequence.Join(virtualCamera[i].transform.DOMove(targetPos[i].position, _duration)
                .SetEase(Ease.Linear)
                .OnComplete(NextCamera));
            sequence.Append(virtualCamera[i].transform.DOMove(startPos[i].position, 1));
            if(i == virtualCamera.Length-1)
            {
                sequence.Join(virtualCamera[i-(virtualCamera.Length-1)].transform.DOMove(targetPos[i - (virtualCamera.Length - 1)].position, _duration)
                    .SetEase(Ease.Linear)
                    .OnComplete(NextCamera));
            }
        }
        sequence.SetLoops(-1);
    }

    private void NextCamera()
    {
        _activeCameraIndex++;
        if (_activeCameraIndex == 3)
        {
            _activeCameraIndex = 0;
        }
        _priorityIndex++;
        _virtualCamera[_activeCameraIndex].Priority = _priorityIndex;
    }

    public void AddStartCamerasPositions(CinemachineVirtualCamera[] cameras)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            _startCamerasPositions[i] = cameras[i].transform;
        }
    }
}
