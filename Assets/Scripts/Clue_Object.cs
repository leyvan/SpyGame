using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Clue_Object : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private InspectObjectUI inspectUI;
    
    [SerializeField] private Collider physicsCollider;
    [SerializeField] private Rigidbody rigidbody;
    
    private bool objectInspect = false;
    private bool canInspect = false;
    private bool isObjectRendered = false;
    
    [SerializeField] private Renderer objectRenderer;

    private bool useOverworldUI;

    private void Awake()
    {
        objectRenderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !objectInspect)
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

        if (Input.GetButtonDown("Fire2") && objectInspect == true)
        {
            GetComponent<Rotatable>().ToggleRotating(true);
        }

        if (Input.GetButtonUp("Fire2") && objectInspect == true)
        {
            GetComponent<Rotatable>().ToggleRotating(false);
        }

        if (Input.GetButtonDown("Drop") && objectInspect == true)
        {
            objectInspect = false;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = true;
            inspectUI.ShowOverHeadText(true);
            
            GameEvents.Instance.LockCamera(true);
            GameEvents.Instance.LockMovement(true);
            Cursor.lockState = CursorLockMode.Locked;
            
            rigidbody.isKinematic = false;
            physicsCollider.isTrigger = false; 
            
            GetComponent<Rotatable>().ToggleRotating(false);
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
        
        rigidbody.isKinematic = true;
        physicsCollider.isTrigger = true;

        Cursor.lockState = CursorLockMode.None;
        GameEvents.Instance.LockCamera(false);
        GameEvents.Instance.LockMovement(false);
        //GetComponent<Rotatable>().ToggleRotating(true);
    }
}
