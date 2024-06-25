using System;
using UnityEngine;

public class ButtonDoorController : MonoBehaviour
{
    protected internal bool _isActivated;
    public Action<ButtonDoorController> OnDoorButtonPress;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isActivated)
        {
            other.GetComponent<PlayerUseButton>().EnableInteract();
            other.GetComponent<PlayerUseButton>().buttonDoorController = this;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerUseButton>().DisableInteract();
            other.GetComponent<PlayerUseButton>().buttonDoorController = null;
        }
    }

    public void Press()
    {
        LockButton();
        OnDoorButtonPress.Invoke(this);
        
    }

    public void LockButton()
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        _isActivated = true;
        GetComponent<Collider>().enabled = false;
    }

    public void Reset()
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        _isActivated = false;
        GetComponent<Collider>().enabled = true;
    }
}