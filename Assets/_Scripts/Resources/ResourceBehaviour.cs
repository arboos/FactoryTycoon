using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBehaviour : MonoBehaviour
{
    public Resource resource;
    
    public int ResourceHealth;
    [SerializeField] protected int ResourceExtractionValue;
    [SerializeField] protected int ResourceFullExtractionValue;
    
    [SerializeField] protected ParticleSystem particles;
    [SerializeField] protected AudioSource sound;

    protected int partsCount;
    protected int damageDealed;

    public Transform selfPoint;
    public ResourceSpawner selfSpawner;

    public virtual void TakeDamage(int damage)
    {
        ResourceHealth -= damage;
        damageDealed -= damage;
        particles.Play();

        PlayerInventory.Instance.AddResource(resource, ResourceExtractionValue);

        if (ResourceHealth <= 0)
        {
            PlayerInventory.Instance.AddResource(resource, ResourceFullExtractionValue);
            PlayerActions.Instance.CurrentResource = null;
            Destroy(gameObject);
        }

        print("Base");
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
