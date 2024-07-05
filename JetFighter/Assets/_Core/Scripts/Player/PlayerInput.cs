using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    
    private PlayerMovement planeMovement;
    private PlayerBoost playerBoost;

    [SerializeField] private ControllerConfigSO controllerConfigSo;
    [SerializeField] private List<ControllerConfigSO> controllerConfigSoList;

    private bool blockInput;
    void Start()
    {
        player = GetComponent<Player>();
        
        planeMovement = GetComponent<PlayerMovement>();
        playerBoost = GetComponent<PlayerBoost>();
    }

    void Update()
    {
        if (GameManager.Ins.GetCurrentGameState().StateKey != GameStates.InGame) { return; }
        if (blockInput) { return; }
        
        HandleMovementInput();
        HandleBoostInput();
        HandleAttackInput();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(controllerConfigSo.left))
        {
            planeMovement.TurnLeft();
        }
        else if (Input.GetKey(controllerConfigSo.right))
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
        if (Input.GetKeyDown(controllerConfigSo.boost))
        {
            playerBoost.PerformBoost().Forget();
        }
    }

    void HandleAttackInput()
    {
        if (Input.GetKeyDown(controllerConfigSo.shoot))
        {
            player.activeWeapon.TryShoot();
        }
    }

    public void Setup(Player _player)
    {
        player = _player;
        controllerConfigSo = controllerConfigSoList[player.PlayerNumber];
    }

    public void BlockInput(bool _block)
    {
        blockInput = _block;
    }
}
