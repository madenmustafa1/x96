using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnMove : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemySpawn");

        Invoke("Enemy", Random.Range(3f, 3f));
    }
    void bulutUst()
    {
        Instantiate(enemy, GameObject.FindGameObjectWithTag("EnemySpawn").transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
    } 
    void Update()
    {
        if (Time.timeScale == 1)
        {
            transform.position = (new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z));
        }      
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Error")
        {
            Destroy(gameObject);
        }
    }
}
