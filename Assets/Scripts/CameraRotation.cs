using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensibility = 100f;
    public float minAngle = -90f, maxAngle = 90f;

    public Transform transformPlayer;

    float cameraRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        cameraRotation -= mouseY;
        cameraRotation = Mathf.Clamp(cameraRotation, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);

        transformPlayer.Rotate(Vector3.up * mouseX);
    }
}
