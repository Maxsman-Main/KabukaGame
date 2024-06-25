using System.Collections;
using System.Collections.Generic;
using Services.InputService;
using UnityEngine;
using Zenject;

public class JoystickInput : MonoBehaviour, IJoystickInput
{
    public float Horizontal => gameObject.GetComponent<FloatingJoystick>().Horizontal;

    public float Vertical => gameObject.GetComponent<FloatingJoystick>().Vertical;
}
