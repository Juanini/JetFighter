using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    private float currentSpeed;
    private Rigidbody2D rb;
    
    // BOOST

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
        // Forward movement
        rb.velocity = transform.up * currentSpeed;

        // Turning
        // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        // {
        //     transform.Rotate(Vector3.forward, movementConfig.turnSpeed * Time.deltaTime);
        //     currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
        // }
        // else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        // {
        //     transform.Rotate(Vector3.forward, -movementConfig.turnSpeed * Time.deltaTime);
        //     currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
        // }
        // else
        // {
        //     // currentSpeed = Mathf.Lerp(currentSpeed, GetCurrentSpeed(), Time.deltaTime * movementConfig.recoverySpeed);
        //     currentSpeed = GetCurrentSpeed();
        // }
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