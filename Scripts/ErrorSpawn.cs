//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;


public class ErrorSpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyPos;
    public float spawnmin = 7f;
    public float spawnmax = 3f;
    public float wait = 10f;

    private bool canSpawn;

    private void Awake()
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
