using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private PlayerVariable playerVariable;
    [SerializeField] private Image shipImage;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    void Start()
    {
        
    }

    public void Init(PlayerVariable _playerVariable)
    {
        playerVariable = _playerVariable;
        shipImage.sprite = playerVariable.Value.GetShipSprite();
        scoreText.text = "0";
    }
}
