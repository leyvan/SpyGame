using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerCountDown;

    public void UpdateTimerUI(float time)
    {
        timerCountDown.text = math.floor(time / 60) + ":" + (time % 60);
    }
}
