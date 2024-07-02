using UnityEngine;


[CreateAssetMenu(fileName = "ShipSO", menuName = "ScriptableObjects/ShipSO", order = 0)]
public class ShipSO : ScriptableObject
{
    public GameObject shipPrefab;
    public Sprite shipSprite;
}