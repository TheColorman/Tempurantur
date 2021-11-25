using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    GameObject door;
    bool open = false;
    float offset = 0;
    float offsetMax = 1;
    float openSpeed = 5f;
    public GameObject otherDoor;
    Vector3 doorPos;
    Vector3 doorPosOther;
    void Start() {
        door = transform.parent.Find("Door").gameObject;
        doorPos = door.transform.localPosition;
        doorPosOther = otherDoor != null ? otherDoor.transform.localPosition : doorPos;
    }
    public override void OnFocus()
    {
    }
    public override void OnLooseFocus()
    {
    }
    public override void OnInteract()
    {
        offset = 0;
        open = !open;
        if (open)
        {
            StartCoroutine(OpenDoor());
        } else
        {
            Debug.Log("Closing door");
            StartCoroutine(CloseDoor());
        }
    }
    IEnumerator OpenDoor()
    {
        while (offset < offsetMax)
        {
            offset += Time.deltaTime * openSpeed;
            door.transform.localPosition = new Vector3(doorPos.x, doorPos.y, doorPos.z + offset);
            if (otherDoor != null)
            {
                otherDoor.transform.localPosition = new Vector3(doorPosOther.x, doorPosOther.y, doorPosOther.z + offset);
            }
            yield return null;
        }
    }
    IEnumerator CloseDoor()
    {
        while (offset > offsetMax * -1)
        {
            offset -= Time.deltaTime * openSpeed;
            door.transform.localPosition = new Vector3(doorPos.x, doorPos.y, doorPos.z + offsetMax + offset);
            if (otherDoor != null)
            {
                otherDoor.transform.localPosition = new Vector3(doorPosOther.x, doorPosOther.y, doorPosOther.z + offsetMax + offset);
            }
            yield return null;
        }
    }
}
