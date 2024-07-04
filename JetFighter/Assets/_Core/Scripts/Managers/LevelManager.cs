using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<PlayerVariable> playersList;
    public List<PlayerVariable> PlayersList => playersList;

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
            player.SetScreenLooperActive(false);
            player.transform.position = PositionReferences.Ins.playersExitPositions[i].position;
            
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

    public Player GetPlayer1() => playersList[0].Value;
    public Player GetPlayer2() => playersList[1].Value;

    public void SetShipsReadyForMatch()
    {
        foreach (var playerVariable in playersList)
        {
            playerVariable.Value.SetReadyForMatch();
        }
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
