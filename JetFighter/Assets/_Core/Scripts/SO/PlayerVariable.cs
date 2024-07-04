using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(fileName = "scriptable_variable_" + nameof(Player), menuName = "Soap/ScriptableVariables/"+ nameof(Player))]
public class PlayerVariable : ScriptableVariable<Player>
{
    private int playerNumber;
    private PlayerInfoUI infoUI;
    private PlayerScoreUI scoreUI;

    public void CleanUp()
    {
        if (Value != null) 
        {
            Destroy(Value);
        }
    }

    public bool IsDead()
    {
        return Value.Health <= 0;
    }
}

