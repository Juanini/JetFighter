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
    public ScriptableListPlayerScoreUI scriptableListPlayerScoreUI;
    
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
            var payerVariable = playersList[i];
            
            player.Setup(i, playersList[i]);
                
            payerVariable.CleanUp();
            payerVariable.Value = player;
            payerVariable.infoUI = scriptableListPlayerInfoUI[i]; 
            payerVariable.scoreUI = scriptableListPlayerScoreUI[i];
                
            player.SetScreenLooperActive(false);
            player.transform.position = PositionReferences.Ins.playersExitPositions[i].position;
            
            scriptableListPlayerInfoUI[i].Init(payerVariable);
            scriptableListPlayerScoreUI[i].Init(payerVariable);
        }
    }
    
    private void OnShipDestroyed(Player _player)
    {
        var winnerPlayer = CheckIfOnlyOnePlayerAlive(); 
        
        if (winnerPlayer != null)
        {
            winnerPlayer.OnWinMatch();
            GameManager.Ins.TransitionToState(GameStates.GameOver);
        }
    }
    
    public PlayerVariable CheckIfOnlyOnePlayerAlive()
    {
        int aliveCount = 0;
        PlayerVariable lastAlivePlayer = null;
    
        foreach (var playerVariable in playersList)
        {
            if (playerVariable.Value != null && !playerVariable.IsDead())
            {
                aliveCount++;
                lastAlivePlayer = playerVariable;
            }
        }
    
        return aliveCount == 1 ? lastAlivePlayer : null;
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
    
    public void ResetShips()
    {
        foreach (var playerVariable in playersList)
        {
            playerVariable.Value.PrepareForNextMatch();
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
