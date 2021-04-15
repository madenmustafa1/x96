using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Canvas canvas;
    bool pause = false;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);

    }
    public void CanvasOnOff()
    {       
        pause = !pause;
        if (pause)
        {
            canvas.gameObject.SetActive(true);
        }
        if (!pause )
        {
            canvas.gameObject.SetActive(false);
        }
    }

}
