using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject PowerupPrefab;
    private float spawnRange = 8.5f;
    private int enemyCount;

    private int WaveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(WaveNumber);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0) 
        {
            WaveNumber++;
            SpawnWave(WaveNumber);
        }
        Debug.Log(enemyCount);
    }
    void SpawnWave(int EnemyNum)
    {
        Instantiate(PowerupPrefab, GenerateSpawnPos(), PowerupPrefab.transform.rotation);
        for (int i = 0; i < EnemyNum; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    Vector3 GenerateSpawnPos() 
    { 
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 SpawnPos = new Vector3(xPos,enemyPrefab.transform.position.y, zPos);
        return SpawnPos;
    }
}
