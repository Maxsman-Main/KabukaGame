using System.Collections;
using System.Collections.Generic;
using Player;
using Scriptable.Move;
using UnityEngine;
using Zenject;

public class PauseUI : MonoBehaviour
{
    [Inject] private Movement _movement;
    public void UnPauseAndPause()
    {
        Time.timeScale = Time.timeScale != 0f ? 0f : 1f;
        Debug.Log(_movement);
    }

    public void ExitBtn()
    {
        UnPauseAndPause();
        GameOverManager.GameOver();
    }
}
