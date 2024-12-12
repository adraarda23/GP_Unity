using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_sc : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void Spawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
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
        yield return new WaitForSeconds(3);

        while (!stopSpawner)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector2(Random.Range(-10, 10), 8), Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;

            int xMvSpeed = Random.Range(0, 3);
            xMvSpeed *= (Random.Range(0, 2) == 0) ? 1 : -1;

            newEnemy.GetComponent<Enemy_sc>().setXSpeed(xMvSpeed);

            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

    [SerializeField]
    GameObject[] BonusArr;

    [SerializeField]
    float bonusSpawnRate = 5;
    IEnumerator SpawnBonusRoutine()
    {
        yield return new WaitForSeconds(5);

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