using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private PlayerMass _playerMass;
    [SerializeField] private CharacterController ch_controller;
    [SerializeField] private float _speedMove = 7f;
    [SerializeField] private float _runMoveSpeed = 15f;
    [SerializeField] private float _jumpPower = 10f;
    
    private Vector3 _moveVector;
    private bool shiftPressed = false;

    public static UnityEvent OnPlayJumpSound = new();
    public static UnityEvent OnPlayWalkSound = new();
    public static UnityEvent StopPlayWalkSound = new();

    private void Update()
    {
        CharecterMove();
        Jump();
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftPressed = !shiftPressed;
        }
    }

    private void CharecterMove()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        _moveVector = transform.right * xMove + transform.forward * zMove;
        _moveVector.y = _playerMass.GravityForce;

        var speed = _speedMove;

        if(shiftPressed)
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
            _playerMass.GravityForce = _jumpPower;

            OnPlayJumpSound.Invoke();
        }
    }
}