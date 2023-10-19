using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class HPBar : MonoBehaviour
{
    public Transform target; // ĳ������ �Ӹ� ��ġ(Transform)
    public RectTransform hpBar; // HP��(UI ���)�� RectTransform
    public float offset; // HP�ٰ� ĳ���� �Ӹ� ���� �ö󰡴� ��ġ ������
    public float smoothing = 5f; // HP�� �̵��� �ε巴�� �ϱ� ���� ��

    private float initialBarWidth;

    private void Start()
    {
        initialBarWidth = hpBar.sizeDelta.x;
    }

    private void Update()
    {
        if (target == null)
        {
            // ���(ĳ����)�� ������ HP�� ��Ȱ��ȭ
            hpBar.gameObject.SetActive(false);
            return;
        }

        // HP�� Ȱ��ȭ
        hpBar.gameObject.SetActive(true);

        // HP�� ��ġ ������Ʈ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        hpBar.position = screenPos + Vector3.up * offset;

        // HP�� ũ�� ������Ʈ (HP���� ����)
        float normalizedHP = Mathf.Clamp01(target.GetComponent<Player>().curHealth / target.GetComponent<Player>().maxHealth);
        hpBar.sizeDelta = new Vector2(initialBarWidth * normalizedHP, hpBar.sizeDelta.y);

        // HP�� �ε巴�� �̵�
        Vector3 desiredPosition = screenPos + Vector3.up * offset;
        hpBar.position = Vector3.Lerp(hpBar.position, desiredPosition, smoothing * Time.deltaTime);
    }
}
