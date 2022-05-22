using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObject : MonoBehaviour
{
    [SerializeField] private int health;
    private Transform spawnPoint;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Damage(int value)
    {
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        rb2d.isKinematic = true;
        transform.position = spawnPoint.position;
        health -= value;
        if (health <= 0)
        {
            Debug.Log("I Dead!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && spawnPoint != null)
        {
            Damage(other.GetComponent<ObstacleSetting>().damageValue);
        }
    }

    void Update()
    {
        
    }
}
