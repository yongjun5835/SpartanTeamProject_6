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



    private int currentItemSlot;    // Ω√¿€ æ∆¿Ã≈€ ΩΩ∏©
    private int maxSlots;           // æ∆¿Ã≈€ ΩΩ∏© ƒ≠
    


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
            OnItemAcquired();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnItemUsed();
        }
    }

    public void ActivateItemSlot()
    {
        if (currentItemSlot < maxSlots)
        {
            itemSlots[currentItemSlot].interactable = true;
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
    }

    public void OnItemUsed()
    {
        DeactivateItemSlot();
    }
}
