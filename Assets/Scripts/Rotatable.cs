using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    private bool _isRotating = false;
    private bool canRotate = false;

    private float rotateSpeed = 90;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && canRotate && !_isRotating)
        {
            _isRotating = true;
        }

        if (Input.GetKeyUp("r"))
        {
            _isRotating = false;
        }

        if (_isRotating)
        {
            transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0f, 0f));
        }
            
    }

    public void StartRotating()
    {
        canRotate = true;
    }
}
