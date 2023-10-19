using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

    [SerializeField] public Sprite healthPotionSprite;
    [SerializeField] public Sprite doubleAmmoSprite;
    [SerializeField] private List<Image> itemSlotImage;

    private ItemType[] itemTypes;


    private int currentItemSlot;    // ���� ������ ����
    private int maxSlots;           // ������ ���� ĭ




    // Start is called before the first frame update
    void Start()
    {
        openWeaponSlot.onClick.AddListener(OpenSlot_Weapon);
        openItemSlot.onClick.AddListener(OpenSlot_Item);
        weaponPanel.SetActive(true);
        itemPanel.SetActive(false);
        weaponTitle.gameObject.SetActive(true);
        itemTitle.gameObject.SetActive(false);

        currentItemSlot = 0;
        maxSlots = 5;

        itemTypes = new ItemType[maxSlots];

        for (int i = 0; i < maxSlots; i++)
        {
            itemTypes[i] = (ItemType)Random.Range(1, 3);
        }

        foreach (Button itemSlotButton in itemSlots)
        {
            itemSlotButton.interactable = false;
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
            ONDoubleUsed();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnHealUsed();
        }
    }

    public void ActivateItemSlot()
    {
        if (currentItemSlot < maxSlots)
        {
            itemSlots[currentItemSlot].interactable = true;
            ItemType curItem = itemTypes[currentItemSlot];
            currentItemSlot++;
        }
    }

    public void DeactivateItemSlot()
    {
        if (currentItemSlot > 0)
        {
            currentItemSlot--;
            itemSlots[currentItemSlot].interactable = false;
        }
    }

    public void OnItemAcquired()
    {
        ActivateItemSlot();
        if (currentItemSlot > 0)
        {
            ItemType curItem = itemTypes[currentItemSlot - 1];

            // ���� �ε����� ���� ������ �̹��� ����
            if (itemSlotImage != null)
            {
                Sprite itemSprite = null;
                if (currentItemSlot >= 1 && currentItemSlot <= 3)
                {
                    // ���� �ε��� 1~3�� ���� ���� ������ �̹����� ����
                    itemSprite = doubleAmmoSprite;
                }
                else if (currentItemSlot >= 4 && currentItemSlot <= 5)
                {
                    // ���� �ε��� 4~5�� ���� ���� ������ �̹����� ����
                    itemSprite = healthPotionSprite;
                }

                if (itemSprite != null)
                {
                    itemSlotImage[currentItemSlot - 1].sprite = itemSprite;
                }
            }
        }
    }

    public void OnHealUsed()
    {
        if (currentItemSlot >= 4 && currentItemSlot <= 5)
        {
            
            itemSlotImage[currentItemSlot - 1].sprite = null;
        }
        DeactivateItemSlot();
    }

    public void ONDoubleUsed()
    {
        if (currentItemSlot >= 1 && currentItemSlot <= 3)
        {
            
            itemSlotImage[currentItemSlot - 1].sprite = null;
        }
        DeactivateItemSlot();
    }
}
