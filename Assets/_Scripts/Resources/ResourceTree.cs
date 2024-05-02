using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTree : ResourceBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        ResourceHealth -= damage;
        damageDealed -= damage;
        
        PlayerInventory.Instance.AddResource(resource, ResourceExtractionValue);
        
        if (ResourceHealth <= 0)
        {
            PlayerInventory.Instance.AddResource(resource, ResourceFullExtractionValue);
            PlayerActions.Instance.CurrentResource = null;
            
            StartCoroutine(Death());
        }
        else
        {
            StartCoroutine(AfterHit());
        }
        print("Tree");
    }

    private IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(0.6f);
        _animator.SetTrigger("Hit");
    }
    
    private IEnumerator Death()
    {
        _animator.SetTrigger("Die");
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);

    }
}
