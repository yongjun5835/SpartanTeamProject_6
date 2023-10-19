using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;

    public event Action OnHealthChange;

    public bool isDead;

    private void Start()
    {
        curHealth = maxHealth;
        isDead = false;
    }

    public void TakenDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth < 0)
        {
            curHealth = 0f;
            isDead = true;
        }
        CallHpChanged();
    }

    public void CallHpChanged() 
    {
        OnHealthChange?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item")) 
        {
            ItemSlot itemSlotScript = GetComponent<ItemSlot>();
           
            
            Destroy(other.gameObject); // �������� ȹ�������Ƿ� ������ GameObject�� ����
        }
    }
}
