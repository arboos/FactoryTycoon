using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMetal : ResourceBehaviour
{
    
    [SerializeField] protected GameObject[] parts;
    [SerializeField] protected int partHP;
    
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
        if (damageDealed <= 0)
        {
            damageDealed = partHP;
            parts[partsCount].SetActive(false);
            partsCount--;
        }

        if (ResourceHealth <= 0)
        {
            PlayerInventory.Instance.AddResource(resource, ResourceFullExtractionValue);
            PlayerActions.Instance.CurrentResource = null;
            Destroy(gameObject);
        }
        
        print("Metal");
    }
}
