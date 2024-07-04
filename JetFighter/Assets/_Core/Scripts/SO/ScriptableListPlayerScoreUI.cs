using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(fileName = "scriptable_list_" + nameof(PlayerScoreUI), menuName = "Soap/ScriptableLists/"+ nameof(PlayerScoreUI))]
public class ScriptableListPlayerScoreUI : ScriptableList<PlayerScoreUI>
{
    
}
