using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerBoost : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    public float boostMultiplier = 2f;
    public float boostDuration = 1f;
    public float boostCooldown = 5f;
    private bool isBoosting = false;

    private float boostBar = 1f;

    void Start()
    {
        // Initialize the boost bar to full
        boostBar = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting)
        {
            PerformBoost().Forget();
        }
        
        // Regenerate the boost bar over time
        if (boostBar < 1f)
        {
            boostBar += Time.deltaTime / boostCooldown;
            boostBar = Mathf.Clamp01(boostBar);
        }
    }

    private async UniTaskVoid PerformBoost()
    {
        isBoosting = true;
        await UniTask.Delay((int)(boostDuration * 1000));
        
        boostBar = 0f;
        isBoosting = false;
    }

    public float GetBoostBar()
    {
        return boostBar;
    }

    public bool IsBoosting()
    {
        return isBoosting;
    }
}