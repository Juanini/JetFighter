using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<PlayerVariable> playersList;

    public ScriptableListPlayerInfoUI scriptableListPlayerInfoUI;
    
    public void CreatePlayers()
    {
        for (var i = 0; i < playersList.Count; i++)
        {
            var gameMode = GameManager.Ins.GetGameModeActive();
            
            var player = Instantiate(gameMode.playersTypesList[i].playerPrefab).GetComponent<Player>();
            
            player.Setup(i);
                
            playersList[i].CleanUp();
            playersList[i].Value = player;
            player.transform.position = PositionReferences.Ins.playersPositions[i].position;
            
            scriptableListPlayerInfoUI[i].Init(playersList[i]);
        }
    }
}
