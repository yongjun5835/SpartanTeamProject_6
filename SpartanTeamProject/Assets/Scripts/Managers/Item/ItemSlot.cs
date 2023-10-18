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

    [SerializeField] private Button weaponSlots;
    [SerializeField] private List<Button> itemSlots;

    [SerializeField] private TextMeshProUGUI weaponTitle;
    [SerializeField] private TextMeshProUGUI itemTitle;


    
    private int currentItemSlot = 0;
    private int maxSlots = 5;
    


    // Start is called before the first frame update
    void Start()
    {
        openWeaponSlot.onClick.AddListener(OpenSlot_Weapon);
        openItemSlot.onClick.AddListener(OpenSlot_Item);
        weaponPanel.SetActive(true);
        itemPanel.SetActive(false);
        weaponTitle.gameObject.SetActive(true);
        itemTitle.gameObject.SetActive(false);



        for (int i = 0; i < maxSlots; i++)
        {
            weaponSlots.gameObject.SetActive(true);
            itemSlots[i].gameObject.SetActive(true);

            Color itemSlotColor = itemSlots[i].image.color;
            itemSlotColor.a = 0.1f;
            itemSlots[i].image.color = itemSlotColor;
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

}
