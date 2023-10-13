using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = 5f;
    public float maxY = 15f;
    public float spawnInterval = 10f;

    private float timer;

    void Start()
    {
        
        timer = spawnInterval;
    }

    void Update()
    {        
        timer -= Time.deltaTime;
                
        if (timer <= 0)
        {
            SpawnItem();
            timer = spawnInterval;
        }
    }

    void SpawnItem()
    {
        
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
    }
}