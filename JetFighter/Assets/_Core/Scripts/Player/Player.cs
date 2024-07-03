using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Weapon activeWeapon;
    [SerializeField] public Transform shootPos;

    [SerializeField] private ShipSO shipSO;

    public GameObject uiPos;

    private float health;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        health = shipSO.maxHealth;
        SetInitialWeapon();
    }

    private void SetInitialWeapon()
    {
        activeWeapon = WeaponsManager.Ins.GetStartingWeapon();
        activeWeapon.SetOwner(this);
    }

    public Sprite GetShipSprite()
    {
        return shipSO.shipSprite;
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public float GetBoostAmount()
    {
        return 0;
    }
}
