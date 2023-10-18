using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnAlarmUI : MonoBehaviour
{
    [SerializeField] private Text turnAlarmText;

    public void SetTurn(string text)
    {
        turnAlarmText.text = text;
    }

    public void Show(float time)
    {
        
    }

}
