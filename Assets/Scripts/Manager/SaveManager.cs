using UnityEngine;

public class SaveManager
{
    public T Load<T>(string key)
    {
        string json = PlayerPrefs.GetString(key);
        return string.IsNullOrEmpty(json) ? default : JsonUtility.FromJson<T>(json);
    }

    public void Save<T>(string key, T data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }
}