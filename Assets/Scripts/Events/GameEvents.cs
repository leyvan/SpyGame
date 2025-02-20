using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private static GameEvents _instance;
    public static GameEvents Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameEvents>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public event Action<bool> onPause;
    public void Pause(bool pause)
    {
        onPause?.Invoke(pause);
    }
    
    public event Action<bool> onCameraLock;
    public void LockCamera(bool lockState)
    {
        onCameraLock?.Invoke(lockState);
    }
    
    public event Action<bool> onMovementLock;
    public void LockMovement(bool lockState)
    {
        onMovementLock?.Invoke(lockState);
    }
}
