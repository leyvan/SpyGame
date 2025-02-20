using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        try
        {
            Cursor.lockState = pauseMenuUI.activeSelf ? CursorLockMode.Locked : CursorLockMode.None;
            GameEvents.Instance.Pause(!pauseMenuUI.activeSelf);
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
