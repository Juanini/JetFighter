using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerBoost : MonoBehaviour
{
    public PlayerMovementConfigSO movementConfig;
    public float boostMultiplier = 2f;
    public float boostDuration = 1f;
    public float boostCooldown = 5f;
    private bool isBoosting = false;

    private float boostBar = 100f;
    private const float maxBoostBar = 100f;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        isBoosting = false;
        boostBar = maxBoostBar;
    }

    void Update()
    {
        if (boostBar < maxBoostBar)
        {
            boostBar += (Time.deltaTime / boostCooldown) * maxBoostBar;
            boostBar = Mathf.Clamp(boostBar, 0f, maxBoostBar);
        }
    }

    public async UniTaskVoid PerformBoost()
    {
        if (boostBar != maxBoostBar) { return; }
        
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