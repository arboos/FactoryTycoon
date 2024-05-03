using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public static PlayerCollection Instance { get; private set; }

    public GameObject Axe;
    public GameObject Pickaxe;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void DisableTools()
    {
        Axe.SetActive(false);
        Pickaxe.SetActive(false);
    }
    
    
}
