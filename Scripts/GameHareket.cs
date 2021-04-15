using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHareket : MonoBehaviour
{
    Hareket player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Hareket>();
    }
    private void FixedUpdate()
    {
        RightButton();
    }
    public void JumpButton()
    {
        player.MobileJump();
    }
    public void FireButton()
    {
        player.MobileFireBullet();
    }
    public void LeftButton()
    {
        player.MoveLeftMobile();
    }
    public void RightButton()
    {
        player.MoveRightMobile();
    }
    public void StopButton()
    {
        player.StopPlayerMobile();
    }
}