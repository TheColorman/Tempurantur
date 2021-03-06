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
    AudioSource audioSource;
    List<GameObject> objectsToMove = new List<GameObject>();
    Manager manager;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        fade = player.GetComponentInChildren<Fade>();
        door = transform.parent.Find("Door").GetComponent<Door>();
        otherDoor = other.transform.parent.Find("Door").GetComponent<Door>();
        audioSource = GetComponent<AudioSource>();
        manager = player.GetComponent<Manager>();
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
        audioSource.Play();
        teleporting = true;
        fade.FadeIn();
        controller.enabled = false;
        door.Close();
        yield return new WaitForSeconds(1f);
        Vector3 TimeTravelDifference = other.transform.position - transform.position;
        player.transform.position += TimeTravelDifference;

        manager.playerInPresent = !manager.playerInPresent;

        for (int i = 0; i < objectsToMove.Count; i++)
        {
            objectsToMove[i].transform.position += TimeTravelDifference;
            Carriable carriable = objectsToMove[i].GetComponent<Carriable>();
            if (carriable != null)
            {
                carriable.OnTeleport();
            }
        }
        objectsToMove.Clear();

        fade.FadeOut();
        yield return new WaitForSeconds(1f);
        otherDoor.Open();
        controller.enabled = true;
        teleporting = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            if (objectsToMove.Contains(other.gameObject))
            {
                return;
            }
            objectsToMove.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            if (!objectsToMove.Contains(other.gameObject))
            {
                return;
            }
            objectsToMove.Remove(other.gameObject);
        }
    }
}
