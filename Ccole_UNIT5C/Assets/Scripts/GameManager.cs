using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float SpawnRate = 4.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public Button restartbutton;

    private int score = 0;

    public bool gameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget() );
        UpdateScore(0);

        GameOverText.gameObject.SetActive(false);
        restartbutton.gameObject.SetActive(false);
    }

   public void GameOver() 
    {
        gameActive = false;
        GameOverText.gameObject.SetActive(true);
        restartbutton.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget() 
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(SpawnRate); 
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }

    public void UpdateScore (int ScoreDelta) 
    {
        score += ScoreDelta;
        if(score < 0 )
        {
            score = 0;
        }

        scoreText.text = "Score:" + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
