using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 2.0f;
    public List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget() ); 
    }


    IEnumerator SpawnTarget() 
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate); 
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }
}
