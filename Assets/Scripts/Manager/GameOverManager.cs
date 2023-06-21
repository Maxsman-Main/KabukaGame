using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameOverManager : MonoBehaviour
{
    private void Awake()
    {
        Health.OnDied += GameOver;
        CountdownTimer.onTimerExpired += GameOver;
    }

    private void GameOver()
    {
        ScenesManager.LoadShop();
    }
    
    private void OnDestroy()
    {
        Health.OnDied -= GameOver;
        CountdownTimer.onTimerExpired -= GameOver;
    }
}
