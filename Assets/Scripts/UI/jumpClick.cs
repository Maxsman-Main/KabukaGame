using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class jumpClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isUIButtonDown = false;
    public static bool isUIButtonUp = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isUIButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isUIButtonUp = true;
    }
}
