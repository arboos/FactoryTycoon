using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpSpeed;

    public bool follow;

    private Vector3 offset;

    private Camera camera;
    private CinemachineVirtualCamera virtualCam;

    private void Start()
    {
        camera = GetComponent<Camera>();
        
        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (follow)
        {
            transform.position = Vector3.Lerp(transform.position, offset + target.position, lerpSpeed * Time.deltaTime);
        }
    }

}
