using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }
    
    [SerializeField] private FloatingJoystick _joystick;
    
    public float Horizontal;
    public float Vertical;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void Update(){
        UpdateInput();
    }

    private void UpdateInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal <= 0.2f && Horizontal >= -0.2f) Horizontal = _joystick.Horizontal;
        if (Vertical <= 0.2f && Vertical >= -0.2f) Vertical = _joystick.Vertical;
    }
    

    
}
