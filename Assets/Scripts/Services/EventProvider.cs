using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EventProvider : MonoBehaviour
{
    public Action IsGameFinish;
    public WinGameUI WinGame;
    void Start()
    {
        IsGameFinish += WinGame.WinGameEnable;  
    }
}
