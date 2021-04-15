using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;//ınput output için
using System.Runtime.Serialization.Formatters.Binary;

public class GameScript : MonoBehaviour
{
    public void PlayerÖlünce(GameObject player)
    {
        
        StartCoroutine("GamePause", player);

    }
    IEnumerator GamePause(GameObject player)
    {
        yield return new WaitForSeconds(2f);
        PlayerDied(player);
    }
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
    }
}
