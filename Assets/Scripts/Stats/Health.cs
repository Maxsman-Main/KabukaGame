using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int health;

    [Inject] private SaveManager saveManager;
    
    private HealthData hpData;
    public static Health Instance { get; private set; }
    
    public void Awake()
    {
        SetHp();
        Instance = this;
    }
    
    public Action<int> OnDamaged;
    public static Action OnDied;

    public void GetDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            OnDied?.Invoke();
        }
        OnDamaged?.Invoke(health);
    }
    
    public void HpPlus(int value)
    {
        health += value;
        OnDamaged?.Invoke(health);
    }
    
    private void SetHp()
    {
        hpData = saveManager.Load<HealthData>("HealthData") ?? new HealthData();
        health = hpData.heath;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            saveManager.Save("HealthData", new HealthData());
            SetHp();
            OnDamaged?.Invoke(health);
        }
    }
}
