using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private int timeToDisable;
    
    private void OnEnable()
    {
        DisableAfterTime();
    }
    
    private async void DisableAfterTime()
    {
        await UniTask.Delay(timeToDisable);
        gameObject.SetActive(false);
    }

    public abstract void Shoot(Transform shootPos);
}
