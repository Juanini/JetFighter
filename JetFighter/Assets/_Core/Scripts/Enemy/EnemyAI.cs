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

    // * =====================================================================================================================================
    // * MAIN
    
    public void Init()
    {
        behaviorType = GetInitialBehavior();
        
        player = GetComponent<Player>();
        playerTarget = LevelManager.Ins.GetPlayer1().transform;
        playerMovement = GetComponent<PlayerMovement>();
        
        isActive = true;
    }
    
    private void Update()
    {
        if (!isActive) { return; }
        
        if (behaviorType == BehaviorType.Offencive)
        {
            player.Shoot();
            FollowPlayer();
        }
        else if (behaviorType == BehaviorType.Defencive)
        {
            MoveAwayFromPlayer();
        }
    }

    public void SetActive(bool _active)
    {
        isActive = false;
    }
    
    // * =====================================================================================================================================
    // * BEHAVIORS
    
    private BehaviorType GetInitialBehavior()
    {
        return Random.Range(0, 100) < 60 ? BehaviorType.Offencive : BehaviorType.Defencive;
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

    private void MoveAwayFromPlayer()
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
    }

    public enum BehaviorType
    {
        Offencive = 0,
        Defencive
    }
}
