using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private MenuUI menuUI;
    [SerializeField]private Button closePauseScreenButton;
    
    
    private void Start()
    {
        closePauseScreenButton.onClick.AddListener(ClosePauseScreen);
    }

    private void ClosePauseScreen()
    {
        menuUI.ToggleMenu();
    }
}
