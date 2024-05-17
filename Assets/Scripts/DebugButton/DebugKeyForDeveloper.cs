using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKeyForDeveloper : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            PlayerPrefs.SetInt("LevelAvailable", PlayerPrefs.GetInt("LevelAvailable", 1) + 1);
            SelectorLevelUI.Instance.CheckAvailableLevels();
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            PlayerPrefs.SetInt("LevelAvailable", PlayerPrefs.GetInt("LevelAvailable", 1) - 1);
            SelectorLevelUI.Instance.CheckAvailableLevels();
        }
        
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.SetInt("LevelAvailable", 1);
            SelectorLevelUI.Instance.CheckAvailableLevels();
        }
    }
}
