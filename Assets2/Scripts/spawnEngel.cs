using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEngel : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    public float spawnPosZ;
    public float StartDelay;
    public float spawnInterval;

    private void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 3, 5);
        
    }

    void SpawnRandomEnemy()
    {

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
         //Vector3 spawnPos = new Vector3(493.5f, 152.7f, 5743); // Random.Range(143.09f, 168f)  -- Random.Range(7.2f, 25)
        Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
