using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameStateModeSelection : StateBase<GameStates>
{
    public GameStateModeSelection(GameStates _key) : base(_key)
    {
    }
    
    public override async UniTask EnterState()
    {
        UI.ShowDialog<ModeSelectView>();
    }

    public override async UniTask ExitState()
    {
        
    }

    public override async void UpdateState()
    {
        
    }
}
