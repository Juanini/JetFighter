using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameStateLevelSetup : StateBase<GameStates>
{
    public override async UniTask EnterState()
    {
        // Instantiate Ships acorting to GameMode info
        LevelManager.Ins.CreatePlayers();
        
        // Setup all elements on level

        // Transition to Countdown State

    }

    public override async UniTask ExitState()
    {
        
    }

    public override async void UpdateState()
    {
        
    }

    public GameStateLevelSetup(GameStates _key) : base(_key)
    {
    }
}
