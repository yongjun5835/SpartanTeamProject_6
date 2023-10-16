using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPorjectile : MonoBehaviour
{
    private void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
}
