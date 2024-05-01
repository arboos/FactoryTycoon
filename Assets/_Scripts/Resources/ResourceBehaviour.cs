using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBehaviour : MonoBehaviour
{
    public Resource resource;
    
    public int ResourceHealth;
    [SerializeField] private int ResourceExtractionValue;
    [SerializeField] private int ResourceFullExtractionValue;
    
    [SerializeField] private bool hasParts;
    [SerializeField] private GameObject[] parts;
    [SerializeField] private int partHP;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource sound;

    private int partsCount;
    private int damageDealed;

    private void Start()
    {
        damageDealed = partHP;
        partsCount = parts.Length - 1;
    }

    public void TakeDamage(int damage)
    {
        ResourceHealth -= damage;
        damageDealed -= damage;
        particles.Play();

        PlayerInventory.Instance.AddResource(resource, ResourceExtractionValue);
        
        if (hasParts)
        {
            if (damageDealed <= 0)
            {
                damageDealed = partHP;
                parts[partsCount].SetActive(false);
                partsCount--;
            }
        }

        if (ResourceHealth <= 0)
        {
            PlayerInventory.Instance.AddResource(resource, ResourceFullExtractionValue);
            PlayerActions.Instance.CurrentResource = null;
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerActions.Instance.CurrentResource = this;
    }
    
    private void OnTriggerExit(Collider other)
    {
        PlayerActions.Instance.CurrentResource = null;
    }
}
