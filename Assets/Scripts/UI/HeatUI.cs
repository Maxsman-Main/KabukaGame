using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HeatUI : MonoBehaviour
{
    private Image _redHeatUIImage;
    
    [Inject] private PlayerTemperature _playerTemperature;
    private void Start()
    {
        _redHeatUIImage = GetComponent<Image>();
        _redHeatUIImage.fillAmount = 0f;
        _playerTemperature.OnHeatChanged += UIHeatUpdate;
    }

    private void UIHeatUpdate(float value)
    {
        _redHeatUIImage.fillAmount = value;
    }
    
    private void OnDestroy()
    {
        _playerTemperature.OnHeatChanged -= UIHeatUpdate;
    }
}
