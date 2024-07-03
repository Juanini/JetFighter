using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private async void Init()
    {
        await UI.Ins.Init();
    }
}
