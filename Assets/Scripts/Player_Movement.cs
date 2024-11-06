using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Player_Movement : MonoBehaviour
{
    
    private Vector3 inputDirection;
    private Vector3 moveDirection;
    
    private float walkSpeed = 5f;
    private float runSpeed = 9f;
    [SerializeField] private float moveSpeed;

    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;
    
    CharacterController pCharacterController;
    public Transform playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out pCharacterController);

        Cursor.lockState = CursorLockMode.Locked;
        
        playerCamera = Camera.main.transform;
        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        if (inputDirection.magnitude >= 0.1f)
        {
            ApplyMovement();
        }
    }

    private void CheckInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        inputDirection.x = horizontal;
        inputDirection.z = vertical;
    }
    
    
    private void ApplyMovement()
    {
        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
        moveDirection = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward;
        pCharacterController.Move( moveDirection.normalized * (moveSpeed * Time.deltaTime));
    }
}
