using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : Interactable
{
    public TimeTravel other;
    GameObject player;
    CharacterController controller;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
    }
    
    public override void OnInteract()
    {
        // Teleport player to other time travel (disable character controller to enable teleport)
        controller.enabled = false;
        Vector3 TimeTravelDifference = other.transform.position - transform.position;
        player.transform.position += TimeTravelDifference;
        controller.enabled = true;
    }
    public override void OnFocus()
    {
        
    }
    public override void OnLooseFocus()
    {

    }
}
