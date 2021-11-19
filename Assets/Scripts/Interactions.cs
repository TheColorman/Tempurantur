using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    static Camera cam;
    public float maxInteractionDistance = 5f;
    public Interactable focus = null;
    public CanvasScript canvas;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(cam.transform.position, forward, out RaycastHit hit, maxInteractionDistance)) {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable")) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (Vector3.Distance(cam.transform.position, hit.point) < interactable.radius && focus != interactable) {
                    SetFocus(interactable);
                }
            } else if (focus != null) {
                RemoveFocus();
            }
        } else if (focus != null) {
            RemoveFocus();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (focus != null) {
                focus.OnInteract();
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
       canvas.OnEnable();
        if (newFocus != focus) {
            if (focus != null) {
                RemoveFocus();
            }
            focus = newFocus;
            newFocus.OnFocus();
        }
    }
    void RemoveFocus()
    {
        canvas.OnDisable();
        if (focus != null) {
            focus.OnLooseFocus();
            focus = null;
        }
    }
}
