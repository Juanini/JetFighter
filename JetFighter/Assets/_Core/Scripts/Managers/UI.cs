using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HannieEcho.UI;
using UnityEngine;

public class UI : Singleton<UI>
{
    [SerializeField] private UIManager uiManager;
    
    public async UniTask Init()
    {
        await uiManager.Init();
    }
}
