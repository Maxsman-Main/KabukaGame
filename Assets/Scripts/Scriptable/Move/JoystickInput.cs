using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour, IJoystickInput
{
    public float Horizontal => gameObject.GetComponent<FixedJoystick>().Horizontal;

    public float Vertical => gameObject.GetComponent<FixedJoystick>().Vertical;
}
