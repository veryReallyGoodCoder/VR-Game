using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private int enemySpawn = 6;
    [SerializeField] public int enemiesKilled = 0;
    private int wave = 3;
    private bool canSpawn = true;
    private bool nextWave = true;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        SpawnEnemy();
        enemiesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemiesKilled);
        Debug.Log(wave);

        if (enemiesKilled >= 6)
        {
            wave++;
            enemiesKilled = 0;
            canSpawn = true;
        }

        if (canSpawn == true)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (wave == 1)
        {
            Debug.Log("1");
            for (int i = 0; i < enemySpawn; i++) 
            {
                Instantiate(enemy1, spawnPoint.position, Quaternion.identity);
                canSpawn = false;
            }
        }

        if (wave == 2)
        {
            Debug.Log("2");
            for (int i = 0; i < enemySpawn; i++)
            {
                Instantiate(enemy2, spawnPoint.position, Quaternion.identity);
                canSpawn = false;
            }
        }

        if (wave == 3)
        {
            Debug.Log("3");
            for (int i = 0; i < enemySpawn; i++)
            {
                Instantiate(enemy3, spawnPoint.position, Quaternion.identity);
                canSpawn = false;
            }
        }
    }
}
