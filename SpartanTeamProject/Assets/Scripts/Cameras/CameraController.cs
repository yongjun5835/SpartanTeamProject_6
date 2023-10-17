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

    // 여기도 임시
    [SerializeField] private Transform player;
    //
    [SerializeField] private Transform freeCameraTarget;
    [SerializeField] private UI_OutOfCamera ui_OutOfCamera;
    private bool isTargetOutOfCamera;
    private bool isFreeCameraMode;

    public float scrollSpeed = 30.0f;
    public float maxSize = 10.0f;
    public float minSize = 5.0f;

    public float moveSpeed = 10.0f;

    float wheelScrollValue;

    public Camera mainCamera;
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
        curTarget = target;
    }

    public void ToggleCameraMode()
    {
        isFreeCameraMode = !isFreeCameraMode;
        if (isFreeCameraMode && !(Cursor.lockState == CursorLockMode.Locked))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Vector2 position = Camera.main.transform.position;
            freeCameraTarget.position = position;
            virtualCamera.m_Follow = freeCameraTarget;
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
        freeCameraTarget.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MouseWheelCheck()
    {
        wheelScrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (wheelScrollValue != 0)
        {
            float newSize = virtualCamera.m_Lens.OrthographicSize;
            newSize += wheelScrollValue > 0 ? -1f : 1f;
            newSize = Mathf.Clamp(newSize, minSize, maxSize);
            virtualCamera.m_Lens.OrthographicSize = newSize;
        }
    }
}
