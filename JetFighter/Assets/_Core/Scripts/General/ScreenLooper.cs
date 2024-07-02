using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLooper : MonoBehaviour
{
    private void Update()
    {
        WrapObject(transform);
    }

    private void WrapObject(Transform objTransform)
    {
        Vector3 newPosition = objTransform.position;
    
        float screenWidth = CameraManager.Ins.cam.orthographicSize * CameraManager.Ins.cam.aspect;
        float screenHeight = CameraManager.Ins.cam.orthographicSize;
    
        if (objTransform.position.x > screenWidth)
        {
            newPosition.x = -screenWidth;
        }
        else if (objTransform.position.x < -screenWidth)
        {
            newPosition.x = screenWidth;
        }
    
        if (objTransform.position.y > screenHeight)
        {
            newPosition.y = -screenHeight;
        }
        else if (objTransform.position.y < -screenHeight)
        {
            newPosition.y = screenHeight;
        }
    
        objTransform.position = newPosition;
    }
}
