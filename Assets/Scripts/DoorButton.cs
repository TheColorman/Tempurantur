using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    Door door;
    public Door otherDoor;
    void Start()
    {
        door = GetComponentInParent<Door>();
    }
    public override void OnFocus()
    {
    }
    public override void OnLooseFocus()
    {
    }
    public override void OnInteract()
    {
        DoorToggle(door);
        if (otherDoor != null)
        {
            DoorToggle(otherDoor);
        }
    }
    void DoorToggle(Door Door)
    {
        Door.open = !Door.open;
        if (Door.open)
        {
            Door.Open();
        } else
        {
            Door.Close();
        }
    }
}
