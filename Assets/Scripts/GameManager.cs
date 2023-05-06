using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //door animator and collider
    public Animator animator;
    public BoxCollider2D doorCollider;

    //Scripts to update UI elements based on their variables
    public SpawnManager spawnManager;
    public PlayerMovement playerMovement;

    //UI text elements
    public TextMeshProUGUI countText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pauseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update UI text
        countText.text = "x" + spawnManager.gemCount;
        scoreText.text = "Score: "+ playerMovement.newScore;
        if(spawnManager.gemCount==0)
        {
            //after collecting all gems open the door
            animator.SetBool("DoorOpen", true);
            // scale the collider of the closed door by 0
            doorCollider.size = new Vector2(0.0f, 0.0f);
        }

        //don't display score and pause text on gameOver screen
        //there was no need to do the same with gameWin screen 
        //as both the UI text and the gameWin screen are white
        if(playerMovement.gameOver)
        {
            scoreText.gameObject.SetActive(false);
            pauseText.gameObject.SetActive(false);
        }        
    }
}
