using System.Collections;
using System.Collections.Generic;
using Player;
using Scriptable.Move;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public void UnPauseAndPause()
    {
        Time.timeScale = Time.timeScale != 0f ? 0f : 1f;
    }

    public void ExitBtn()
    {
        UnPauseAndPause();
        GameOverManager.GameOver();
    }
}
