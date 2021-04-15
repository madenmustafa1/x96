
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void Level ()
    {
        Application.LoadLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
