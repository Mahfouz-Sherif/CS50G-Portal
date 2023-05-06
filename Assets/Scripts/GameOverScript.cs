using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public bool gameOver = false;
    public PlayerMovement player;
    public void Setup()
    {
        //setup GameOver screen and update flags
        gameObject.SetActive(true);
        gameOver = true;
        player.gameOver = true;
        //reset levelCounter to 1 to also reset currentscore to 0
        PlayerMovement.levelCounter =1;
    }

}
