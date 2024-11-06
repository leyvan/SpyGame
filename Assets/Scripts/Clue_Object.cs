using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue_Object : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private InspectObjectUI inspectUI;
    
    private bool objectInspect = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inspectUI.ShowOverHeadText(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inspectUI.ShowOverHeadText(false);
        }
    }

    private void Update()
    {
        if(objectInspect == false)
            inspectUI.transform.rotation = mainCam.transform.rotation;

        if (Input.GetButtonDown("Submit") && objectInspect == false)
        {
            objectInspect = true;
            MoveObjectToInspectPosition();
        }

        if (Input.GetButtonDown("Cancel") && objectInspect == true)
        {
            objectInspect = false;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = true;
            inspectUI.ShowOverHeadText(true);
        }
    }

    private void MoveObjectToInspectPosition()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        inspectUI.ShowOverHeadText(false);
        GetComponent<BoxCollider>().enabled = false;
        transform.parent = mainCam.GetComponent<CameraUtil>().GetCameraInspectPosition();
    }
}
