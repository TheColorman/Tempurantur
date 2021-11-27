using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorOpen : Door
{
    public GameObject left;
    public GameObject right;
    float offset = 0f;
    Vector3 leftPos;
    Vector3 rightPos;
    public override void Start()
    {
        leftPos = left.transform.localPosition;
        rightPos = right.transform.localPosition;
        audioSource = GetComponent<AudioSource>();
    }
    public override void Open()
    {
        boxCollider.enabled = !boxCollider.enabled;
        audioSource.Play();
        StartCoroutine(OpenDoor());
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
            left.transform.localPosition = new Vector3(leftPos.x, leftPos.y, leftPos.z + offset);
            right.transform.localPosition = new Vector3(rightPos.x, rightPos.y, rightPos.z - offset);
            yield return null;
        }
        FullyOpen = true;
    }

}
