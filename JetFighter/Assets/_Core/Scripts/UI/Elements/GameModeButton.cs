using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeButton : MonoBehaviour
{
    [SerializeField] private GameModeTypeSO gameModeTypeSo;
    [SerializeField] private ScriptableEventGameModeTypeSO onGameModeSelected;
    [SerializeField] private Button button;
    
    void Start()
    {
        button.onClick.AddListener(OnGameModeSelect);
    }

    private async void OnGameModeSelect()
    {
        onGameModeSelected.Raise(gameModeTypeSo);
        await UI.ShowDialog<HowToPlayView>();
    }
}
