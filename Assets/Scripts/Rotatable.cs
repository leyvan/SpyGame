using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    private bool _isRotating = false;
    private bool canRotate = false;

    private float rotateSpeed = 90;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Update() {
        if (canRotate) {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(v, h, 0);
        }
    }
    public void ToggleRotating(bool shouldRotate)
    {
        canRotate = shouldRotate;
    }
}
