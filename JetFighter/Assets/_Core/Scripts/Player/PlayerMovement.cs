using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    private float currentSpeed;
    private Rigidbody2D rb;
    
    public PlayerBoost playerBoost;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movementConfig.forwardSpeed;
    }

    void Update()
    {
        HandleMovement();
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
        // transform.Rotate(Vector3.forward, movementConfig.turnSpeed * Time.deltaTime);
        // currentSpeed = movementConfig.forwardSpeed * movementConfig.slowDownFactor;
        
        transform.Rotate(Vector3.forward, movementConfig.turnSpeed * Time.deltaTime);
        currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
    }

    public void TurnRight()
    {
        // transform.Rotate(Vector3.forward, -movementConfig.turnSpeed * Time.deltaTime);
        // currentSpeed = movementConfig.forwardSpeed * movementConfig.slowDownFactor;
        
        transform.Rotate(Vector3.forward, -movementConfig.turnSpeed * Time.deltaTime);
        currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
    }

    public void StopTurning()
    {
        // currentSpeed = Mathf.Lerp(currentSpeed, movementConfig.forwardSpeed, Time.deltaTime * movementConfig.recoverySpeed);
        currentSpeed = GetCurrentSpeed();
    }

        
}