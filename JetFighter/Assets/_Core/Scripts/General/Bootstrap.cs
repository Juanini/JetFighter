using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameEventSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Bootstrap : MonoBehaviour
{
    public List<AssetReference> assetsToLoad;

    public const string ON_GAME_ASSETS_LOADED_EVENT_KEY = "OnGameAssetsLoaded";
    
    void Start()
    {
        LoadAssets();
    }
    
    protected async UniTask LoadAssets()
    {
        foreach (var assetToLoad in assetsToLoad)
        {
            await InstantiatePrefabAsync(assetToLoad);
        }
        
        GameEventManager.TriggerEvent(ON_GAME_ASSETS_LOADED_EVENT_KEY);
    }
    
    public async UniTask<GameObject> InstantiatePrefabAsync(AssetReference assetReference, Transform parent = null)
    {
        AsyncOperationHandle<GameObject> handle = assetReference.InstantiateAsync(parent);
        await handle.Task;
        return handle.Result;
    }
}
