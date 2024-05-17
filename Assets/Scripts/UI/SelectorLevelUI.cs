using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorLevelUI : MonoBehaviour
{
    public static SelectorLevelUI Instance;
    private void Start()
    {
        CheckAvailableLevels();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SelectLevel(string nameLevel)
    {
        PlayerPrefs.SetString("NextLevel", nameLevel);
        ScenesManager.LoadGame();
    }

    public void CheckAvailableLevels()
    {
        var selectorBtns = GetComponentsInChildren<Button>();
        int levelAvailable = PlayerPrefs.GetInt("LevelAvailable", 1);
        for (int i = 1; i <= selectorBtns.Length; ++i)
        {
            selectorBtns[i - 1].interactable = true;
            if (levelAvailable < i)
            {
                selectorBtns[i - 1].interactable = false;
            }
        }
    }
}
