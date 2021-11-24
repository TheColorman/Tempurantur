using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public enum PickupType
    {
        keyCardOne,
        keyCardTwo,
        keyCardThree,
    }
    public PickupType pickupType;
    public string pickupText = "Picked up";
    public CanvasScript canvasScript;
    public override void OnInteract()
    {
        // Get player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // get manager
        Manager manager = player.GetComponent<Manager>();

        // Set based on pickup type
        switch (pickupType)
        {
            case PickupType.keyCardOne:
                manager.keyCardOne = true;
                break;
            case PickupType.keyCardTwo:
                // manager.keyCardTwo = true;
                break;
            case PickupType.keyCardThree:
                // manager.keyCardThree = true;
                break;
        }
        
    }
    public override void OnFocus()
    {
    }
    public override void OnLooseFocus()
    {
    }
}
