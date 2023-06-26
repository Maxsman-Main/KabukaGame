using System;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public enum ActiveColor
    {
        Red,
        Green,
        Blue
    }
    
    private static ActiveColor currentColor = ActiveColor.Red;

    [SerializeField] private ActiveColor color = currentColor;
    
    private Renderer playerMeshRenderer;

    private void Awake()
    {
        playerMeshRenderer = GetComponent<Renderer>();
        SetPlayerColor();
    }

    public void ToggleColor()
    {
        switch (currentColor)
        {
            case ActiveColor.Red:
                currentColor = ActiveColor.Green;
                break;
            case ActiveColor.Green:
                currentColor = ActiveColor.Blue;
                break;
            case ActiveColor.Blue:
                currentColor = ActiveColor.Red;
                break;
        }

        SetPlayerColor();
    }

    private void SetPlayerColor()
    {
        switch (currentColor)
        {
            case ActiveColor.Red:
                //playerMeshRenderer.material.color = Color.red;
                //color = ActiveColor.Red;
                break;
            case ActiveColor.Green:
                //playerMeshRenderer.material.color = Color.green;
                //color = ActiveColor.Green;
                break;
            case ActiveColor.Blue:
                //playerMeshRenderer.material.color = Color.blue;
                //color = ActiveColor.Blue;
                break;
        }
    }

    public static bool CanInteractWithObject(Color objectColor)
    {
        return (currentColor == ActiveColor.Red && objectColor == Color.red) ||
               (currentColor == ActiveColor.Green && objectColor == Color.green) ||
               (currentColor == ActiveColor.Blue && objectColor == Color.blue);
    }

    private void Update()
    {
        currentColor = color;
        SetPlayerColor();
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleColor();
        }
    }
}