using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameStateGameOver : StateBase<GameStates>
{
    public override async UniTask EnterState()
    {
        GameManager.Ins.onMatchEnd.Raise();
        UI.ShowPopup<GameOverView>();
    }

    public override async UniTask ExitState()
    {
        
    }

    public override async void UpdateState()
    {
        
    }

    public GameStateGameOver(GameStates _key) : base(_key)
    {
    }
}
