using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerUp;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 16.0f;
    private float zPowerUpRange = 5.0f;
    private float xPowerUpRange = 5.0f;
    private float ySpawn = 0.75f;
    private float powerUpSpawnTime = 5.75f;
    private float enemySpawnTime = 2.0f;
    private float startDelay = 0.75f;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay,enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay,powerUpSpawnTime);
    }
        
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(xSpawnRange, -xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(xPowerUpRange, -xPowerUpRange);
        float randomZ = Random.Range(zPowerUpRange, -zPowerUpRange);
        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
        Instantiate(powerUp, spawnPos, powerUp.gameObject.transform.rotation);

    }
}
