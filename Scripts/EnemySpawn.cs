using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyPos;
    public float spawnmin = 1f;
    public float spawnmax = 3f;
    public float wait = 12f;

    private bool canSpawn;

    void Start()
    {
        canSpawn = true;
    }
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine("SpawnEnemy");
        }
    }
    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, enemyPos.transform.position, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(spawnmin);
        Invoke("SpawnRandom", Random.Range(spawnmin, spawnmax));
        canSpawn = true;
    }
}

