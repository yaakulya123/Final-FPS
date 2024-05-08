using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy")] public GameObject enemyPrefab;
    [Header("Spawn Points")] public Transform[] spawnPoints;
    private void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (GameManager.Instance.enemyCount == 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}
