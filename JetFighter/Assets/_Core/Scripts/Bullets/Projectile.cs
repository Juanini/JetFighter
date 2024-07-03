using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private int timeToDisable;
    private int playerOwnerNumber;
    
    private void OnEnable()
    {
        DisableAfterTime();
    }
    
    private async void DisableAfterTime()
    {
        await UniTask.Delay(timeToDisable);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            
        }
    }

    public abstract void Shoot(Transform _shootPos);

    public void SetOwnerNumber(int _number)
    {
        playerOwnerNumber = _number;
    }
    public int GetOwnerNumber()
    {
        return playerOwnerNumber;
    }
}
