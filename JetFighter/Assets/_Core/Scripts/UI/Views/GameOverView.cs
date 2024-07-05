using System;
using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : UIView
{
    [SerializeField] private Button rematchButton;
    [SerializeField] private Button changeGameModeButton;
    [SerializeField] private ScriptableEventNoParam onRematch;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        rematchButton.onClick.AddListener(OnRematchClick);
        changeGameModeButton.onClick.AddListener(OnChangeGameModeClick);
    }

    private void OnRematchClick()
    {
        navController.HideNavLastView();
        onRematch.Raise();
    }
    
    private void OnChangeGameModeClick()
    {
        navController.HideNavLastView();
        GameManager.Ins.TransitionToState(GameStates.ModeSelection);
    }
}
