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
        if (Door.open)
        {
            Door.Close();
        } else
        {
            Door.Open();
        }
    }
}
