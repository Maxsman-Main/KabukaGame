using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static void LoadShop()
    { 
        SceneManager.LoadScene("Scenes/ShopMenu");
    }
    
    public static void LoadGame()
    { 
        SceneManager.LoadScene("Scenes/Game");
    }
}
