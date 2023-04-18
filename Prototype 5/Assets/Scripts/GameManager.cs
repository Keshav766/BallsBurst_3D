using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> gameItems;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
     

    public float spawnRate = 1;
    private int score;
    public int goodFall;
    public bool isGameActive;

    void Start()
    {
        goodFall = 4;
        titleScreen.SetActive(true);
    }

    IEnumerator spawnObjects(float x)
    {
        while (isGameActive)
        {
            int index = Random.Range(0, 5);
            yield return new WaitForSeconds(x);
            Instantiate(gameItems[index]);
            
        }
    }

    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        scoreText.text = "Score : " + score;
    }

    public void UpdateLives()
    {
        goodFall--;
        livesText.text = "Lives : " + goodFall;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(spawnObjects(spawnRate));
        score = 0;
        UpdateScore(0);
        UpdateLives();
        titleScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(goodFall <= 0)
        {
            GameOver();
        }
    }

}
