using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] gemPrefabs;
    public int gemCount;

    private float spawnPosX = 8.0f;
    private float spawnPosY = 4.0f;
    private Vector3 spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        //number of gems that will spawn is from 0 to 9
        gemCount = Random.Range(1, gemPrefabs.Length);

        for (int i=0;i<gemCount;++i)
        SpawnGem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGem()  //Spawns Random Gems at random positions
    {
        spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), Random.Range(-spawnPosY, spawnPosY));
        int gemIndex = Random.Range(0, gemPrefabs.Length);
        Instantiate(gemPrefabs[gemIndex], spawnPos, gemPrefabs[gemIndex].transform.rotation); 
    }
}
