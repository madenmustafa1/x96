using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Error")
        {
            Destroy(other.gameObject);
        }
    }
}
