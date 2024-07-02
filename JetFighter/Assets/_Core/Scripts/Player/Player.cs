using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Weapon activeWeapon;
    [SerializeField] public Transform shootPos;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        SetInitialWeapon();
    }

    private void SetInitialWeapon()
    {
        activeWeapon = WeaponsManager.Ins.GetStartingWeapon();
        activeWeapon.SetOwner(this);
    }
}
