using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSlot : MonoBehaviour
{
    public Image ItemImg;
    private void Awake()
    {
        ItemImg = gameObject.GetComponent<Image>();
    }

    private void OnEnable()
    {
        ItemImg.sprite = DataManager.Instance.Weapon[0].WeaponImg;
    }
}
