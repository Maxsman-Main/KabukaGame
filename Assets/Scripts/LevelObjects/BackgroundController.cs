using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private List<Material> skyboxes;
    private void Start()
    {
        var levelsPath = PlayerPrefs.GetString("NextLevel", "Level1");
        switch (levelsPath)
        {
            case "Level1":
                backgrounds[0].SetActive(true);
                RenderSettings.skybox = skyboxes[0];
                break;
            case "Level2":
                backgrounds[1].SetActive(true);
                RenderSettings.skybox = skyboxes[1];
                break;
            case "Level3":
                backgrounds[2].SetActive(true);
                RenderSettings.skybox = skyboxes[2];
                break;
            case "Level4":
                backgrounds[3].SetActive(true);
                RenderSettings.skybox = skyboxes[3];
                break;
            case "Level5":
                backgrounds[4].SetActive(true);
                RenderSettings.skybox = skyboxes[4];
                break;
        }

        //RenderSettings.fogDensity (float)
        //RenderSettings.fogColor (Color)
    }
    
}
