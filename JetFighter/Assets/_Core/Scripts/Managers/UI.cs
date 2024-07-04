using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HannieEcho.UI;
using UnityEngine;
using UnityEngine.UI;

public class UI : Singleton<UI>
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private UINavigation uiNavigation;
    
    public List<PlayerInfoUI> playerInfoUiList;
    public List<PlayerScoreUI> playerScoreUIList;

    public IngameView ingameView;
    
    public async UniTask Init()
    {
        await uiManager.Init();
    }
    
    // * =====================================================================================================================================
    // * 
    
    public static async UniTask<UIView> ShowDialog<T>() where T : UIView
    {
        return await UI.Ins.ShowMenu<T>(ViewType.Dialog);
    }
    
    public static async UniTask<UIView> ShowPanel<T>() where T : UIView
    {
        return await UI.Ins.ShowMenu<T>(ViewType.Panel);
    }
    
    public static async UniTask<UIView> ShowPopup<T>() where T : UIView
    {
        return await UI.Ins.ShowMenu<T>(ViewType.Popup);
    }

    private async UniTask<UIView> ShowMenu<T>(ViewType _viewType) where T : UIView
    {
        UIView view = null;
        
        switch (_viewType)
        {
            case ViewType.Dialog:
                view = await uiNavigation.ShowDialog<T>();
                break;
            case ViewType.Panel:
                view = await uiNavigation.ShowPanel<T>();
                break;
            case ViewType.Popup:
                view = await uiNavigation.ShowPopup<T>();
                break;
        }

        return view;
    }

    public void HideLastView()
    {
        uiNavigation.HideNavLastView();
    }
}

public enum ViewType
{
    Dialog = 0,
    Panel = 1,
    Popup = 3
}
