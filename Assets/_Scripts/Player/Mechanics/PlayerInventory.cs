using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    
    public List<Resource> InventoryResources;
    public List<int> InventoryCounts;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        InventoryResources = new List<Resource>();
        InventoryCounts = new List<int>();
    }

    public void AddResource(Resource resource, int count)
    {
        if (InventoryResources.Contains(resource))
        {
            for (int i = 0; i < InventoryResources.Count; i++)
            {
                if (InventoryResources[i] == resource)
                {
                    InventoryCounts[i] += count;
                }
            }
        }
        else
        {
            InventoryResources.Add(resource);
            InventoryCounts.Add(count);
        }
        
        UpdateInventory();
    }
    
    public void UpdateInventory()
    {
        
        for (int i = 0; i < UIManager.Instance.resourcesParent.childCount; i++)
        {
            Destroy(UIManager.Instance.resourcesParent.GetChild(i).gameObject);
        }

        for(int i = 0; i < InventoryResources.Count; i++)
        {
            GameObject currentInventorySlot = Instantiate(UIManager.Instance.resourcePrefab);
            currentInventorySlot.transform.SetParent(UIManager.Instance.resourcesParent);
            currentInventorySlot.transform.GetChild(0).GetComponent<Image>().sprite = InventoryResources[i].Icon;
            currentInventorySlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = InventoryCounts[i].ToString();
        }
    }
}

public enum ResourceType
{
    Wood,
    Metal
}
