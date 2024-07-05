using DG.Tweening;
using HannieEcho.UI;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : UIView
{
    [SerializeField] private Button rematchButton;
    [SerializeField] private Button changeGameModeButton;
    [SerializeField] private ScriptableEventNoParam onRematch;

    [SerializeField] private GameObject buttonsContainer;
    [SerializeField] private GameObject buttonsContainerOutPos;
    [SerializeField] private GameObject buttonsContainerInPos;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        rematchButton.onClick.AddListener(OnRematchClick);
        changeGameModeButton.onClick.AddListener(OnChangeGameModeClick);
    }

    public override void OnViewBeforeAppear()
    {
        base.OnViewBeforeAppear();

        buttonsContainer.transform.position = buttonsContainerOutPos.transform.position;
    }

    public override void OnViewAfterAppear()
    {
        base.OnViewAfterAppear();
        ShowButtonsAnimated();
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

    private void ShowButtonsAnimated()
    {
        buttonsContainer.transform.DOMove(buttonsContainerInPos.transform.position, 0.25f)
            .SetEase(Ease.OutQuad);
    }
}
