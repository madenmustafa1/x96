using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material mat;
    private float offset;
    private Hareket hareket;

    public float speed;
    void Start()
    {
        hareket = GameObject.FindGameObjectWithTag("Player").GetComponent<Hareket>();
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += Input.GetAxisRaw("Horizontal") * speed;

        if(hareket.leftClicked)
        {
            offset += -speed;
        }
        if (hareket.rightClicked)
        {
            offset += speed;
        }
        mat.SetTextureOffset("_MainTex",new Vector2(offset,0));
    }
}
