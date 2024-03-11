using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private CharacterController ch_controller;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _runMoveSpeed;
    [SerializeField] private float _jumpPower;

    private float _gravityForce;
    private Vector3 _moveVector;

    private bool shiftPressed = false;

    public static UnityEvent OnPlayJumpSound = new();
    public static UnityEvent OnPlayWalkSound = new();
    public static UnityEvent StopPlayWalkSound = new();

    private void Start()
    {
        PauseGame.ActivePause.AddListener(DisablePlayerControll);
    }

    private void Update()
    {
        CharecterMove();
        GamingGravity();
        Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftPressed = !shiftPressed;
        }
    }

    public float GetGravityForce() => _gravityForce;

    private void DisablePlayerControll(bool isActive)
    {
        if (isActive)
        {
            PlayerControll playerControll = this;
            playerControll.enabled = !playerControll.enabled;
        }
        else
        {
            PlayerControll playerControll = this;
            playerControll.enabled = !playerControll.enabled;
        }
    }

    private void CharecterMove()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        _moveVector = transform.right * xMove + transform.forward * zMove;
        _moveVector.y = _gravityForce;

        var speed = _speedMove;

        if (shiftPressed)
        {
            speed = _speedMove;
        }
        else
        {
            speed = _runMoveSpeed;
        }
        ch_controller.Move(_moveVector * speed * Time.deltaTime);

        if (Math.Abs(xMove) > 0.2 || Math.Abs(zMove) > 0.2)
        {
            OnPlayWalkSound.Invoke();
        }
        else
        {
            StopPlayWalkSound.Invoke();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded)
        {
            _gravityForce = _jumpPower;
            OnPlayJumpSound.Invoke();
        }
    }

    private void GamingGravity()
    {
        if (!ch_controller.isGrounded)
        {
            _gravityForce -= 9f * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1f;
        }
    }
}