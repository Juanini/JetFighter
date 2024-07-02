using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement planeMovement;
    private PlayerBoost playerBoost;
    private Attack attack;

    void Start()
    {
        planeMovement = GetComponent<PlayerMovement>();
        playerBoost = GetComponent<PlayerBoost>();
        attack = GetComponent<Attack>();

        turnLeftKey = KeyCode.LeftArrow;
    }

    private KeyCode turnLeftKey;

    void Update()
    {
        HandleMovementInput();
        HandleBoostInput();
        HandleAttackInput();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            planeMovement.TurnLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            planeMovement.TurnRight();
        }
        else
        {
            planeMovement.StopTurning();
        }
    }

    void HandleBoostInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerBoost.PerformBoost().Forget();
        }
    }

    void HandleAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack.Shoot();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            attack.StopShooting();
        }
    }
}
