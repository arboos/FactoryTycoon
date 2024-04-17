using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float velocity;

    private CharacterController _characterController;
    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update(){
        UpdateInput();
        Move();
    }

    private void UpdateInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
    
    private void Move()
    {
        Vector3 movement = new Vector3(_horizontal, 0, _vertical);
        movement.Normalize();
        _characterController.Move(movement * Time.deltaTime * velocity);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    
}
