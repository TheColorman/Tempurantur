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
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        fade = player.GetComponentInChildren<Fade>();
    }
    
    public override void OnInteract()
    {
        if (teleporting) { return; }
        // Start courutine
        // Teleport player to other time travel (disable character controller to enable teleport)
        StartCoroutine(FadeCouroutine());
    }
    public override void OnFocus()
    {
        
    }
    public override void OnLooseFocus()
    {

    }
    IEnumerator FadeCouroutine()
    {
        teleporting = true;
        fade.FadeIn();
        yield return new WaitForSeconds(1f);
        controller.enabled = false;
        Vector3 TimeTravelDifference = other.transform.position - transform.position;
        player.transform.position += TimeTravelDifference;
        controller.enabled = true;

        fade.FadeOut();
        yield return new WaitForSeconds(1f);
        teleporting = false;
    }
}
