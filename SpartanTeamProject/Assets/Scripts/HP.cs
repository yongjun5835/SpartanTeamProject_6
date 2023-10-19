using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class HPBar : MonoBehaviour
{
    public Transform target; // 캐릭터의 머리 위치(Transform)
    public RectTransform hpBar; // HP바(UI 요소)의 RectTransform
    public float offset; // HP바가 캐릭터 머리 위로 올라가는 위치 조정값
    public float smoothing = 5f; // HP바 이동을 부드럽게 하기 위한 값

    private float initialBarWidth;

    private void Start()
    {
        initialBarWidth = hpBar.sizeDelta.x;
    }

    private void Update()
    {
        if (target == null)
        {
            // 대상(캐릭터)이 없으면 HP바 비활성화
            hpBar.gameObject.SetActive(false);
            return;
        }

        // HP바 활성화
        hpBar.gameObject.SetActive(true);

        // HP바 위치 업데이트
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        hpBar.position = screenPos + Vector3.up * offset;

        // HP바 크기 업데이트 (HP값에 따라)
        float normalizedHP = Mathf.Clamp01(target.GetComponent<Player>().curHealth / target.GetComponent<Player>().maxHealth);
        hpBar.sizeDelta = new Vector2(initialBarWidth * normalizedHP, hpBar.sizeDelta.y);

        // HP바 부드럽게 이동
        Vector3 desiredPosition = screenPos + Vector3.up * offset;
        hpBar.position = Vector3.Lerp(hpBar.position, desiredPosition, smoothing * Time.deltaTime);
    }
}
