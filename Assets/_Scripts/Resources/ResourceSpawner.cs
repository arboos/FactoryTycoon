using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceSpawner : MonoBehaviour
{
    public List<Transform> points;
    public List<Transform> usedPoints;

    [SerializeField] private Transform parent;

    public int Limit;
    private int currentSpawned;
    
    public GameObject prefab;

    private void Start()
    {
        points = new List<Transform>();
        usedPoints = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            points.Add(transform.GetChild(i));
        }
        SpawnResource();
        SpawnResource();
        SpawnResource();
    }

    public void SpawnResource()
    {
        GameObject resourceSpawned = Instantiate(prefab);
        Transform positionPoint = GetRandomPoint();
        resourceSpawned.transform.position = positionPoint.position;
        resourceSpawned.GetComponent<ResourceBehaviour>().selfPoint = positionPoint;
        resourceSpawned.GetComponent<ResourceBehaviour>().selfSpawner = this;
        resourceSpawned.transform.parent = parent;
    }

    private Transform GetRandomPoint()
    {
        int randomIndex = Random.Range(0, points.Count);
        Transform returnedPoint =  points[randomIndex];
        usedPoints.Add(returnedPoint);
        points.Remove(returnedPoint);
        return returnedPoint;
    }
    
    
}
