using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI CountDownText;
    public GameObject gameOverScreen;
    public GameObject CountDownScreen;
    public float CountDownTimer = 3f;
    private bool countingdown = true;
    // Add Score

void Start()
{
    CountDownTimer = 3f; // always force this
    countingdown = true;
    CountDownScreen.SetActive(true);
    Time.timeScale = 0f;
}

void Update()
{
    if (countingdown)
    {
        float delta = Mathf.Min(Time.unscaledDeltaTime, 0.1f);
        CountDownTimer -= delta;
        CountDownText.text = Mathf.CeilToInt(CountDownTimer).ToString();
        if (CountDownTimer <= 0)
        {
            CountDownScreen.SetActive(false);
            countingdown = false;
            Time.timeScale = 1f;
        }
    }
}


    [ContextMenu("Add Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }   

    public void RestartGame()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}     
