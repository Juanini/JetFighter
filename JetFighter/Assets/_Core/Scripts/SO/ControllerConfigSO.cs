using UnityEngine;

[CreateAssetMenu(fileName = "ControllerConfig", menuName = "ScriptableObjects/ControllerConfig", order = 0)]
public class ControllerConfigSO : ScriptableObject
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;
    public KeyCode boost;
}