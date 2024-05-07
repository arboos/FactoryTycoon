using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTree : ResourceBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        sound = GameObject.Find("Audio_Tree").GetComponent<AudioSource>();
    }

    public override void TakeDamage(int damage)
    {
        ResourceHealth -= damage;
        damageDealed -= damage;
        
        if (ResourceHealth <= 0)
        {
            PlayerActions.Instance.CurrentResource = null;
            
            StartCoroutine(Death());
        }
        else
        {
            StartCoroutine(AfterHit());
        }
    }

    private IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(0.5f);
        
        _animator.SetTrigger("Hit");
        PlayerInventory.Instance.AddResource(resource, ResourceExtractionValue);
    }
    
    private IEnumerator Death()
    {
        selfSpawner.points.Add(selfPoint);
        selfSpawner.usedPoints.Remove(selfPoint);
        _animator.SetTrigger("Die");
        PlayerInventory.Instance.AddResource(resource, ResourceFullExtractionValue);
        
        yield return new WaitForSeconds(0.8f);

        selfSpawner.SpawnResource(10f);
        Destroy(gameObject);

    }
}
