using Cysharp.Threading.Tasks;

public enum GameStates
{
    Idle = 0,
    Enter,
    ModeSelection,
    ShipSelection,
    LevelSetup,
    PregameStart,
    InGame,
    Paused,
    Results,
    GameOver,
    CleanUp
}
public class GameStateMachine : StateMachine<GameStates>
{
    public async UniTask Setup()
    {
        AddState(GameStates.Idle,         new GameStateIdle(GameStates.Idle), this);
        AddState(GameStates.Enter,        new GameStateEnter(GameStates.Enter), this);
        AddState(GameStates.ModeSelection,new GameStateModeSelection(GameStates.ModeSelection), this);
        AddState(GameStates.ShipSelection,new GameStateShipSelection(GameStates.ShipSelection), this);
        AddState(GameStates.LevelSetup,   new GameStateLevelSetup(GameStates.LevelSetup), this);
        AddState(GameStates.PregameStart, new GameStatePregameStart(GameStates.PregameStart), this);
        AddState(GameStates.InGame,       new GameStateInGame(GameStates.InGame), this);
        AddState(GameStates.Paused,       new GameStatePaused(GameStates.Paused), this);
        AddState(GameStates.GameOver,     new GameStateGameOver(GameStates.GameOver), this);
        AddState(GameStates.CleanUp,      new GameStateCleanUp(GameStates.CleanUp), this);
        
        await EnterInitialState(States[GameStates.Enter]);
        StateTransitioned += OnStateTransitioned;
    }

    private void OnStateTransitioned(GameStates _newState)
    {
        
    }

    private void OnDestroy()
    {
        StateTransitioned -= OnStateTransitioned;
    }
}
