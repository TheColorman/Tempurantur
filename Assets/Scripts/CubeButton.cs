using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    GameObject Compressable;
    bool isPressed = false;
    public float offset = 5f;
    Door door;
    public Door otherDoor;
    void Awake() {
        Compressable = gameObject.transform.Find("Stm_button02").gameObject;
        door = GetComponentInParent<Door>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (isPressed)
        {
            return;
        }
        if (collider.gameObject.tag == "ButtonPress" || collider.gameObject.tag == "Player")
        {
            OnPress();
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (!isPressed)
        {
            return;
        }
        if (collider.gameObject.tag == "ButtonPress" || collider.gameObject.tag == "Player")
        {
            OnRelease();
        }
    }
    void OnPress()
    {
        isPressed = true;
        Compressable.transform.localPosition = Compressable.transform.localPosition - new Vector3(0, offset, 0);
        OnButtonPressed();
    }
    void OnRelease()
    {
        isPressed = false;
        Compressable.transform.localPosition = Compressable.transform.localPosition + new Vector3(0, offset, 0);
        OnButtonReleased();
    }
    void OnButtonPressed()
    {
        DoorOpen(door);
        if (otherDoor != null)
        {
            DoorOpen(otherDoor);
        }
    }
    void OnButtonReleased()
    {
        DoorClose(door);
        if (otherDoor != null)
        {
            DoorClose(otherDoor);
        }
    }
    void DoorOpen(Door Door)
    {
        Door.open = true;
        Door.Open();
    }
    void DoorClose(Door Door)
    {
        Door.open = false;
        Door.Close();
    }
}
