using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraYükselme : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float minX, maxX;
    public float minY, maxY;

    private AudioSource audioSource;

    void Update()
    {
        //y'ye sayi eklemek kameranın fazla aşağı inmemesini sağlamak için Mathf.Clamp kullanıyoruz.
        //bu iki değeri birbirine sabitliyor.
        Vector3 nextPos = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y + 0.64f, minY, maxY), transform.position.z);

        //daha akıcı bir geçiş için lerp kullanıyoruz.;
        transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
    }
}
