using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int health;
    
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
}
