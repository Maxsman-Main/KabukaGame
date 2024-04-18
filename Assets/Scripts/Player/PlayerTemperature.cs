using System;
using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;
using Zenject;

public class PlayerTemperature : MonoBehaviour
{
    public float maxTemperature = 100f;
    public float temperatureIncreaseRate = 10f; 
    public float temperatureDecreaseRate = 2f;
    public float temperatureThreshold = 100f;
    private int _amountDamage = 1;
    
    [SerializeField] private float currentTemperature = 0f;
    
    [Inject] private LevelController _levelController;
    
    public bool isInHeatZone;
    
    public Action<float> OnHeatChanged;

    private void Update()
    {
        if (isInHeatZone)
        {
            currentTemperature += Time.deltaTime * temperatureIncreaseRate;
            OnHeatChanged?.Invoke(currentTemperature / maxTemperature);
        }
        else
        {
            currentTemperature -= Time.deltaTime * temperatureDecreaseRate;
            OnHeatChanged?.Invoke(currentTemperature / maxTemperature);
        }

        currentTemperature = Mathf.Clamp(currentTemperature, 0f, maxTemperature);

        if (currentTemperature >= temperatureThreshold)
        {
            Health.Instance.GetDamage(_amountDamage);
            _levelController.TeleportPlayerOnPatternStart(FindObjectOfType<StartPoint>().transform);
            currentTemperature = 0f;
        }
        
    }

}
