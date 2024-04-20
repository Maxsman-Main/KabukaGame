using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<ButtonDoorController> validSequenceButton;
    public List<ButtonDoorController> anotherButton;

    private bool _isBrokeSequence;
    private int _curNumButtonSequence;

    private void Awake()
    {
        foreach (var buttonDoorController in validSequenceButton)
        {
            buttonDoorController.OnDoorButtonPress += OnDoorButtonPress;
        }

        foreach (var buttonDoorController in anotherButton)
        {
            buttonDoorController.OnDoorButtonPress += OnDoorButtonPress;
        }
    }

    private void OnDoorButtonPress(ButtonDoorController button)
    {
        if (!_isBrokeSequence && button == validSequenceButton?[_curNumButtonSequence])
        {
            _curNumButtonSequence += 1;
            if (_curNumButtonSequence >= validSequenceButton.Count)
            {
                DoorOpen();
            }
        }
        else
        {
            _isBrokeSequence = true;
            Invoke(nameof(ResetAllButton), 0.5f);
        }
        
    }

    private void DoorOpen()
    {
        transform.Translate(Vector3.forward, Space.Self);
        PressAllButton();
    }

    private void ResetAllButton()
    {
        _curNumButtonSequence = 0;
        foreach (var buttonDoorController in validSequenceButton)
        {
            if (buttonDoorController._isActivated)
                buttonDoorController.Reset();
        }

        foreach (var buttonDoorController in anotherButton)
        {
            if (buttonDoorController._isActivated)
                buttonDoorController.Reset();
        }

        _isBrokeSequence = false;
    }

    private void PressAllButton()
    {
        foreach (var buttonDoorController in validSequenceButton)
        {
            if (!buttonDoorController._isActivated)
                buttonDoorController.LockButton();
        }

        foreach (var buttonDoorController in anotherButton)
        {
            if (!buttonDoorController._isActivated)
                buttonDoorController.LockButton();
        }
    }

    private void OnDestroy()
    {
        foreach (var buttonDoorController in validSequenceButton)
        {
            buttonDoorController.OnDoorButtonPress -= OnDoorButtonPress;
        }

        foreach (var buttonDoorController in anotherButton)
        {
            buttonDoorController.OnDoorButtonPress -= OnDoorButtonPress;
        }
    }
}
