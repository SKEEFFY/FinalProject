using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 300f;
    [SerializeField] private Transform _playerBody;
    private float _xRotation = 0f;

    private void Start()
    {
        PauseGame.ActivePause.AddListener(UnlockCursor);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);

    }
    
    private void UnlockCursor(bool isActive)
    {
        if(!isActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}


