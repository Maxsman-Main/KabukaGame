using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorLevelUI : MonoBehaviour
{
    public void SelectLevel(string nameLevel)
    {
        PlayerPrefs.SetString("NextLevel", nameLevel);
        ScenesManager.LoadGame();
    }
}
