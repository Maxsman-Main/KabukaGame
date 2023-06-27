using System;
using Player;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    private Collider objectCollider;
    private Renderer objectRenderer;
    
    private PlayerColor.ActiveColor color;

    private static readonly Color Red = new Color(0.802f, 0.533f, 0.533f, 1.000f);
    private static readonly Color Blue = new Color(0.622f, 0.622f, 0.840f, 1.000f);
    private static readonly Color Green = new Color(0.581f, 0.689f, 0.581f, 1.000f);

    public void Awake()
    {
        objectCollider = gameObject.GetComponent<Collider>();
        objectRenderer = gameObject.GetComponent<Renderer>();
        if (Mathf.Abs (objectRenderer.material.color.r-Red.r)<.1f)
        {
            color = PlayerColor.ActiveColor.Red;
        }
        if (Mathf.Abs (objectRenderer.material.color.g-Green.g)<.1f)
        {
            color = PlayerColor.ActiveColor.Green;
        }
        if (Mathf.Abs (objectRenderer.material.color.b-Blue.b)<.1f)
        {
            color = PlayerColor.ActiveColor.Blue;
        }
    }

    private void Update()
    {
        objectCollider.enabled = PlayerColor.CanInteractWithObject(color);
    }
}