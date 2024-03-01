using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class ControlPlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int HorizontalInput = Animator.StringToHash("HorizontalInput");
    private static readonly int VerticalInput = Animator.StringToHash("VerticalInput");
    private static readonly int JumpInput = Animator.StringToHash("Jump");

    private void Update()
    {
        _animator.SetFloat(HorizontalInput, Input.GetAxis("Horizontal"));
        _animator.SetFloat(VerticalInput, Input.GetAxis("Vertical"));
        _animator.SetInteger(JumpInput, (int)Input.GetAxis("Jump"));
    }
}