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
    
    public Material playerMaterial;

    private void Awake()
    {
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
                ColorUtility.TryParseHtmlString("#CC8888", out var red);
                playerMaterial.color = red;
                color = ActiveColor.Red;
                break;
            case ActiveColor.Green:
                ColorUtility.TryParseHtmlString("#94B094", out var green);
                playerMaterial.color = green;
                color = ActiveColor.Green;
                break;
            case ActiveColor.Blue:
                ColorUtility.TryParseHtmlString("#9F9FD6", out var blue);
                playerMaterial.color = blue;
                color = ActiveColor.Blue;
                break;
        }
    }

    public static bool CanInteractWithObject(ActiveColor objectColor)
    {
        return (currentColor == ActiveColor.Red && objectColor == ActiveColor.Red) ||
               (currentColor == ActiveColor.Green && objectColor == ActiveColor.Green) ||
               (currentColor == ActiveColor.Blue && objectColor == ActiveColor.Blue);
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