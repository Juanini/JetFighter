using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class GameStatePregameStart : StateBase<GameStates>
{
    private float shipEntranceAnimTime = 1.1f;
    
    public override async UniTask EnterState()
    {
        // await UniTask.Delay(500);
        
        LevelManager.Ins.GetPlayer2().SetRotation(-180);
        
        for (var i = 0; i < LevelManager.Ins.PlayersList.Count; i++)
        {
            var playerVariable = LevelManager.Ins.PlayersList[i];
            playerVariable.Value.transform
                .DOMove(PositionReferences.Ins.playersPositions[i].transform.position, shipEntranceAnimTime)
                .SetEase(Ease.OutCubic);
        }

        await UniTask.Delay(500);
        await UniTask.Delay((int)shipEntranceAnimTime * 1000);
        await UI.Ins.ingameView.DoCountDownAnim();

        LevelManager.Ins.SetShipsReadyForMatch();
        
        GameManager.Ins.OnMatchStart();
    }

    public override async UniTask ExitState()
    {
        
    }

    public override async void UpdateState()
    {
        
    }

    public GameStatePregameStart(GameStates _key) : base(_key)
    {
    }
}
