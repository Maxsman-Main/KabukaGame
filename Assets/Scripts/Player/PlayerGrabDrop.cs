using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGrabDrop : MonoBehaviour
{
    public Button grabDropButton;
    public ObjectGrabDrop _objectGrabDrop;
    public PlaceToDropObject _placeToDropObject;

    internal bool _isGrabObject = false;
    
    public void EnableInteract()
    {
        grabDropButton.interactable = true;
    }
    
    public void DisableInteract()
    {
        grabDropButton.interactable = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Collider>().enabled = true;
    }
    
    public void GrabDropObject()
    {
        if (_objectGrabDrop is not null && !_isGrabObject)
        {
            _objectGrabDrop.GetComponent<SphereCollider>().radius = 0.5f;
            _objectGrabDrop.GrabObject();
            grabDropButton.transform.Rotate(new Vector3(0, 0, -180));
            _isGrabObject = true;
        }

        if (_placeToDropObject is not null && _isGrabObject)
        {
            _objectGrabDrop.GetComponent<SphereCollider>().radius = 1.5f;
            _placeToDropObject.DropObject();
            grabDropButton.transform.Rotate(new Vector3(0, 0, 180));
            _isGrabObject = false;
        }
    }
}
