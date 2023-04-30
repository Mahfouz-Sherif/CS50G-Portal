using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //varisbles for score saving
    public int highScore = 0, newScore = 0;
    public static int levelCounter=1;

    //Player movement variables
    public float moveSpeed = 5.0f;
    Vector2 movement;

    //booleans for gameWin, gamePause, gameOver -> lose (GameStates)
    private bool doorOpenOnce = false;
    public bool gameOver = false;
    public bool gamePaused = false;

    //Player components
    public Rigidbody2D rb; 
    public Animator animator;

    //Script that spawns gems
    public SpawnManager spawnManager;

    //Scripts for UI Canvas
    public GameWinScript gameWinScreen;
    public GamePauseScript gamePauseScreen;

    //Audio
    public AudioClip gemSound;
    public AudioClip doorSound;
    private AudioSource playerAudio;

    //ParticleSystems and particlePoint invisible game object
    private ParticleSystem pickupParticles;
    private ParticleSystem tempParticles;
    public GameObject particlePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        //score is 0 by default so update it if not on level 1 
        if(levelCounter!=1)
        {
            newScore = PlayerPrefs.GetInt("newScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Press P to Pause/Unpause while playing level
        if(Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            gamePaused = ! gamePaused;
            gamePauseScreen.Setup();
            //This is necessary to play music on unpausing (see line 111)  
            playerAudio.Play();
        }

        //Going back to title screen
        if (Input.GetKey("escape") && (gamePaused || gameOver))
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        if(!gameOver && !gamePaused)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            // if-else statement restricts diagonal movement
            if(movement.x==0) 
            {
                movement.y = Input.GetAxisRaw("Vertical");
            }
            else
            {
                movement.y = 0f;
            }
            //set animator parameters to change animation
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            
            //makes the player face the same direction after stopping movement instead of down
            if(movement.x != 0)
            animator.SetFloat("Horizontal2", movement.x);
            if(movement.y != 0)
            animator.SetFloat("Vertical2", movement.y);

            //set dooropen boolean and play sound after collecting all gems
            //boolean to be used in GameManager script
            if(spawnManager.gemCount==0 && !doorOpenOnce)
            {
                playerAudio.PlayOneShot(doorSound, 1.0f);
                doorOpenOnce = true;
            }

            
        }
        else if(gameOver || gamePaused)
        {
            //stop music on level end or pause
            playerAudio.Stop();
        }

        //Continue to next level after winning and pressing space
        if(gameWinScreen.gameWin && Input.GetKeyDown(KeyCode.Space))
        {
                SceneManager.LoadScene("PlayScene");
                levelCounter++;
        }
    }

    void FixedUpdate() 
    {
        //Player Movement
        if(!gameOver && !gamePaused)
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //check for collisions only while playing
        if(!gameOver && !gamePaused)
        {
            //when player collects gem-> increase score, play sound, update UI and play Particle effect
            if (other.gameObject.CompareTag("Gem"))
            {
                newScore+=5;
                playerAudio.PlayOneShot(gemSound, 1.0f);
                
                //because the gem will be destroyed the particleSystem component on it (pickupParticles) will be destroyed as well
                //so to make it play I made a gameObject (particlePoint) with a copy of the particleSystem component (tempParticles)
                //of the gem prefab and moved it to the gem's position
                particlePoint.transform.position = other.gameObject.transform.position;
                tempParticles = particlePoint.GetComponent<ParticleSystem>();
                pickupParticles = other.gameObject.GetComponent<ParticleSystem>();
                
                //and then took the color from the gem's pickupParticles into tempParticles
                tempParticles.startColor = pickupParticles.startColor;
                //and now it's ready for playing
                tempParticles.Play();
                
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                //Debug.Log(spawnManager.gemCount);

                //Update gemCount for UI and gameplay
                spawnManager.gemCount--;
                //Debug.Log(spawnManager.gemCount);
            }

            //when player collides with the open door ->increase score, store High Score and update UI
            if (other.gameObject.CompareTag("Escape"))
            {
                newScore+= 25;

                //Store High Score if currentscore is higher than previous highscore
                if(PlayerPrefs.HasKey("HiScore"))
                {
                    if(newScore > PlayerPrefs.GetInt("HiScore"))
                    {
                        highScore = newScore;
                        PlayerPrefs.SetInt("HiScore", highScore);
                        PlayerPrefs.Save();
                    }
                }
                else
                {   
                    if(newScore > highScore)
                    {
                        highScore = newScore;
                        PlayerPrefs.SetInt("HiScore", highScore);
                        PlayerPrefs.Save();
                    }
                }
                PlayerPrefs.SetInt("newScore", newScore);
                //update UI
                gameWinScreen.Setup();
                //Debug.Log("You Win");
            }
        }
    }

    
}
