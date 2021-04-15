using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

public class Hareket : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;

    public GameObject rightbullet, leftbullet;
    public Transform leftBulletPos;
    public Transform rightBulletPos;
    AudioController AudioController;
    public AudioClip Gun;
    public AudioClip deadSound;
    public Canvas canvas;

    private float timer;

    public float speed;
    public float ziplamaKuvveti;
    public float nextFire = 0.5f;
    public float second = 5f;
    float time = 3f;

    private bool canFire = true;
    public bool leftClicked;
    public bool rightClicked;
    bool yereDegiyor = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (yereDegiyor)
            {
                Jump();
            }
        }
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            MovePlayer(h);
        }
        else
        {
            StopPlayer();
        }
        if (leftClicked)
        {
            MovePlayer(-1f);
        }
        if (rightClicked)
        {
            MovePlayer(1f);
        }
    }
    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, ziplamaKuvveti);
        
    }
    private void MovePlayer(float h)
    {
        
        rigid.velocity = new Vector2(h * speed, rigid.velocity.y);

        if (h > 0)
        {
            sprite.flipX = true;
        }
        else if (h < 0)
        {
            sprite.flipX = false;
        }
    }
    private void StopPlayer()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D other)
    {       
        if(other.gameObject.tag == "Enemy")
        {
            this.GetComponent<Hareket>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;

            AudioSource.PlayClipAtPoint(deadSound, Camera.main.transform.position);

            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(false);
            }
            StartCoroutine("Dead");
        }
        if (other.gameObject.tag == "Error")
        {
            this.GetComponent<Hareket>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            AudioSource.PlayClipAtPoint(deadSound, Camera.main.transform.position);

            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(false);
            }
            StartCoroutine("Dead");

        }
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(other.gameObject);
            this.GetComponent<Hareket>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            AudioSource.PlayClipAtPoint(deadSound, Camera.main.transform.position);

            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(false);
            }
            StartCoroutine("Dead");
        }
        rigid.velocity = Vector2.zero;    
    } 

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            yereDegiyor = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            yereDegiyor = false;
        }
    }
    private void FireBullet()
    {
        if (canFire)
        {
            
            timer = 0f;
            if (!sprite.flipX)
            {
                Instantiate(rightbullet, rightBulletPos.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(Gun, new Vector3(0, 0, 0));
                
            }
            if (sprite.flipX)
            {
                Instantiate(leftbullet, leftBulletPos.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(Gun, Camera.main.transform.position);

            }
        }
    }
    public void MobileJump()
    {
        Jump();
    }
    public void MobileFireBullet()
    {
        FireBullet();
    }
    public void MoveLeftMobile()
    {
        rightClicked = false;
        leftClicked = true;
    }
    public void MoveRightMobile()
    {
        leftClicked = false;
        rightClicked = true;
    }
    public void StopPlayerMobile()
    {
        rightClicked = false;
        leftClicked = false;
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(time);

        int score = PlayerPrefs.GetInt("score");
        if(BulletController.Skor > score)
        {
            PlayerPrefs.SetInt("score", BulletController.Skor);
            Debug.Log("aa");
        }
        BulletController.Skor = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}

