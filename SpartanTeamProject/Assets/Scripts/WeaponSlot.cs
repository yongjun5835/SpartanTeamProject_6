using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSlot : MonoBehaviour
{
    public Image[] ItemImg;
    private void Awake()
    {
        ItemImg = gameObject.GetComponentsInChildren<Image>();
    }

    private void OnEnable()
    {
        for(int i = 1; i < ItemImg.Length; i++)
        {
            ItemImg[i].sprite = DataManager.Instance.Weapon[i].WeaponImg;
        }
        //ItemImg.sprite = DataManager.Instance.Weapon[0].WeaponImg;
    }
}
