using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    private float currentSpeed;
    private Rigidbody2D rb;
    
    public PlayerBoost playerBoost;

    private bool canMove;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movementConfig.forwardSpeed;
    }

    void Update()
    {
        if (!canMove) { return; }
        
        HandleMovement();
    }

    public void SetMovingState(bool _state)
    {
        canMove = _state;
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    void HandleMovement()
    {
        rb.velocity = transform.up * currentSpeed;
    }

    public float GetCurrentSpeed()
    {
        return playerBoost.IsBoosting()
            ? movementConfig.forwardSpeed * playerBoost.boostMultiplier
            : movementConfig.forwardSpeed; ;
    }
    
    public void TurnLeft()
    {
        transform.Rotate(Vector3.forward, movementConfig.turnSpeed * Time.deltaTime);
        currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
    }

    public void TurnRight()
    {
        transform.Rotate(Vector3.forward, -movementConfig.turnSpeed * Time.deltaTime);
        currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
    }

    public void StopTurning()
    {
        // currentSpeed = Mathf.Lerp(currentSpeed, movementConfig.forwardSpeed, Time.deltaTime * movementConfig.recoverySpeed);
        currentSpeed = GetCurrentSpeed();
    }
}