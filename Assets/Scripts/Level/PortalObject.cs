using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    public PortalObject toTeleport;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            Teleport(other.transform, toTeleport.transform.GetChild(0));
        }
    }

    private void Teleport(Transform first, Transform second)
    {
        first.position = second.position;
    }
}
