using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Button testBtn;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private Slider powerBar;
    [SerializeField]
    private float maxPower = 100;
    public float currentPower = 0;

    private bool isSetDir = false;
    private bool isSetPower = false;
    private bool isShoot = false;

    [HideInInspector]
    public Vector2 v2;
    [HideInInspector]
    public float aimAngle;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        testBtn.GetComponent<Button>().interactable = false;
        StartCoroutine(activateBtn());
    }

    private void Update()
    {
        if (isSetDir)
        {
            Crosshair.gameObject.SetActive(true);
            Crosshair.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(aimAngle, 90, 180));
            FindAngle();
        }

        if (isSetDir && Input.GetMouseButtonDown(0))
        {
            Debug.Log($"마우스 클릭 {isSetDir} {Time.frameCount.ToString()}");
            isSetPower = true;
            isSetDir = false;
            testBtn.GetComponent<Button>().interactable = false;
        }

        if (isSetPower && Input.GetMouseButton(0))
        {
            powerBar.gameObject.SetActive(true);
            currentPower += Time.deltaTime * 100;
            if (currentPower > maxPower + 5)
                currentPower = 0;
            powerBar.value = currentPower / maxPower;
            isShoot = true;
        }

        if (isShoot && Input.GetMouseButtonUp(0))
        {
            isSetPower = false;
            Debug.Log("발사");
            anim.SetTrigger("isShoot");
            isShoot = false;
            // 발사 로직
            ProjectileManager.instance.Shoot();
        }
    }

    public void SettingDir()
    {
        Debug.Log($"마우스 버튼 다운 {Input.GetMouseButtonDown(0)} 프레임카운트 {Time.frameCount}");
        if (isSetDir == false)
            isSetDir = true;
        else
            isSetDir = false;
    }

    public void FindAngle()
    {
        v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Crosshair.gameObject.transform.position;
        aimAngle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
        if (-180 < aimAngle && aimAngle < 0)
            aimAngle = 180;
        if (0 < aimAngle && aimAngle < 90)
            aimAngle = 90;
    }

    IEnumerator activateBtn()
    {
        yield return new WaitForSecondsRealtime(2);
        testBtn.GetComponent<Button>().interactable = true;
    }
}
