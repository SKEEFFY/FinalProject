using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _walkSound;

    [SerializeField] private float _speedMove = 7f;
    [SerializeField] private float _runMoveSpeed = 15f;
    [SerializeField] private float _jumpPower = 10f;
    

    private float _gravityForce;
    private Vector3 _moveVector;

    [SerializeField] private CharacterController ch_controller;

    private bool shiftPressed = false;

    private void Update()
    {
        CharecterMove();
        GamingGravity();
        Jump();
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftPressed = !shiftPressed;
        }
    }

    public float GetGravityForce() => _gravityForce;

    private void CharecterMove()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        _moveVector = transform.right * xMove + transform.forward * zMove;
        _moveVector.y = _gravityForce;

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
            if (!_walkSound.isPlaying) 
            {
                _walkSound.Play(); 
            }
        }
        else
        {
            if (_walkSound.isPlaying) 
            {
                _walkSound.Stop(); 
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded)
        {
            _gravityForce = _jumpPower;

            _jumpSound.Play();
        }
    }

    private void GamingGravity()
    {
        if(!ch_controller.isGrounded)
        {
            _gravityForce -= 9f * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1f;
        }
    }
}