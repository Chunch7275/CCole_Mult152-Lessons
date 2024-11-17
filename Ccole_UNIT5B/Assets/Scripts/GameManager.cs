using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 2.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget() );
        UpdateScore(0);
    }


    IEnumerator SpawnTarget() 
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate); 
            UpdateScore(1);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }

    public void UpdateScore (int ScoreDelta) 
    {
        score += ScoreDelta;
        if(score > 0 )
        {
            score = 0;
        }

        scoreText.text = "Score:" + score;
    }
}
