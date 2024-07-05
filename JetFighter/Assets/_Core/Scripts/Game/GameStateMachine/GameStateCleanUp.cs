using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameStateCleanUp : StateBase<GameStates>
{
    public override async UniTask EnterState()
    {
        LevelManager.Ins.ResetShips();
        GameManager.Ins.TransitionToState(GameStates.PregameStart);
    }

    public override async UniTask ExitState()
    {
        
    }

    public override async void UpdateState()
    {
        
    }

    public GameStateCleanUp(GameStates _key) : base(_key)
    {
    }
}
