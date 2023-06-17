using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = gameObject.GetComponent<Text>();
        ResourceManager.Instance.ResourceChanged += TextHpUpdate;
        ResourceManager.Instance.ResourceChanged?.Invoke(ResourceManager.Instance.Resources);
    }
    private void TextHpUpdate(int value)
    {
        _text.text = $"Res: {value}";
    }
    
    private void OnDestroy()
    {
        ResourceManager.Instance.ResourceChanged -= TextHpUpdate;
    }
}
