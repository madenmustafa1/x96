using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    private float seconds;
    private int seconds2;
    BulletController bulletController;

    private void Start()
    {
        text = GetComponent<Text>();
        int score = PlayerPrefs.GetInt("score");
        GameObject.Find("BestScore").GetComponent<Text>().text = "Best Score: " + score; 
    }

}

