using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float rangeMax = 9;

    public int nombreEnnemies;
    public int vague = 1;

    void Start()
    {
        this.SpawnEnemyWawe(vague);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        nombreEnnemies = FindObjectsOfType<Enemy>().Length; 
        if(nombreEnnemies == 0)
        {
            vague++;
            SpawnEnemyWawe(vague);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-rangeMax, rangeMax);
        float spawnPositionZ = Random.Range(-rangeMax, rangeMax);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return spawnPosition;
    }

    public void SpawnEnemyWawe(int ennemiesToSpawn)
    {
        for(int i = 0; i<ennemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, this.GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

}
