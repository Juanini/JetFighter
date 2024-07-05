using System.Collections;
using System.Collections.Generic;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayView : UIView
{
    public Button okButton;
    public Image howToPlayImage;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        okButton.onClick.AddListener(OnOkClick);
    }

    public override void OnViewBeforeAppear()
    {
        base.OnViewBeforeAppear();
        howToPlayImage.sprite = GameManager.Ins.GetGameModeActive().howToPlayImage;
    }

    private void OnOkClick()
    {
        navController.HideNavLastView();
        GameManager.Ins.TransitionToState(GameStates.LevelSetup);
    }
}
