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
    public Fade fade;
    public CanvasScript popupScript;
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
        // StartCoroutine(OpenDoor()); // so like only do this if we are gonna have the door open
        fade.SetColor(Color.black);
        fade.FadeIn();
        popupScript.SetText("You escaped.");
        popupScript.OnEnable();
        StartCoroutine(CloseGame(5f));
    }
    IEnumerator CloseGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
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
