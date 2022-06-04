using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform currentTarget;
    private Vector3 startPoint;
    private Camera myCamera;

    private void Awake()
    {
        startPoint = transform.position;
        myCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (currentTarget != null)
        {
            SetMove();
        }
    }

    private void SetMove()
    {
        if (currentTarget.position.x > transform.position.x && !PlayerLaunch.canDrag)
        {
            Vector3 newPosition = new Vector3(currentTarget.position.x,
                                              transform.position.y,
                                              transform.position.z);
            
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        }
    }
}
