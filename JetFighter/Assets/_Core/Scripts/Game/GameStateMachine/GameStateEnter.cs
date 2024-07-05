using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameStateEnter : StateBase<GameStates>
{
    public override async UniTask EnterState()
    {
        await UI.ShowDialog<MainMenuView>();
    }

    public override async UniTask ExitState()
    {
        
    }

    public override async void UpdateState()
    {
        
    }

    public GameStateEnter(GameStates _key) : base(_key)
    {
    }
}
