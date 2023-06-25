using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public int cost = 3;

    private ResourceData resourceData;
    private HealthData hpData;
    void Start()
    {
        resourceData = Load<ResourceData>("ResourceData") ?? new ResourceData();
        hpData = Load<HealthData>("HealthData") ?? new HealthData();
        gameObject.GetComponent<Text>().text = "Res: " + resourceData.resource;
    }

    private void SaveData()
    {
        Save("ResourceData", resourceData);
        Save("HealthData", hpData);
        gameObject.GetComponent<Text>().text = "Res: " + resourceData.resource;
    }

    private T Load<T>(string key)
    {
        string json = PlayerPrefs.GetString(key);
        return string.IsNullOrEmpty(json) ? default : JsonUtility.FromJson<T>(json);
    }

    private void Save<T>(string key, T data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public void BuyMaxHp()
    {
        if (resourceData.resource < cost) return;
        resourceData.resource -= cost;
        hpData.heath += 1;
        SaveData();
    }
}
