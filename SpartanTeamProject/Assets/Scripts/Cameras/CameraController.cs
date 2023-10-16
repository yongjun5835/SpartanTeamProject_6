using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum CameraModes { Computer, Mobile }
public class CameraController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private CinemachineConfiner confiner;

    [SerializeField] private TextMeshProUGUI bulletDistance;
    public Camera mainCamera;
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        confiner = GetComponent<CinemachineConfiner>();
        mainCamera = Camera.main;
    }

    public void ChangeBounds(Collider2D collider)
    {
        if (collider != null)
        {
            confiner.m_BoundingShape2D = collider;
        }
    }

    public void SetTarget(Transform target)
    {
        if (target == null) return;
        virtualCamera.m_Follow = target;
    }
}
