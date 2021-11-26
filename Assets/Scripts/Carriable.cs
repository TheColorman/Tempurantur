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
        if (isBeingCarried) {
            transform.position = cam.transform.position + cam.transform.forward * 3;
            Vector3 currentPos = transform.position;
            currentPos.y = currentPos.y < cam.transform.position.y - 1 ? cam.transform.position.y - 1 : currentPos.y;
            transform.position = currentPos;
            // Raycast from camera to get closest wall
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 3, LayerMask.NameToLayer("Carrying"))) {
                // Get position slightly closer to camera
                transform.position = hit.point - cam.transform.forward * 0.1f;
            }
            transform.rotation = cam.transform.rotation;
            if (Input.GetKeyDown(KeyCode.E) && !cooldown) {
                Drop();
            }
        }
    }
    public override void OnInteract() {
        if (!isBeingCarried && !cooldown) {
            Pickup();
            cooldown = true;
            Invoke("ResetCooldown", 0.2f);
        }
    }
    void Drop() {
        // Set layermask to "Interactable"
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        rb.useGravity = true;
        cooldown = true;
        base.radius = startRadius;
        isBeingCarried = false;
        Invoke("ResetCooldown", 0.5f);
    }
    void Pickup() {
        // Set layermask to "Carrying"
        gameObject.layer = LayerMask.NameToLayer("Carrying");
        rb.useGravity = false;
        isBeingCarried = true;
        base.radius = Vector3.Distance(transform.position, cam.transform.position) + 2;
    }
    void ResetCooldown() {
        cooldown = false;
    }
    public override void OnFocus() {
    }
    public override void OnLooseFocus() {

    }
}
