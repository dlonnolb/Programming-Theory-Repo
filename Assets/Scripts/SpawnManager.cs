using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerUp;
    public PlayerController muerto;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 14.0f;
    private float zPowerUpRange = 10.0f;
    private float xPowerUpRange = 12.0f;
    private float ySpawn = 0.75f;
    private float powerUpSpawnTime = 3f;
    private float enemySpawnTime = 1f;
    private float startDelay = 0.5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
    }
    
    void SpawnEnemy()
    {
        if (muerto.Dead == false)
        {
            float randomX = Random.Range(xSpawnRange, -xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);
            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        if (muerto.Dead == false)
        {
            float randomX = Random.Range(xPowerUpRange, -xPowerUpRange);
            float randomZ = Random.Range(zPowerUpRange, -zPowerUpRange);
            Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
            Instantiate(powerUp, spawnPos, powerUp.gameObject.transform.rotation);
        }
    }
}
