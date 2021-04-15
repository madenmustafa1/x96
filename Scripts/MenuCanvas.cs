using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    bool pause;
    PauseMenu pauseMenu;
    public void Pause ()
    {
        pause = !pause;
        if(pause)
        {
            Time.timeScale = 0;
        }
        if(!pause)
        {
            Time.timeScale = 1;
        }     
    }
}
