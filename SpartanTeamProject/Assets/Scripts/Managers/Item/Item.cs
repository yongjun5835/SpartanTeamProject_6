using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSlot slot;


    private void Start()
    {
        slot = FindObjectOfType<ItemSlot>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            slot.OnItemAcquired();
          
        }
    }
}
