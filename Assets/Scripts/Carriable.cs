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
            transform.rotation = cam.transform.rotation;
            if (Input.GetKeyDown(KeyCode.E)) {
                print("dropping");
                if (isBeingCarried) {
                    Drop();
                }
            }
        }
    }
    public override void OnInteract() {
        if (!isBeingCarried && !cooldown) {
            Pickup();
        }
    }
    void Drop() {
        rb.useGravity = true;
        cooldown = true;
        base.radius = startRadius;
        isBeingCarried = false;
        Invoke("PickupCooldown", 2);
    }
    void Pickup() {
        rb.useGravity = false;
        isBeingCarried = true;
        base.radius = Vector3.Distance(transform.position, cam.transform.position) + 2;
    }
    void PickupCooldown() {
        cooldown = false;
    }
    public override void OnFocus() {
    }
    public override void OnLooseFocus() {

    }
}
