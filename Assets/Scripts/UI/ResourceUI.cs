using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = gameObject.GetComponent<Text>();
        ResourceManager.Instance.ResourceChanged += TextHpUpdate;
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
