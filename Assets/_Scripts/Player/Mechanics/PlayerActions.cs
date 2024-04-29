using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public static PlayerActions Instance { get; private set; }

    public ResourceData CurrentResource;
    
    private float timeToHit;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (CurrentResource != null)
        {
            if (PlayerInput.Instance.Horizontal <= 0.05 && PlayerInput.Instance.Vertical <= 0.05)
            {
                Extract();
            }
        }
    }

    public void Extract()
    {
        timeToHit -= Time.deltaTime;
        if (timeToHit <= 0)
        {
            switch (CurrentResource.Type)
            {
                Pl
            }
        }
    }
}
