using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    public int waveNumber = 1;


    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //instantiate the enemy in the random position
        SpawnEnemyWave(waveNumber);

        //generate powerups at start of the game 
        SpawnPowerup(1);

        //setting an instance of the object
        playerController = GetComponent<PlayerController>();

    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }


    //general method that can be used in SpawnEnemyWave() and SpawnPowerUps()
    private Vector3 GenerateSpawnPosition()
    {
        //generate random pos on platform

        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        Vector3 randompos = new Vector3(spawnPosx, 0, spawnPosz);
        return randompos;
    }

    // Update is called once per frame
    void Update()
    {
        // using plural FindGameObjectsWithTag()
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyCount == 0  )
        {
            //proceed to the next wave and start spawning enemies
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);

        }
        
        if (playerController.hasPowerUp)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

   
}
