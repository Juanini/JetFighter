using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameStateLevelSetup : StateBase<GameStates>
{
    public override async UniTask EnterState()
    {
        await UI.ShowDialog<IngameView>();
        await LevelManager.Ins.CreatePlayers();
        GameManager.Ins.TransitionToState(GameStates.PregameStart);
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
