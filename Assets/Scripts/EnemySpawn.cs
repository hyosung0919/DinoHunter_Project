using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float spawnRange = 10f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRange;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
