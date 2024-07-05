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

    [Header("ELEMENTS")] 
    public SpriteRenderer playerSprite;
    
    [Header("COMPONENTS")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerBoost playerBoost;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private ScreenLooper screenLooper;
    [SerializeField] private EnemyAI enemyAI;

    [Header("EVENTS")] [SerializeField]
    private ScriptableEventPlayer onShipDestoyed;
    private ScriptableEventPlayer onMatchStart;

    private float health;
    public float Health => health;

    private int playerNumber;
    public int PlayerNumber => playerNumber;

    private PlayerVariable playerVariable;
    private int score;
    public int Score
    {
        get => score;
        set => score = value;
    }

    private void Start()
    {
        Init();
    }

    public void Setup(int _playerNumber, PlayerVariable _playerVariable, ShipSO _shipSo)
    {
        shipSO = _shipSo;
        playerVariable = _playerVariable;
        
        playerNumber = _playerNumber;
        playerInput.Setup(this);

        playerSprite.sprite = shipSO.shipSprite;
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
        playerInput.BlockInput(false);
        playerMovement.SetMovingState(true);
        SetScreenLooperActive(true);
        
        enemyAI?.Init();
    }
    
    public void PrepareForNextMatch()
    {
        transform.position = PositionReferences.Ins.playersExitPositions[playerNumber].position;
        
        playerInput.BlockInput(true);
        
        playerBoost.Init();
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

    public int GetBoostAmount()
    {
        return (int)playerBoost.GetBoostBar();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag(GameDefs.TAG_PROJECTILE))
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
