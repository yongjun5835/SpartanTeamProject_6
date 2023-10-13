using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public string itemName;
    public float damageMultiplier = 1f;         // 데미지 2배
    public int twiceMultiplier = 1;             // 탄환 수 2배
    public float rangeMultiplier = 1f;          // 데미지 범위 반경 2배
}
