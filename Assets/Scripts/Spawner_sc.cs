using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_sc : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }

    void Update()
    {
    }

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject enemyContainer;

    [SerializeField]
    bool stopSpawner = false;

    [SerializeField]
    float enemySpawnRate = 2;
    IEnumerator SpawnEnemyRoutine()
    {
        while (!stopSpawner)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector2(Random.Range(-10, 10), 8), Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;

            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    [SerializeField]
    GameObject[] BonusArr;

    [SerializeField]
    float bonusSpawnRate = 5;
    IEnumerator SpawnBonusRoutine()
    {
        while (!stopSpawner)
        {
            int bonusType = Random.Range(0, 3);

            GameObject newBonus;

            newBonus = Instantiate(BonusArr[bonusType], new Vector2(Random.Range(-10, 10), 8), Quaternion.identity);

            yield return new WaitForSeconds(bonusSpawnRate);
        }
    }

    public void stopSpawnerFunc()
    {
        stopSpawner = true;
    }

    public void startSpawnerFunc()
    {
        stopSpawner = false;
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }
}