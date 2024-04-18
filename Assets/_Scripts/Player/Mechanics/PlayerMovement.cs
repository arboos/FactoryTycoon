using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //Move
        Vector3 movement = new Vector3(PlayerInput.Instance.Horizontal, 0, PlayerInput.Instance.Vertical);
        movement.Normalize();
        _characterController.Move(movement * Time.deltaTime * PlayerInfo.Instance.Speed);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        
        //Look
        Vector3 lookTo = new Vector3(transform.position.x + PlayerInput.Instance.Horizontal, transform.position.y, 
            transform.position.z + PlayerInput.Instance.Vertical);
        transform.LookAt(lookTo);
    }
}
