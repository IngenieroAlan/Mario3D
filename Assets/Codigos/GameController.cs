using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    private int score = 0;
    private int lives = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addScore(int num)
    {
        score += num;
        scoreText.text = $"Puntuación: {score}";
    }
    public void subtractScore(int num)
    {
        score -= num;
        scoreText.text = $"Puntuación: {score}";
    }
    public void takeLife()
    {
        lives--;
        if (lives < 0)
        {
            gameOver();
        }
        livesText.text = $"Vidas: {lives}";
    }
    public void addLife()
    {
        lives++;
        livesText.text = $"Vidas: {lives}";
    }
    private void gameOver()
    {
        gameOverPanel.SetActive(true);
    }
}