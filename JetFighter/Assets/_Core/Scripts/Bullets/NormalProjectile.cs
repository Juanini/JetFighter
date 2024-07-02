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
        transform.position = _shootPos.position;
        transform.rotation = _shootPos.rotation;
        
        if (rb != null)
        {
            Debug.Log("Achis 2");
            Debug.Log("_shootPos.forward * speed: " + _shootPos.forward * speed);
            
            rb.velocity = _shootPos.up * speed;
        }
    }
}
