using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public GameObject powerupPrefab;
    private float _spawnRange = 9;
    public int enemyCount;
    public int waveNumber;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // This function will generate a random spawn position for any object that will sit atop of the plane.
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<FollowPlayer>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            //Instantiate(powerupPrefab, GenerateSpawnPos(), Quaternion.identity);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
        
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
