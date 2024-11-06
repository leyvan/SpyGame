using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InspectObjectUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI overHeadText;

    public void ShowOverHeadText(bool enabled)
    {
        overHeadText.gameObject.SetActive(enabled);
    }
}
