using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinScript : MonoBehaviour
{
    public bool gameWin = false;
    public PlayerMovement player;
    public void Setup()
    {
        //setup GameWin screen and update flags
        gameObject.SetActive(true);
        player.gameOver = true;
        gameWin = true;
    }
}
