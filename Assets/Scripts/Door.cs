using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float offsetMax = 1;
    public float openSpeed = 5f;
    GameObject door;
    Vector3 startPos;
    public bool open = false;
    public AudioSource audioSource;
    public bool FullyOpen = false;
    public bool StartOpen = false;
    public BoxCollider boxCollider;
    public bool Animating = false;
    public virtual void Start()
    {
        door = transform.Find("Door").gameObject;
        startPos = door.transform.localPosition;
        audioSource = GetComponent<AudioSource>();
        boxCollider = door.GetComponent<BoxCollider>();
        if (StartOpen)
        {
            Open();
        }
    }
    public virtual void Open()
    {
        open = true;
        boxCollider.enabled = !boxCollider.enabled;
        StartCoroutine(OpenDoor());
        audioSource.Play();
    }
    public void Close()
    {
        open = false;
        boxCollider.enabled = !boxCollider.enabled;
        StartCoroutine(CloseDoor());
        audioSource.Play();
    }

    IEnumerator OpenDoor()
    {
        if (FullyOpen == true)
        {
            yield return new WaitUntil(() => FullyOpen == false);
        }
        Animating = true;
        while ((startPos.z + offsetMax) - door.transform.localPosition.z > 0.01f) // while difference between current and target is more than 0.1f (because Lerp never reaches target value)
        {
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, new Vector3(startPos.x, startPos.y, startPos.z + offsetMax), 0.1f);
            yield return null;
        }
        FullyOpen = true;
        Animating = false;
    }
    IEnumerator CloseDoor()
    {
        if (FullyOpen == false)
        {
            yield return new WaitUntil(() => FullyOpen == true);
        }
        Animating = true;
        while (door.transform.localPosition.z - startPos.z > 0.01f)
        {
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, startPos, 0.1f);
            yield return null;
        }
        FullyOpen = false;
        Animating = false;
    }

}
