using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] public string WeaponName;
    [SerializeField] public string WeaponType;
    [SerializeField] public float WeaponDamage;
    [SerializeField] public float WeaponRange;
    [SerializeField] public Sprite WeaponImg;
}
