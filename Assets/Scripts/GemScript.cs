using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private float spawnPosX = 8.0f;
    private float spawnPosY = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position =new Vector3(5, 2.5f); used for debugging in scene view
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //this code prevents gems overlapping torches and other gems
        //which prevents gameplay bugs and confusion
        if(other.gameObject.CompareTag("Gem") || other.gameObject.CompareTag("Torch"))
        {
            transform.position = new Vector3(Random.Range(-spawnPosX, spawnPosX), Random.Range(-spawnPosY, spawnPosY));
        }
    }
}
