using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.Serialization;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTarget;
    public float detectionRange = 10f;
    public float shootingRange = 8f;
    public float dodgeChance = 0.3f; // 30% chance to dodge
    public float boostChance = 0.1f; // 10% chance to boost
    public float dodgeCooldown = 5f;
    public float boostCooldown = 10f;

    private Player player;
    private PlayerMovement playerMovement;
    private PlayerBoost playerBoost;
    private CancellationTokenSource cancellationTokenSource;
    
    public void Init()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerBoost = GetComponent<PlayerBoost>();
        cancellationTokenSource = new CancellationTokenSource();
        StartAI(cancellationTokenSource.Token).Forget();
    }

    private async UniTaskVoid StartAI(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);
            if (distanceToPlayer <= detectionRange)
            {
                if (distanceToPlayer <= shootingRange)
                {
                    bool shouldDodge = Random.value < dodgeChance;
                    bool shouldBoost = Random.value < boostChance;

                    if (shouldDodge)
                    {
                        Dodge().Forget();
                        await UniTask.Delay((int)(dodgeCooldown * 1000), cancellationToken: token);
                    }

                    if (shouldBoost)
                    {
                        playerBoost.PerformBoost().Forget();
                        await UniTask.Delay((int)(boostCooldown * 1000), cancellationToken: token);
                    }

                    player.Shoot();
                }
                else
                {
                    // attack.StopShooting();
                }

                FollowPlayer();
            }
            else
            {
                // attack.StopShooting();
                playerMovement.StopTurning();
            }

            await UniTask.Yield();
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = (playerTarget.position - transform.position).normalized;
        float angle = Vector2.SignedAngle(transform.up, direction);

        if (angle > 5f)
        {
            playerMovement.TurnRight();
        }
        else if (angle < -5f)
        {
            playerMovement.TurnLeft();
        }
        else
        {
            playerMovement.StopTurning();
        }
    }

    private async UniTaskVoid Dodge()
    {
        Vector2 dodgeDirection = (Vector2)transform.right * (Random.value < 0.5f ? -1 : 1);
        Vector2 dodgeTarget = (Vector2)transform.position + dodgeDirection * 2f; // Move 2 units left or right

        while (Vector2.Distance(transform.position, dodgeTarget) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, dodgeTarget, playerMovement.movementConfig.forwardSpeed * Time.deltaTime);
            await UniTask.Yield();
        }
    }
}
