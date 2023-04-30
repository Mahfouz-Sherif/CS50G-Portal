using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseScript : MonoBehaviour
{
    public bool gamePaused = false;
    public PlayerMovement player;
    public void Setup()
    {
        //setup GamePause screen and update flags
        gamePaused = player.gamePaused;
        if(!gamePaused)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        
    }
}
