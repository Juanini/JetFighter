using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    public PlayerVariable playerVariable;
    
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI boostText;

    private bool isInitialized;
    void Start()
    {
        
    }
    
    public void Init(PlayerVariable _playerVariable)
    {
        playerVariable = _playerVariable;
        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized) { return; }
        
        healthText.text = playerVariable.Value.GetCurrentHealth().ToString();
        healthText.text = playerVariable.Value.GetBoostAmount().ToString();
    }
}
