using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class ObjectGrabDrop : MonoBehaviour
{
    private GameObject _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerGrabDrop>()._isGrabObject)
        {
            other.GetComponent<PlayerGrabDrop>().EnableInteract();
            other.GetComponent<PlayerGrabDrop>()._objectGrabDrop = this;
            _player = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerGrabDrop>()._isGrabObject)
        {
            other.GetComponent<PlayerGrabDrop>().DisableInteract();
            other.GetComponent<PlayerGrabDrop>()._objectGrabDrop = null;
        }
    }

    public void GrabObject()
    {
        Transform transform1;
        var flipVector = _player.GetComponent<PlayerMovement>().isFlip ? new Vector3(1f, 1f, 0f) : new Vector3(-1f, 1f, 0f);
        (transform1 = transform).SetPositionAndRotation(_player.transform.position + flipVector, Quaternion.identity);
        
        transform1.transform.SetParent(_player.transform);
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        //GetComponent<SphereCollider>().enabled = false;
        _player.GetComponent<PlayerGrabDrop>().DisableInteract();
    }
}
