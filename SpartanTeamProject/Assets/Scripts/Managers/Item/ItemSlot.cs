using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Button openWeaponSlot;
    [SerializeField] private Button openItemSlot;
    [SerializeField] private GameObject weaponPanel;
    [SerializeField] private GameObject itemPanel;

    [SerializeField] private List<Button> weaponSlots;
    [SerializeField] private List<Button> itemSlots;

    [SerializeField] private TextMeshProUGUI weaponTitle;
    [SerializeField] private TextMeshProUGUI itemTitle;


    private int currentWeaponSlot = 0;
    private int currentItemSlot = 0;
    private int maxSlots = 5;
    private int selectedWeaponIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        openWeaponSlot.onClick.AddListener(OpenSlot_Weapon);
        openItemSlot.onClick.AddListener(OpenSlot_Item);
        weaponPanel.SetActive(false);
        itemPanel.SetActive(false);
        weaponTitle.gameObject.SetActive(true);
        itemTitle.gameObject.SetActive(false);



        for (int i = 0; i < maxSlots; i++)
        {
            weaponSlots[i].gameObject.SetActive(true);
            itemSlots[i].gameObject.SetActive(true);

            Color itemSlotColor = itemSlots[i].image.color;
            itemSlotColor.a = 0.1f;
            itemSlots[i].image.color = itemSlotColor;
        }

        // 초기 설정: 0번 슬롯 알파값을 1로, 나머지 슬롯 알파값을 0.5로 설정
        for (int i = 0; i < maxSlots; i++)
        {
            float alpha = (i == 0) ? 1.0f : 0.5f; // 0번 슬롯 알파값을 1로, 나머지 슬롯 알파값을 0.5로 설정
            SetSlotAlpha(i, alpha);
            int weaponIndex = i; // 현재 무기 슬롯의 인덱스를 저장
            weaponSlots[i].onClick.AddListener(() => SelectWeapon(weaponIndex));
        }

    }

    private void OpenSlot_Item()
    {
        itemPanel.SetActive(true);
        weaponPanel.SetActive(false);
        itemTitle.gameObject.SetActive(true);
        weaponTitle.gameObject.SetActive(false);
    }

    private void OpenSlot_Weapon()
    {
        weaponPanel.SetActive(true);
        itemPanel.SetActive(false);
        weaponTitle.gameObject.SetActive(true);
        itemTitle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponPanel.SetActive(true);
            itemPanel.SetActive(false);
            weaponTitle.gameObject.SetActive(true);
            itemTitle.gameObject.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponPanel.SetActive(false);
            itemPanel.SetActive(true);
            weaponTitle.gameObject.SetActive(false);
            itemTitle.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateSlots();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AcquireItem();
        }
    }
    // 아이템 슬릇 활성화
    public void ActivateSlots()
    {
        if (currentItemSlot < maxSlots)
        {

            Color itemSlotColor = itemSlots[currentItemSlot].image.color;
            itemSlotColor.a = 1.0f;
            itemSlots[currentItemSlot].image.color = itemSlotColor;

            currentItemSlot++;
        }
    }



    //아이템 사용 시 슬릇 비활성화
    public void UseItem()
    {

        if (currentItemSlot > 0)
        {

            // 가장 최근 아이템 슬롯을 비활성화하고 현재 아이템 슬롯 인덱스를 감소
            itemSlots[currentItemSlot - 1].gameObject.SetActive(false);
            currentItemSlot--;
        }
    }

    public void AcquireItem()
    {
        if (currentItemSlot < maxSlots)
        {
            itemSlots[currentItemSlot].gameObject.SetActive(true);
            currentItemSlot++;
        }
    }

    private void SetSlotAlpha(int slotIndex, float alpha)
    {
        Color slotColor = weaponSlots[slotIndex].image.color;
        slotColor.a = alpha;
        weaponSlots[slotIndex].image.color = slotColor;
    }

    private void SelectWeapon(int weaponIndex)
    {
        // 장착 중인 무기의 슬롯 알파값을 0.5로 설정
        SetSlotAlpha(selectedWeaponIndex, 0.5f);

        // 선택한 무기의 슬롯 알파값을 1로 설정
        SetSlotAlpha(weaponIndex, 1.0f);

        // 선택한 무기를 장착
        EquipWeapon(weaponIndex);

        // 선택한 무기의 인덱스를 업데이트
        selectedWeaponIndex = weaponIndex;
    }

    private void EquipWeapon(int weaponIndex)
    {

    }
}
