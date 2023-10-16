using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum CameraModes { Computer, Mobile }
public class CameraController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [Header("Settings")]
    [SerializeField] private CameraModes cameraModes;
    [SerializeField, Range(0f, 0.5f)] private float smoothTime;

    [Header("Map")]
    [SerializeField] private SpriteRenderer map;

    [Header("Inspector (dont need to connect)")]
    [SerializeField] private Transform curTarget;

    private Bounds cameraBounds;
    public Camera camera;
    private Vector3 refVector = Vector3.zero;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }
    void Start()
    {
        //gameManager = GameManager.Instance;
        ChangeMap();
    }


    private void Update()
    {
        ChaseTarget();
    }

    private void LateUpdate()
    {
        CheckBounds();
    }

    public void ChangeMap()
    {
        if (map != null)
        {
            cameraBounds = map.bounds;
        }
    }
    public void CheckBounds()
    {
        if (cameraBounds == null) return;

        Vector3 curPosition = camera.transform.position;
        float halfOrthoSize = camera.orthographicSize;
        float aspectRatio = camera.aspect;

        curPosition.x = Mathf.Clamp(curPosition.x, cameraBounds.min.x + halfOrthoSize * aspectRatio, cameraBounds.max.x - halfOrthoSize * aspectRatio);
        curPosition.y = Mathf.Clamp(curPosition.y, cameraBounds.min.y + halfOrthoSize, cameraBounds.max.y - halfOrthoSize);

        camera.transform.position = curPosition;
    }

    public void SetTarget(Transform target)
    {
        if( target == null) return;
        curTarget = target;
    }

    public void ChaseTarget()
    {
        if (curTarget == null) return;

        Vector3 target = curTarget.position;
        target.z = -10f;

        transform.position = target;
    }
}
