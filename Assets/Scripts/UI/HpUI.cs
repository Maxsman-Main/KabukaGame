using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HpUI : MonoBehaviour
{
    [Inject] private Health _health;
    
    private Text _text;

    private void Awake()
    {
        _text = gameObject.GetComponent<Text>();
        _health.OnDamaged += TextHpUpdate;
        _health.GetDamage(0);
    }

    private void TextHpUpdate(int value)
    {
        _text.text = $"HP: {value}";
    }
    
    private void OnDestroy()
    {
        _health.OnDamaged -= TextHpUpdate;
    }
}
