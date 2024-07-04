using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using HannieEcho.UI;
using TMPro;
using UnityEngine;

public class IngameView : UIView
{
    public TextMeshProUGUI countDownText;
    
    public Transform countDownTextAnimPosition;
    public Transform countDownTextAnimPositionOut;

    public override void OnViewCreated()
    {
        base.OnViewCreated();
        UI.Ins.ingameView = this;
    }
    
    // * =====================================================================================================================================
    // * 

    public async UniTask DoCountDownAnim()
    {
        int timeBetweenCountDown = 700;
        
        SetCountDownText("3");
        await UniTask.Delay(timeBetweenCountDown);
        SetCountDownText("2");
        await UniTask.Delay(timeBetweenCountDown);
        SetCountDownText("1");
        await UniTask.Delay(timeBetweenCountDown);
        SetCountDownText("GO!");
        await UniTask.Delay(timeBetweenCountDown);
        
        countDownText.DOFade(0, 0.2f);
    }

    private void SetCountDownText(string _value)
    {
        countDownText.text = _value;
        
        float animTime = 0.23f;
        countDownText.DOFade(0, 0);
        countDownText.transform.position = countDownTextAnimPositionOut.transform.position;

        countDownText.transform.DOMove(countDownTextAnimPosition.transform.position, animTime);
        countDownText.DOFade(1, animTime);
    }
}
