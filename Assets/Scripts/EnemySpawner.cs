using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private PosteManager posteManager;

    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private float maximumSpawnTime;

    [SerializeField]
    private float spawnTime;

    int qtdPostesLigados = 0;

    private void Awake()
    {
        SetSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        qtdPostesLigados = posteManager.qtdPostesLigados();

        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetSpawnTime();
        }
    }

    private void SetSpawnTime()
    {
        spawnTime = Random.Range(minimumSpawnTime - qtdPostesLigados, maximumSpawnTime - qtdPostesLigados);
    }
}
