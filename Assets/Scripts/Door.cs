using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float offset = 0;
    float offsetMax = 1;
    float openSpeed = 5f;
    GameObject door;
    Vector3 doorPos;
    public bool open = false;
    void Start()
    {
        door = transform.parent.Find("Door").gameObject;
        doorPos = door.transform.localPosition;
    }
    public void Open()
    {
        offset = 0;
        open = true;
        StartCoroutine(OpenDoor());
    }
    public void Close()
    {
        offset = 0;
        open = false;
        StartCoroutine(CloseDoor());
    }

    IEnumerator OpenDoor()
    {
        while (offset < offsetMax)
        {
            offset += Time.deltaTime * openSpeed;
            door.transform.localPosition = new Vector3(doorPos.x, doorPos.y, doorPos.z + offset);
            yield return null;
        }
    }
    IEnumerator CloseDoor()
    {
        while (offset > offsetMax * -1)
        {
            offset -= Time.deltaTime * openSpeed;
            door.transform.localPosition = new Vector3(doorPos.x, doorPos.y, doorPos.z + offsetMax + offset);
            yield return null;
        }
    }

}
