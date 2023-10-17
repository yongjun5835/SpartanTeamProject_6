using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_OutOfCamera : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_distance;

    [SerializeField] private Transform curTarget;
    [SerializeField] private bool isChasing;
    
    private RectTransform panelTransform;
    private Vector2 canvasSize;

    private void Start()
    {
        panelTransform = GetComponent<RectTransform>();
        canvasSize = GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta;
    }

    private void Update()
    {
        if (isChasing) 
        {
            ChaseTarget();
            ClampPanelToCanvas();
            SetDistance();
        }
    }

    private void ChaseTarget()
    {
        Vector2 targetScreenPosition = Camera.main.WorldToScreenPoint(curTarget.localPosition - Camera.main.transform.position);
        panelTransform.anchoredPosition = targetScreenPosition;
    }
    public void StartChasing(Transform target)
    {
        curTarget = target;
        isChasing = true;
    }

    public void StopChasing()
    {
        curTarget = null;
        isChasing = false;
    }

    private void ClampPanelToCanvas()
    {
        Vector2 clampedPosition = panelTransform.anchoredPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -canvasSize.x*0.5f, canvasSize.x*0.5f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -canvasSize.y*0.5f, canvasSize.y*0.5f);
        panelTransform.anchoredPosition = clampedPosition;
    }

    private void SetDistance()
    {
        //float distance = Vector3.Distance(curTarget.transform.position, ;

    }
}