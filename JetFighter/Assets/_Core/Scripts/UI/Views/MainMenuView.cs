using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : UIView
{
    [Header("Buttons")]
    public Button playButton;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        SetupButtons();
    }

    private void OnPlayClick()
    {
        navController.HideNavLastView();
        GameManager.Ins.TransitionToState(GameStates.ModeSelection);
    }

    private void SetupButtons()
    {
        playButton.onClick.AddListener(OnPlayClick);
    }
}
