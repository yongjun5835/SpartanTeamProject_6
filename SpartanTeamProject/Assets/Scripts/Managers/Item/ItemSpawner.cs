using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float minSpawnInterval = 5f; // �ּ� ���� �ֱ�
    public float maxSpawnInterval = 10f; // �ִ� ���� �ֱ�

    private float timeSinceLastSpawn = 0.0f;
    private float spawnInterval;
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnItem();
            timeSinceLastSpawn = 0.0f; // ������ ���� �� �ð� �ʱ�ȭ

            SetRandomSpawnInterval();
        }
    }

    void SpawnItem()
    {
        float randomX = Random.Range(28f, 35f);
        float randomY = Random.Range(15f, 20f);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        // �������� ����
        GameObject newItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        
        newItem.AddComponent<BoxCollider2D>();
                       
    }

    void SetRandomSpawnInterval()
    {
        
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
