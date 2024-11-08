using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Clue_Object : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private InspectObjectUI inspectUI;
    
    private bool objectInspect = false;
    private bool canInspect = false;
    private bool isObjectRendered = false;
    
    [SerializeField] private Renderer objectRenderer;
    

    private void Awake()
    {
        objectRenderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canInspect = true;
            inspectUI.ShowOverHeadText(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInspect = false;
            inspectUI.ShowOverHeadText(false);
        }
    }

    private void Update()
    {
        if(objectInspect == false)
            inspectUI.transform.rotation = mainCam.transform.rotation;

        if (Input.GetButtonDown("Interact") && objectInspect == false && objectRenderer.isVisible && canInspect)
        {
            objectInspect = true;
            MoveObjectToInspectPosition();
        }

        if (Input.GetButtonDown("Drop") && objectInspect == true)
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
        transform.position = transform.parent.position;
        
        transform.rotation = Quaternion.identity;
        
        GetComponent<Rotatable>().StartRotating();
    }
}
