using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    
    private PlayerMovement planeMovement;
    private PlayerBoost playerBoost;

    void Start()
    {
        player = GetComponent<Player>();
        
        planeMovement = GetComponent<PlayerMovement>();
        playerBoost = GetComponent<PlayerBoost>();

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
            player.activeWeapon.TryShoot();
        }
        // else if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     
        // }
    }
}
