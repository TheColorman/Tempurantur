using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardCheck : Interactable
{
    public Door door;
    public Door otherDoor;
    public enum KeyCardType {
        keyCardOne,
        keyCardTwo,
        keyCardThree,
    }
    public CanvasScript canvasScript;
    public KeyCardType keyCardType;
    public override void OnInteract()
    {
        // Get player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // get manager
        Manager manager = player.GetComponent<Manager>();

        // Check if keycard is true
        switch (keyCardType)
        {
            case KeyCardType.keyCardOne:
                if (manager.keyCardOne)
                {
                    manager.keyCardOneUnlocked = true;
                    AcceptKeyCard();
                } else {
                    RejectKeyCard();
                }
                break;
            case KeyCardType.keyCardTwo:
                if (manager.keyCardTwo)
                {
                    manager.keyCardTwoUnlocked = true;
                    AcceptKeyCard();
                } else {
                    RejectKeyCard();
                }
                break;
            case KeyCardType.keyCardThree:
                if (manager.keyCardThree)
                {
                    manager.keyCardThreeUnlocked = true;
                    AcceptKeyCard();
                } else {
                    RejectKeyCard();
                }
                break;
        }
    }
    public override void OnFocus()
    {
    }
    public override void OnLooseFocus()
    {
    }
    void AcceptKeyCard()
    {
        // Enable canvas and set accept text
        canvasScript.OnEnable();
        canvasScript.SetText("Keycard accepted");
        // Disable canvas after 2 seconds
        canvasScript.Invoke("OnDisable", 2f);
        // Open doors
        if (door != null)
        {
            door.Open();
        }
        if (otherDoor != null)
        {
            otherDoor.Open();
        }
    }
    void RejectKeyCard()
    {
        // Enable canvas and set accept text
        canvasScript.OnEnable();
        canvasScript.SetText("Keycard rejected");
        // Disable canvas after 2 seconds
        canvasScript.Invoke("OnDisable", 2f);
    }
}
