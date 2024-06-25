using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTemperature playerTemperature = other.GetComponent<PlayerTemperature>();
            if (playerTemperature != null)
            {
                playerTemperature.isInHeatZone = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTemperature playerTemperature = other.GetComponent<PlayerTemperature>();
            if (playerTemperature != null)
            {
                playerTemperature.isInHeatZone = false;
            }
        }
    }

}
