using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer
{
    private float _timeToStart;
    private float _timeToEnd;
    
    private float _timeElapsed;
    
    
    
    public GameTimer(MonoBehaviour myMonoBehaviour, float timeToStart, float timeToEnd)
    {
        _timeToStart = timeToStart;
        _timeToEnd = timeToEnd;

        _timeElapsed = timeToStart;

        myMonoBehaviour.StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (_timeElapsed > _timeToEnd)
        {
            _timeElapsed -= 1;
            Debug.Log("TIMER: " + _timeElapsed);
            yield return new WaitForSeconds(1);
        }
        
        
    }
}
