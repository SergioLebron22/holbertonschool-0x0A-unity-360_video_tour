using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 5f;
    public float maxYAngle = 80f;
    public float minYAngle = -80f;

    private Vector2 currentRotation;

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = -Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = -Input.GetAxis("Mouse Y") * sensitivity;

            currentRotation.x += mouseX;
            currentRotation.y -= mouseY;
            currentRotation.y = Mathf.Clamp(currentRotation.y, minYAngle, maxYAngle);

            transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        }
    }
}
