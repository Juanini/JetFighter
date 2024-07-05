using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private PlayerVariable playerVariable;
    [SerializeField] private Image shipImage;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScriptableListPlayerScoreUI scriptableListPlayerScoreUI;
    
    void Start()
    {
        scriptableListPlayerScoreUI.Add(this);
    }

    public void Init(PlayerVariable _playerVariable)
    {
        playerVariable = _playerVariable;
        shipImage.sprite = playerVariable.Value.GetShipSprite();
        SetScore(0);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
