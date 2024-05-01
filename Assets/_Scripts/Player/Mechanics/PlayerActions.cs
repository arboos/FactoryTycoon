using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public static PlayerActions Instance { get; private set; }

    public ResourceBehaviour CurrentResource;


    [SerializeField] private int Damage;
    [SerializeField] private float timeToHit;
    
    private float currentTimeToHit;
    
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
        currentTimeToHit -= Time.deltaTime;
        if (currentTimeToHit <= 0)
        {
            currentTimeToHit = timeToHit;
            CurrentResource.TakeDamage(Damage);
        }
    }
}
