using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<PlayerVariable> playersList;

    public ScriptableListPlayerInfoUI scriptableListPlayerInfoUI;
    
    [FormerlySerializedAs("onShipDestoyed")] [Header("EVENTS")] [SerializeField]
    private ScriptableEventPlayer onShipDestroyed;

    private void Start()
    {
        RegisterEvents();
    }

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
    
    private void OnShipDestroyed(Player _player)
    {
        if (CheckIfOnlyOnePlayerAlive())
        {
            GameManager.Ins.TransitionToState(GameStates.GameOver);
        }
    }
    
    public bool CheckIfOnlyOnePlayerAlive()
    {
        int aliveCount = 0;
        
        foreach (var playerVariable in playersList)
        {
            if (playerVariable.Value != null && !playerVariable.IsDead())
            {
                aliveCount++;
            }
        }
        
        return aliveCount == 1;
    }
    
    // * =====================================================================================================================================
    // * EVENTS

    private void RegisterEvents()
    {
        onShipDestroyed.OnRaised += OnShipDestroyed;
    }

    private void UnregisterEvents()
    {
        onShipDestroyed.OnRaised -= OnShipDestroyed;
    }

    private void OnDestroy()
    {
        UnregisterEvents();
    }
}
