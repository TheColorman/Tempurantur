using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void SetText(string newText) {
        // Get text child
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = newText;
    }
}
