using UnityEngine;


[CreateAssetMenu(fileName = "ShipSO", menuName = "ScriptableObjects/ShipSO", order = 0)]
public class ShipSO : ScriptableObject
{
    [Header("PROPERTIES")] 
    public float maxHealth;
    public PlayerMovementConfigSO movementConfig;
    
    [Header("ASSETS")]
    public GameObject shipPrefab;
    public Sprite shipSprite;
}