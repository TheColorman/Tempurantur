using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    Door door;
    public Door otherDoor;
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
        door.open = !door.open;
        if (Door.open)
        {
            Door.Close();
        } else
        {
            Door.Open();
        }
    }
}
