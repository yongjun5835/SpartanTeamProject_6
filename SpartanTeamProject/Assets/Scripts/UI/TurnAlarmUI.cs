using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnAlarmUI : MonoBehaviour
{
    [SerializeField] private Text turnAlarmText;
    [SerializeField, Range(0.3f,1f)] private float alarmTime;

    private void Start()
    {
        gameObject.SetActive(false);        
    }


    public void SetText(string text)
    {
        turnAlarmText.text = text;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(CloseAfterSeconds(alarmTime));
    }
    public IEnumerator CloseAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
