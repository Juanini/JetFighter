using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    private float currentSpeed;
    private Rigidbody2D rb;
    
    // 
    
    private ScreenLooper screenLooper;
    
    // BOOST

    public PlayerBoost playerBoost;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movementConfig.forwardSpeed;
        screenLooper = FindObjectOfType<ScreenLooper>();
    }

    void Update()
    {
        HandleMovement();
        screenLooper.WrapObject(transform);
    }

    void HandleMovement()
    {
        // Forward movement
        rb.velocity = transform.up * currentSpeed;

        // Turning
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, movementConfig.turnSpeed * Time.deltaTime);
            currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -movementConfig.turnSpeed * Time.deltaTime);
            currentSpeed = GetCurrentSpeed() * movementConfig.slowDownFactor;
        }
        else
        {
            // currentSpeed = Mathf.Lerp(currentSpeed, GetCurrentSpeed(), Time.deltaTime * movementConfig.recoverySpeed);
            currentSpeed = GetCurrentSpeed();
        }
    }

    public float GetCurrentSpeed()
    {
        return playerBoost.IsBoosting()
            ? movementConfig.forwardSpeed * playerBoost.boostMultiplier
            : movementConfig.forwardSpeed; ;
    }
        
}