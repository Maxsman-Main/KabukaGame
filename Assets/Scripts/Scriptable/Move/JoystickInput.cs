using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour, IJoystickInput
{
    public float Horizontal => gameObject.GetComponent<FloatingJoystick>().Horizontal;

    public float Vertical => gameObject.GetComponent<FloatingJoystick>().Vertical;
}
