using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUseButton : MonoBehaviour
{
    public Button useBtn;
    public ButtonDoorController buttonDoorController;

    private void Awake()
    {
        DisableInteract();
    }

    public void EnableInteract()
    {
        useBtn.interactable = true;
    }
    
    public void DisableInteract()
    {
        useBtn.interactable = false;
        buttonDoorController = null;
    }

    public void ActivateButton()
    {
        if (buttonDoorController is not null)
        {
            buttonDoorController.Press();
            buttonDoorController.OnTriggerExit(gameObject.GetComponent<Collider>());
        }
    }
}
