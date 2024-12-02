using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float SpawnRate = 4.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public Button restartbutton;
    public GameObject TitleScreen;

    private int score = 0;

    public bool gameActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void StartGame(int diff)
    {
        gameActive = true;
        score = 0;
        SpawnRate = SpawnRate / diff;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
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
