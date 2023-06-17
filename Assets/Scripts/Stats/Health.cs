using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int health;
    
    public static Health Instance { get; private set; }
    
    public void Awake()
    {
        Instance = this;
    }
    
    public Action<int> OnDamaged;
    public Action OnDied;

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
    
    public void SetHp(int value)
    {
        health = value;
        OnDamaged?.Invoke(health);
    }
}
