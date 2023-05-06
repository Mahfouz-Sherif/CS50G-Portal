using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LowerLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D myLight;
    public GameOverScript GameOverScreen;
    public PlayerMovement player;
   
    // Update is called once per frame
    void Update() 
    {   
        //Play again if you press space at gameOverScreen
        if(!player.gamePaused)
        {
            if(GameOverScreen.gameOver && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
    
    void FixedUpdate()
    {
        //Decrease the light intensity of the torches unless the game is paused
        if(!player.gamePaused)
        {
            //myLight.intensity = Mathf.PingPong(Time.time, 8);
            myLight.intensity -= myLight.intensity * (Time.fixedDeltaTime/20);
            if(myLight.intensity <= 0.01) //not <= 0 because of error
            {
                //You lose if the torches' lights completely vanish
                GameOverScreen.Setup();
                //Debug.Log("You lose");
            }  
        }
        
    }
}
