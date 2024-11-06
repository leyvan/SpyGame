using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameTimer gameTimer;
    private bool countdownStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !countdownStarted)
        {
            gameTimer = new GameTimer(this, 900, 0);
        }
    }
}
