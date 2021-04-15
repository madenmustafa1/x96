using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource GunFire;
    public AudioClip Gun;
    void Start()
    {
        GunFire = GetComponent<AudioSource>();
    }
    public void OnFire()
    {
        GunFire.Play();
        AudioSource.PlayClipAtPoint(Gun, Camera.main.transform.position);

    }
}
