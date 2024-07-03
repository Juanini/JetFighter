using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStateMachine gameStateMachine;

    [Header("GAME MODE")] 
    private GameModeTypeSO currentModeSelected;
    [SerializeField] private ScriptableEventGameModeTypeSO onGameModeSelected;
    
    private void Start()
    {
        Init();
    }

    private async void Init()
    {
        await UI.Ins.Init();
        await gameStateMachine.Setup();
        RegisterEvents();
        FadePanel.Ins.FadeOut();
    }

    public GameModeTypeSO GetGameModeActive()
    {
        return currentModeSelected;
    }
    
    // * =====================================================================================================================================
    // * 

    public void TransitionToState(GameStates _state)
    {
        gameStateMachine.TransitionToState(_state);
    }
    
    // * =====================================================================================================================================
    // * 
    
    private void OnGameModeSelected(GameModeTypeSO _gameModeSelected)
    {
        currentModeSelected = _gameModeSelected;
    }
    
    // * =====================================================================================================================================
    // * EVENTS
    
    private void RegisterEvents()
    {
        onGameModeSelected.OnRaised += OnGameModeSelected;
    }
    
    private void UnregisterEvents()
    {
        onGameModeSelected.OnRaised -= OnGameModeSelected;
    }

    private void OnDestroy()
    {
        UnregisterEvents();
    }
}
