using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    [SerializeField] private Transform upPoint, downPoint;
    [SerializeField] private float moveUpSpeed, moveDownSpeed;
    private bool isMoveUp;
    void Update()
    {
        if (transform.position.y > upPoint.position.y)
        {
            isMoveUp = false;
        }
        else if (transform.position.y < downPoint.position.y)
        {
            isMoveUp = true;
        }
    }
    private void FixedUpdate()
    {
        if (isMoveUp)
        {
            transform.Translate(Vector3.up * moveUpSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate( - Vector3.up * moveDownSpeed * Time.fixedDeltaTime);
        }
    }
}
