using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CubeButton : MonoBehaviour
{
    GameObject Compressable;
    bool isPressed = false;
    public float offset = 5f;
    void Awake() {
        Compressable = gameObject.transform.Find("Stm_button02").gameObject;
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
    public abstract void OnButtonPressed();
    public abstract void OnButtonReleased();
}
