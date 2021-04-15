using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockrandom : MonoBehaviour
{
    public GameObject[] obj;
    public float spawnmin = 1f;
    public float spawnmax = 3f;
    void Start()
    {
        spawnetme();     
    }
    void spawnetme()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);

        Invoke("spawnetme", Random.Range(spawnmin, spawnmax));
    }  
}
