using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WinGameUI : MonoBehaviour
{
    public void WinGameEnable()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
