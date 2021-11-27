using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriable : Interactable
{
    Camera cam;
    public bool isBeingCarried = false;
    float startRadius;
    bool cooldown = false;
    Rigidbody rb;
    void Start() {
        cam = Camera.main;
        startRadius = base.radius;
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && !cooldown && isBeingCarried) {
            Drop();
        }
    }
    void FixedUpdate() {
        if (isBeingCarried) {
            Vector3 GoalPos = cam.transform.position + cam.transform.forward * 3;
            Vector3 currentPos = rb.transform.position;
            // Raycast from camera to get closest wall
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 3, LayerMask.NameToLayer("Carrying"))) {
                // Get position slightly closer to camera
                GoalPos = hit.point - cam.transform.forward * 0.1f;
            }
            GoalPos.y = GoalPos.y < cam.transform.position.y - 1 ? cam.transform.position.y - 1 : GoalPos.y;

            rb.MovePosition(Vector3.Lerp(currentPos, GoalPos, Time.fixedDeltaTime * 10));
            rb.MoveRotation(cam.transform.rotation);
        }
    }
    public override void OnInteract() {
        if (!isBeingCarried && !cooldown) {
            Pickup();
        }
    }
    void Drop() {
        // Set layermask to "Interactable"
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        rb.useGravity = true;
        cooldown = true;
        base.radius = startRadius;
        isBeingCarried = false;
        Invoke("ResetCooldown", 0.1f);
    }
    void Pickup() {
        // Set layermask to "Carrying"
        gameObject.layer = LayerMask.NameToLayer("Carrying");
        rb.useGravity = false;
        isBeingCarried = true;
        base.radius = Vector3.Distance(rb.transform.position, cam.transform.position) + 5;
        cooldown = true;
        Invoke("ResetCooldown", 0.1f);
    }
    void ResetCooldown() {
        cooldown = false;
    }
    public override void OnFocus() {
    }
    public override void OnLooseFocus() {

    }
}
