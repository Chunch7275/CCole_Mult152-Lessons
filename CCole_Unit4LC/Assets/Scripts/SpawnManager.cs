using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 8.5f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
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
