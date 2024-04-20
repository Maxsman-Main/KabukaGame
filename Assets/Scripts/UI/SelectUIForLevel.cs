using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUIForLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public List<GameObject> colorUI;
    public Material materialColor;
    public GameObject torsoColor;
    public List<GameObject> useUI;
    public List<GameObject> grabDropUI;
    public List<GameObject> heatUI;

    private void Awake()
    {
        switch (PlayerPrefs.GetString("NextLevel"))
        {
            case "Level1":
                foreach (var ui in colorUI)
                {
                    ui.SetActive(true);
                }
                player.GetComponent<PlayerColor>().enabled = true;
                torsoColor.GetComponent<Renderer>().material = materialColor;
                break;
            case "Level2":
                foreach (var ui in heatUI)
                {
                    ui.SetActive(true);
                }
                player.GetComponent<PlayerTemperature>().enabled = true;
                break;
            case "Level3":
                foreach (var ui in useUI)
                {
                    ui.SetActive(true);
                }
                break;
            case "Level4":
                foreach (var ui in grabDropUI)
                {
                    ui.SetActive(true);
                }
                break;
            case "Level5":
                
                break;
        }
    }
}
