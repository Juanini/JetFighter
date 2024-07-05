using System;
using System.Collections;
using System.Collections.Generic;
using GameEventSystem;
using Obvious.Soap;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStateMachine gameStateMachine;

    [Header("GAME MODE")] 
    private GameModeTypeSO currentModeSelected;
    [SerializeField] private ScriptableEventGameModeTypeSO onGameModeSelected;

    [Header("EVENTS")] 
    public ScriptableEventNoParam onRematch;
    public ScriptableEventNoParam onMatchEnd;
    public ScriptableEventNoParam onMatchStart;
    
    private void Start()
    {
        GameEventManager.StartListening(Bootstrap.ON_GAME_ASSETS_LOADED_EVENT_KEY, OnGameAssetsLoaded);
    }

    private void OnGameAssetsLoaded(Hashtable arg0)
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
    
    public void OnMatchStart()
    {
        onMatchStart.Raise();
    }
    
    private void OnRematch()
    {
        TransitionToState(GameStates.CleanUp);
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
        onRematch.OnRaised += OnRematch;
    }

    private void UnregisterEvents()
    {
        onGameModeSelected.OnRaised -= OnGameModeSelected;
        onRematch.OnRaised -= OnRematch;
    }

    private void OnDestroy()
    {
        UnregisterEvents();
    }
}
