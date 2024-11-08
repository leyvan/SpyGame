using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameTimer gameTimer;
    private bool countdownStarted;

    [SerializeField] private GameUI gameUI;
    [SerializeField] private WorldspaceUI worldspaceUI;

    void Start()
    {
        StartGame();    
    }

    private void StartGame()
    {
        gameTimer = new GameTimer(this, 900, 0);
        countdownStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (countdownStarted)
        {
            gameUI.UpdateTimerUI(gameTimer.GetTimeElapsed());
            worldspaceUI.UpdateTimerUI(gameTimer.GetTimeElapsed());
        }
    }
}
