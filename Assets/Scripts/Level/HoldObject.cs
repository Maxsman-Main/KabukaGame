using System;
using Player;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    private Collider objectCollider;
    private Renderer objectRenderer;

    public void Awake()
    {
        objectCollider = gameObject.GetComponent<Collider>();
        objectRenderer = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (PlayerColor.CanInteractWithObject(objectRenderer.material.color))
        {
            objectCollider.enabled = true;
        }
        else
        {
            objectCollider.enabled = false;
        }
    }
}