using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {
    Camera cam;
    public float sensitivity = 1.0f;
    public float minAngle = 80.0f;
    public float maxAngle = -80.0f;
    public float startAngle = 0.0f;
    float camAngle = 0.0f;
    public bool hideMouse = true;

    void Start() {
        cam = Camera.main;
        // Set camera start angle
        cam.transform.localEulerAngles = new Vector3(startAngle, 0, 0);
        if (hideMouse) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
	void Update () {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        // Clamp angle
        camAngle -= mouseY * sensitivity;
        camAngle = Mathf.Clamp(camAngle, minAngle, maxAngle);
        // Rotate camera
        cam.transform.localEulerAngles = new Vector3(camAngle, 0, 0);
        print(camAngle);
        // Rotate player
        transform.Rotate(0, mouseX * sensitivity, 0);
    }
}