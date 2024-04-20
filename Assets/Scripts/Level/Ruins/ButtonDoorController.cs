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
        transform.GetChild(0).transform.Translate(new Vector3(0, -0.15f, 0f), Space.Self);
        _isActivated = true;
        GetComponent<Collider>().enabled = false;
    }

    public void Reset()
    {
        transform.GetChild(0).transform.Translate(new Vector3(0, 0.15f,0f), Space.Self);
        _isActivated = false;
        GetComponent<Collider>().enabled = true;
    }
}