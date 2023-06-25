using System;
using UnityEngine;
using Zenject;

public class ResourceManager : MonoBehaviour
{
    [Inject] private ResourceData resourceData;
    [Inject] private SaveManager saveManager;
    
    private readonly string saveKey = "ResourceData";
    public Action<int> ResourceChanged;

    public int Resources => resourceData.resource;
    
    public static ResourceManager Instance { get; private set; }
    
    public void Awake()
    {
        Instance = this;
    }
    
    [Inject]
    private void Construct()
    {
        resourceData = saveManager.Load<ResourceData>(saveKey) ?? new ResourceData();
    }

    private void ClearResource()
    {
        resourceData.resource = 0;
        SaveResourceData();
        ResourceChanged?.Invoke(Resources);
    }

    public void AddResource(int amount)
    {
        resourceData.resource += amount;
        SaveResourceData();
        ResourceChanged?.Invoke(Resources);
    }

    public void SubtractResource(int amount)
    {
        resourceData.resource -= amount;
        SaveResourceData();
        ResourceChanged?.Invoke(Resources);
    }

    private void SaveResourceData()
    {
        saveManager.Save(saveKey, resourceData);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ClearResource();
        }
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            AddResource(1);
        }
    }
}