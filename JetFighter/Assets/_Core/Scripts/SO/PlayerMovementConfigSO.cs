using UnityEngine;
using Obvious.Soap;


[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "ScriptableObjects/PlayerMovementConfig", order = 1)]
public class PlayerMovementConfigSO : ScriptableObject
{
    public float forwardSpeed;
    public float turnSpeed;
    public float slowDownFactor;
    public float recoverySpeed;
}