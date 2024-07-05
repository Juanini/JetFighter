using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalProjectile : Projectile
{
    [SerializeField] private float speed;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Shoot(Transform _shootPos)
    {
        Trace.Log("SHOOT");
        
        transform.position = _shootPos.position;
        transform.rotation = _shootPos.rotation;
        
        if (rb != null)
        {
            rb.velocity = _shootPos.up * speed;
        }
    }
}
