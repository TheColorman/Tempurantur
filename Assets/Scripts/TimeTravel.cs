using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : Interactable
{
    public TimeTravel other;
    GameObject player;
    CharacterController controller;
    private bool teleporting = false;
    Fade fade;
    Door door;
    Door otherDoor;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        fade = player.GetComponentInChildren<Fade>();
        door = transform.parent.Find("Door").GetComponent<Door>();
        otherDoor = other.transform.parent.Find("Door").GetComponent<Door>();
    }
    
    public override void OnInteract()
    {
        if (teleporting) { return; }
        // Start courutine
        // Teleport player to other time travel (disable character controller to enable teleport)
        StartCoroutine(TeleportRoutine());
    }
    public override void OnFocus()
    {
        
    }
    public override void OnLooseFocus()
    {

    }
    IEnumerator TeleportRoutine()
    {
        teleporting = true;
        fade.FadeIn();
        controller.enabled = false;
        door.Close();
        yield return new WaitForSeconds(1f);
        Vector3 TimeTravelDifference = other.transform.position - transform.position;
        player.transform.position += TimeTravelDifference;

        fade.FadeOut();
        yield return new WaitForSeconds(1f);
        otherDoor.Open();
        controller.enabled = true;
        teleporting = false;
    }
}
