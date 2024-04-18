using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontal = PlayerInput.Instance.Horizontal;
        _vertical = PlayerInput.Instance.Vertical;

        if ((_horizontal >= 0.1f || _horizontal <= -0.1f) || (_vertical >= 0.1f || _vertical <= -0.1f))
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}
