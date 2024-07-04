using System.Collections.Generic;
using Obvious.Soap;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModeTypeSO", menuName = "ScriptableObjects/Enums/GameModeTypeSO")]
public class GameModeTypeSO : ScriptableEnumBase
{
    public Weapon startingWeapon;
    public List<PlayerTypeSO> playersTypesList;
    public List<ShipSO> shipSOList;

    public int GetPlayersAmount()
    {
        return playersTypesList.Count;
    }
}
