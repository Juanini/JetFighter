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

    [Header("COMPONENTS")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private ScreenLooper screenLooper;

    [Header("EVENTS")] [SerializeField]
    private ScriptableEventPlayer onShipDestoyed;
    private ScriptableEventPlayer onMatchStart;

    private float health;
    public float Health => health;

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
        SetHealthToMax();
        SetInitialWeapon();
    }

    public void Shoot()
    {
        activeWeapon.TryShoot();
    }
    
    private void SetHealthToMax()
    {
        health = shipSO.maxHealth;
    }

    private void SetInitialWeapon()
    {
        activeWeapon = WeaponsManager.Ins.GetStartingWeapon();
        activeWeapon.SetOwner(this);
    }

    public void SetReadyForMatch()
    {
        playerMovement.SetMovingState(true);
        SetScreenLooperActive(true);
    }
    
    public void PrepareForNextMatch()
    {
        transform.position = PositionReferences.Ins.playersExitPositions[playerNumber].position;
        
        playerMovement.SetMovingState(false);
        playerMovement.Stop();
        
        SetRotation(playerNumber == 0 ? 0 : -180);
        
        SetScreenLooperActive(false);
        SetHealthToMax();
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
            
            projectile.HandleHit();
            Damage();
        }
    }
    
    // * =====================================================================================================================================
    // * 

    public void SetRotation(float _valuer)
    {
        transform.Rotate(new Vector3(0, 0, _valuer));
    }

    public void SetScreenLooperActive(bool _active)
    {
        screenLooper.enabled = _active;
    }

    // * =====================================================================================================================================
    // * 
    
    private void Damage()
    {
        if (health <= 0) { return; }
        
        health -= 10;

        if (health <= 0)
        {
            onShipDestoyed.Raise(this);
        }
    }
}
