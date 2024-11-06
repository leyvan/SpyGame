using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtil : MonoBehaviour
{
    [SerializeField] private Transform cameraInspectPosition;

    public Transform GetCameraInspectPosition(){return cameraInspectPosition;}
}
