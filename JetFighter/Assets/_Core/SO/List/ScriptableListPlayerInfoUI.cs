using UnityEngine;
using Obvious.Soap;

[CreateAssetMenu(fileName = "scriptable_list_" + nameof(PlayerInfoUI), menuName = "Soap/ScriptableLists/"+ nameof(PlayerInfoUI))]
public class ScriptableListPlayerInfoUI : ScriptableList<PlayerInfoUI>
{
    
}
