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
    
    public override void TakeDamage(int damage)
    {
        ResourceHealth -= damage;
        damageDealed -= damage;
        particles.Play();
        
        if (ResourceHealth <= 0)
        {
            StartCoroutine(Death());
        }
        else
        {
            if (damageDealed <= 0)
            {
                damageDealed = partHP;
                parts[partsCount].SetActive(false);
                partsCount--;
            }

            StartCoroutine(AfterHit());
        }
        
        print("Metal");
    }
    
    private IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(0.05f);
        
        PlayerInventory.Instance.AddResource(resource, ResourceExtractionValue);
    }
    
    private IEnumerator Death()
    {
        selfSpawner.points.Add(selfPoint);
        selfSpawner.usedPoints.Remove(selfPoint);
        PlayerInventory.Instance.AddResource(resource, ResourceFullExtractionValue);
        
        yield return new WaitForSeconds(0.8f);

        selfSpawner.SpawnResource(10f);
        Destroy(gameObject);

    }
}
