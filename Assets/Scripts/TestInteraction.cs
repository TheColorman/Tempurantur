using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : Interactable
{
    public override void OnInteract()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
    public override void OnFocus()
    {
        Debug.Log("Focused on " + gameObject.name);
    }
    public override void OnLooseFocus()
    {
        Debug.Log("Loose focus on " + gameObject.name);
    }
}
