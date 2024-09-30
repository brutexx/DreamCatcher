using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private float maximumSpawnTime;

    [SerializeField]
    private float spawnTime;

    private void Awake()
    {
        SetSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetSpawnTime();
        }
    }

    private void SetSpawnTime()
    {
        spawnTime = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
