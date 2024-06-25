using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKeyForDeveloper : MonoBehaviour
{
    [SerializeField]
    private SelectorLevelUI _selectorLevelUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            PlayerPrefs.SetInt("LevelAvailable", PlayerPrefs.GetInt("LevelAvailable", 1) + 1);
            _selectorLevelUI.CheckAvailableLevels();
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            PlayerPrefs.SetInt("LevelAvailable", PlayerPrefs.GetInt("LevelAvailable", 1) - 1);
            _selectorLevelUI.CheckAvailableLevels();
        }
        
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.SetInt("LevelAvailable", 1);
            _selectorLevelUI.CheckAvailableLevels();
            PlayerPrefs.SetInt("WinGame", 0);
        }
    }
}
