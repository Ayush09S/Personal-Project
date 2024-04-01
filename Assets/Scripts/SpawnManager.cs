using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject peasant;
    public GameObject knight;
    public GameObject king;
    public GameObject powerup;
    public int waveNumber = 2;

    private int xRange = 24;
    private int zRange = 24;

    private int powerupSpawnDelay = 2;
    private int powerupSpawnTime = 5;

    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", powerupSpawnDelay, powerupSpawnTime);
        SpawnEnemy(peasant, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
        {
            switch (waveNumber)
            {
                case 1:
                    SpawnEnemy(peasant, 1);
                    WaveAdd1();
                    break;
                case 2:
                    SpawnEnemy(peasant, 2);
                    WaveAdd1();
                    break;
                case 3:
                    SpawnEnemy(peasant, 3);
                    WaveAdd1();
                    break;
                case 4:
                    SpawnEnemy(knight, 1);
                    WaveAdd1();
                    break;
                case 5:
                    SpawnEnemy(knight, 2);
                    WaveAdd1();
                    break;
                case 6:
                    SpawnEnemy(knight, 2);
                    SpawnEnemy(peasant, 1);
                    WaveAdd1();
                    break;
                case 7:
                    SpawnEnemy(king, 1);
                    WaveAdd1();
                    break;
                case 8:
                    SpawnEnemy(king, 1);
                    SpawnEnemy(knight, 1);
                    SpawnEnemy(peasant, 2);
                    WaveAdd1();
                    break;

            }
        }
    }

    private void SpawnPowerup()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xRange, -xRange), powerup.transform.position.y, Random.Range(zRange, -zRange));
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

    private void SpawnEnemy(GameObject enemy, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(xRange, -xRange), enemy.transform.position.y, Random.Range(zRange, -zRange));
            Instantiate(enemy, spawnPos, enemy.gameObject.transform.rotation);
        }
    }

    private void WaveAdd1() => waveNumber += 1;
}
