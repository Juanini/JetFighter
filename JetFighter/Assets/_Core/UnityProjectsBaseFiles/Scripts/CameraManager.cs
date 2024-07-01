using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class CameraManager : Singleton<CameraManager>
{

    public Camera cam;
    
    void Awake()
    {
        cam = Camera.main;
    }

    public void ResetZoom()
    {
        cam.orthographicSize = 15;
    }
    
    public void ResetPosition()
    {
        cam.transform.position = new Vector3(0, 0, -10);
    }

    public async UniTask DoZoom(float _zoomValue, float _time)
    {
        await cam
            .DOOrthoSize(_zoomValue, _time)
            .SetEase(Ease.InOutExpo)
            .AsyncWaitForCompletion();
    }
    
    public void CenterInFrontOfCamera(GameObject objectToCenter)
    {
        if (objectToCenter == null) return;
        Vector3 cameraPosition = cam.transform.position;
        objectToCenter.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, objectToCenter.transform.position.z);
    }
}
