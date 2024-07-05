using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTarget;
    
    private Player player;
    private PlayerMovement playerMovement;
    private PlayerBoost playerBoost;
    
    private bool isActive;
    
    private BehaviorType behaviorType;
    
    private float behaviorChangeCheckTime = 1.5f;
    public int offenciveBehaviorPercentChance = 40;
    public int healthToChangeToDefencive = 30;
    public int shootChance = 10;
    
    // * =====================================================================================================================================
    // * MAIN
    
    public void Init()
    {
        behaviorType = GetInitialBehavior();
        
        player = GetComponent<Player>();
        playerTarget = LevelManager.Ins.GetPlayer1().transform;
        playerMovement = GetComponent<PlayerMovement>();
        
        SetActive(true);
    }

    private void CheckBehaviorChangeOverTime()
    {
        CheckBehavior();
        if (behaviorType == BehaviorType.Defencive)
        {
            PerformDefensiveMovement(moveAwayTurnDuration).Forget();
        }
    }

    private void CheckBehavior()
    {
        if (player.GetCurrentHealth() < healthToChangeToDefencive)
        {
            behaviorType = BehaviorType.Defencive;
            return;
        }
        
        if (Random.Range(0, 100) < 30)
        {
            behaviorType = GetRandomBehavior();
            return;
        }
    }
    
    private void Update()
    {
        if (!isActive) { return; }
        
        if (behaviorType == BehaviorType.Offencive)
        {
            TryToShoot();
            FollowPlayer();
        }
    }

    private bool canShoot = true;
    
    private void TryToShoot()
    {
        if (!canShoot) { return; }
        canShoot = false;
        
        ResetShoot().Forget();
        
        if (Random.Range(0, 100) < shootChance)
        {
            player.Shoot();
        }
    }

    private async UniTask ResetShoot()
    {
        await UniTask.Delay(500);
        canShoot = true;
    }

    public void SetActive(bool _active)
    {
        isActive = _active;
        canShoot = isActive;

        if (isActive)
        {
            InvokeRepeating(nameof(CheckBehaviorChangeOverTime), 0, behaviorChangeCheckTime);
        }
        else
        {
            CancelInvoke(nameof(CheckBehaviorChangeOverTime));
        }
    }
    
    // * =====================================================================================================================================
    // * BEHAVIORS
    
    private BehaviorType GetInitialBehavior()
    {
        return GetRandomBehavior();
    }

    private BehaviorType GetRandomBehavior()
    {
        return Random.Range(0, 100) < offenciveBehaviorPercentChance ? BehaviorType.Offencive : BehaviorType.Defencive;
    }
    
    // * =====================================================================================================================================
    // * MOVEMENT

    private void FollowPlayer()
    {
        Vector3 directionToPlayer = playerTarget.position - transform.position;
        float angleToPlayer = Vector3.SignedAngle(transform.up, directionToPlayer, Vector3.forward);

        if (angleToPlayer > 0)
        {
            playerMovement.TurnLeft();
        }
        else if (angleToPlayer < 0)
        {
            playerMovement.TurnRight();
        }
    }
    
    public float moveAwayTurnDuration = 0.5f;
    
    private async void MoveAwayFromPlayer()
    {
        Vector3 directionToPlayer = playerTarget.position - transform.position;
        float angleToPlayer = Vector3.SignedAngle(transform.up, directionToPlayer, Vector3.forward);
        
        if (angleToPlayer > 0)
        {
            playerMovement.TurnRight();
        }
        else if (angleToPlayer < 0)
        {
            playerMovement.TurnLeft();
        }
        
        await UniTask.Delay(TimeSpan.FromSeconds(moveAwayTurnDuration));
        playerMovement.StopTurning();
    }
    
    private async UniTaskVoid PerformDefensiveMovement(float duration)
    {
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            MoveAwayFromPlayer();
            await UniTask.Yield(); 
        }
        
        playerMovement.StopTurning();
    }

    public enum BehaviorType
    {
        Offencive = 0,
        Defencive
    }
}
