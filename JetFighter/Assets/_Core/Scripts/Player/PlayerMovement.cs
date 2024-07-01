using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    private float currentSpeed;
    private Rigidbody2D rb;
    
    // 
    private ScreenLooper screenWrapper;
    
    // BOOST
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movementConfig.forwardSpeed;
        screenWrapper = FindObjectOfType<ScreenLooper>();
    }

    void Update()
    {
        HandleMovement();
        screenWrapper.WrapObject(transform);
    }

    void HandleMovement()
    {
        // Forward movement
        rb.velocity = transform.up * currentSpeed;

        // Turning
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, movementConfig.turnSpeed * Time.deltaTime);
            currentSpeed = movementConfig.forwardSpeed * movementConfig.slowDownFactor;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -movementConfig.turnSpeed * Time.deltaTime);
            currentSpeed = movementConfig.forwardSpeed * movementConfig.slowDownFactor;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, movementConfig.forwardSpeed, Time.deltaTime * movementConfig.recoverySpeed);
        }
    }
}