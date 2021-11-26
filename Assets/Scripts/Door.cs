using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float offset = 0;
    public float offsetMax = 1;
    float openSpeed = 5f;
    GameObject door;
    Vector3 doorPos;
    public bool open = false;
    AudioSource audioSource;
    public bool FullyOpen = false;
    public bool StartOpen = false;
    void Start()
    {
        door = transform.Find("Door").gameObject;
        doorPos = door.transform.localPosition;
        audioSource = GetComponent<AudioSource>();
        if (StartOpen)
        {
            Open();
        }
    }
    public void Open()
    {
        offset = 0;
        open = true;
        StartCoroutine(OpenDoor());
        audioSource.Play();
    }
    public void Close()
    {
        offset = 0;
        open = false;
        StartCoroutine(CloseDoor());
        audioSource.Play();
    }

    IEnumerator OpenDoor()
    {
        if (FullyOpen == true)
        {
            yield return new WaitUntil(() => FullyOpen == false);
        }
        while (offset < offsetMax)
        {
            offset += Time.deltaTime * openSpeed;
            door.transform.localPosition = new Vector3(doorPos.x, doorPos.y, doorPos.z + offset);
            yield return null;
        }
        FullyOpen = true;
    }
    IEnumerator CloseDoor()
    {
        if (FullyOpen == false)
        {
            yield return new WaitUntil(() => FullyOpen == true);
        }
        while (offset > offsetMax * -1)
        {
            offset -= Time.deltaTime * openSpeed;
            door.transform.localPosition = new Vector3(doorPos.x, doorPos.y, doorPos.z + offsetMax + offset);
            yield return null;
        }
        FullyOpen = false;
    }

}
