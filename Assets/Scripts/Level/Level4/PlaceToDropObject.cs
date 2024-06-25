using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceToDropObject : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerGrabDrop>().gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectGrabDrop>() is not null && _player.GetComponent<PlayerGrabDrop>()._isGrabObject && transform.childCount < 4)
        {
            _player.GetComponent<PlayerGrabDrop>().EnableInteract();
            _player.GetComponent<PlayerGrabDrop>()._placeToDropObject = this;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ObjectGrabDrop>() is not null && _player.GetComponent<PlayerGrabDrop>()._isGrabObject)
        {
            _player.GetComponent<PlayerGrabDrop>().DisableInteract();
            _player.GetComponent<PlayerGrabDrop>()._placeToDropObject = null;
        }
    }

    public void DropObject()
    {
        var objectGrabDrop = _player.GetComponent<PlayerGrabDrop>()._objectGrabDrop;
        objectGrabDrop.transform.SetPositionAndRotation(transform.position + Vector3.up, Quaternion.identity);
        objectGrabDrop.transform.SetParent(transform);
        objectGrabDrop.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        //objectGrabDrop.GetComponent<SphereCollider>().enabled = true;
        _player.GetComponent<PlayerGrabDrop>().DisableInteract();
        _player.GetComponent<PlayerGrabDrop>()._objectGrabDrop = null;
        _player.GetComponent<PlayerGrabDrop>()._placeToDropObject = null;
    }
}
