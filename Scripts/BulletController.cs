using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public Vector2 speed;   
    public float wait = 4f;
    
    private Rigidbody2D rigid;
    Hareket hareket;
    public AudioClip deadSound;
    public AudioClip deadSound2;

    public static int Skor;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        rigid.velocity = speed;

        StartCoroutine("Delete");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {            
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(deadSound2, other.gameObject.transform.position);
            Ekle();
        }
        else if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deadSound2, other.gameObject.transform.position);
        }
        if(other.gameObject.CompareTag("Error"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deadSound, other.gameObject.transform.position);
        }
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
    }
    public void Ekle()
    {
        Skor = Skor + 1;
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE: " + Skor;
    }
}