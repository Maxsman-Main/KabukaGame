using System;
using Player;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    private BoxCollider objectCollider;
    private Renderer objectRenderer;

    public void Awake()
    {
        objectCollider = gameObject.GetComponent<BoxCollider>();
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