using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds;

    private void Start()
    {
        var levelsPath = PlayerPrefs.GetString("NextLevel", "Level1");
        switch (levelsPath)
        {
            case "Level1":
                backgrounds[0].SetActive(true); 
                break;
            case "Level2":
                backgrounds[1].SetActive(true); 
                break;
            case "Level3":
                backgrounds[2].SetActive(true); 
                break;
            case "Level4":
                backgrounds[3].SetActive(true); 
                break;
            case "Level5":
                backgrounds[4].SetActive(true); 
                break;
        }
    }
}
