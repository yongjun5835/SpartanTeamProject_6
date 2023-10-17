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
    [SerializeField] private Transform curTarget;

    [Header("Need to connect")]
    [SerializeField] private Transform player;

    // 작업중
    // [SerializeField] private UI_OutOfCamera ui_OutOfCamera;
    [Header("Settings")]
    public float zoomMaxSize = 10.0f;
    public float zoomMinSize = 5.0f;
    public float freeCameraMoveSpeed = 10.0f;
    public Camera mainCamera;
    private bool isTargetOutOfCamera;
    private bool isFreeCameraMode;
    private Bounds bounds;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        confiner = GetComponent<CinemachineConfiner>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        GameManager.Instance.cameraController = this;
        // 임시임
        SetTarget(player);
        MapChange(confiner.m_BoundingShape2D);
        // 여기까지
    }

    private void Update()
    {
        if (isTargetOutOfCamera)
        {
            //ui_OutOfCamera.SetTarget(curTarget);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ToggleCameraMode();
        }
        if (isFreeCameraMode)
        {
            MoveFreeCamera();
        }
        MouseWheelCheck();
    }
    public void MapChange(Collider2D map_PolygonCollider)
    {
        if (map_PolygonCollider != null)
        {
            confiner.m_BoundingShape2D = map_PolygonCollider;
            bounds = map_PolygonCollider.bounds;
        }
    }

    public void SetTarget(Transform target)
    {
        if (target == null) return;
        virtualCamera.m_Follow = target;
        curTarget = target;
    }

    public void ToggleCameraMode()
    {
        isFreeCameraMode = !isFreeCameraMode;
        if (isFreeCameraMode && !(Cursor.lockState == CursorLockMode.Locked))
        {
            Cursor.lockState = CursorLockMode.Locked;
            virtualCamera.m_Follow = null;
            virtualCamera.transform.position = Camera.main.transform.position;
        }
        if (!isFreeCameraMode && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            virtualCamera.m_Follow = curTarget;
        }
    }

    public void MoveFreeCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 moveDirection = new Vector3(mouseX, mouseY, 0);
        Vector3 newPosition = virtualCamera.transform.position + moveDirection * freeCameraMoveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, bounds.min.x, bounds.max.x);
        newPosition.y = Mathf.Clamp(newPosition.y, bounds.min.y, bounds.max.y);

        virtualCamera.transform.position = newPosition;
    }

    public void MouseWheelCheck()
    {
        float wheelScrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (wheelScrollValue != 0)
        {
            float newSize = virtualCamera.m_Lens.OrthographicSize;
            newSize += wheelScrollValue > 0 ? -1f : 1f;
            newSize = Mathf.Clamp(newSize, zoomMinSize, zoomMaxSize);
            virtualCamera.m_Lens.OrthographicSize = newSize;
        }
    }
}
