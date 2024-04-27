using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(ResourceHealth))]
public class ResourceData : MonoBehaviour
{
    public ResourceType Type;

    private ResourceHealth _resourceHealth;

    private void Start()
    {
        _resourceHealth = GetComponent<ResourceHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerActions.Instance.CurrentResource = this;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerActions.Instance.CurrentResource = null;
        }
    }
}

public enum ResourceType
{
    Tree,
    Metal,
    None
}