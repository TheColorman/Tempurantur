using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    void Awake() {
        gameObject.SetActive(false);
    }

    public void OnEnable() {
        gameObject.SetActive(true);
    }

    public void OnDisable() {
        gameObject.SetActive(false);
    }
}
