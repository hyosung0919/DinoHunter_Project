using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float spawnRange = 10f;
    private float monsterTimer;
    public TextMeshProUGUI TimerText;                   
    public float Timer;                                 
    void Update()
    {
        monsterTimer += Time.deltaTime;
        
        if (monsterTimer >= spawnRate)
        {
            SpawnEnemy();
            monsterTimer = 0f;
        }
        Timer += Time.deltaTime;
        TimerText.text = "생존 시간 : " + Timer.ToString("0.00");
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRange;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
