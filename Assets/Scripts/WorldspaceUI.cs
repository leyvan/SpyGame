using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class WorldspaceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI worldSpaceTimer;
    
    public void UpdateTimerUI(float time)
    {
        worldSpaceTimer.text = math.floor(time/60) + ":" + (time % 60);
    }
}
