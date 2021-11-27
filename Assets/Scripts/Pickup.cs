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
    void Start()
    {
    }
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
        // Enable canvas
        canvasScript.OnEnable();
        // Set text on screen
        canvasScript.SetText(pickupText);
        // Disable canvas after 2 seconds
        canvasScript.Invoke("OnDisable", 2f);
        // Hide object
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        // Delete after 2 seconds
        Invoke("DestroyObject", 2f);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    public override void OnFocus()
    {
    }
    public override void OnLooseFocus()
    {
    }
}
