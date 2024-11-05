using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_sc : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnRoutine());
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
    float spawnRate = 2;
    IEnumerator SpawnRoutine()
    {
        while (!stopSpawner)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), 8, 0), Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void stopSpawnerFunc()
    {
        stopSpawner = true;
    }
}