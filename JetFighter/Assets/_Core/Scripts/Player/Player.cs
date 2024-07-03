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

    [Header("COMPONENTS")] [SerializeField]
    private PlayerInput playerInput;

    private float health;
    private int playerNumber;
    public int PlayerNumber => playerNumber;

    private void Start()
    {
        Init();
    }

    public void Setup(int _playerNumber)
    {
        playerNumber = _playerNumber;
        playerInput.Setup(this);
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

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Projectile"))
        {
            var projectile = _other.GetComponent<Projectile>();
            if (projectile.GetOwnerNumber() == playerNumber)
            {
                return;
            }
            
            Damage();
        }
    }

    // * =====================================================================================================================================
    // * 
    
    private void Damage()
    {
        health -= 10;
    }
}
