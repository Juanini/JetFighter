using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(fileName = "scriptable_variable_" + nameof(Player), menuName = "Soap/ScriptableVariables/"+ nameof(Player))]
public class PlayerVariable : ScriptableVariable<Player>
{
    public PlayerInfoUI infoUI;
    public PlayerScoreUI scoreUI;

    public void CleanUp()
    {
        if (Value != null)
        {
            Value.Score = 0;
            Destroy(Value.gameObject);
        }
    }

    public bool IsDead()
    {
        return Value.Health <= 0;
    }

    public void OnWinMatch()
    {
        Value.Score++;
        scoreUI.SetScore(Value.Score);
    }
}

