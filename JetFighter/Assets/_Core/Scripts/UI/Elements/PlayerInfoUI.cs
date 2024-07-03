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

    public ScriptableListPlayerInfoUI scriptableListPlayerInfoUI;

    private bool isInitialized;
    void Start()
    {
        scriptableListPlayerInfoUI.Add(this);
    }
    
    public void Init(PlayerVariable _playerVariable)
    {
        playerVariable = _playerVariable;
        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized) { return; }
        
        healthText.text = "HEALTH: " + playerVariable.Value.GetCurrentHealth().ToString();
        boostText.text = "BOOST: " + playerVariable.Value.GetBoostAmount().ToString();
    }

    private void LateUpdate()
    {
        if (!isInitialized) { return; }
        FollowUIPosition();
    }

    private void FollowUIPosition()
    {
        if (playerVariable.Value.uiPos != null)
        {
            Vector3 uiPosition = playerVariable.Value.uiPos.transform.position;
            transform.position = uiPosition;
            
            // Reset rotation to avoid rotating with the target object
            transform.rotation = Quaternion.identity;
        }
    }
}
